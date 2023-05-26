using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine;
using SerializeDeserialize;

[System.Serializable]
public class GptConversation {
	[SerializeField] private GptConnectionSettings gptConnectionSettings;
	private GptConversationBehaviour _gptConversationBehaviour;
	
	private GptRequests _requests = new();
	private List<ChatApiMessage> _messagingHistory = new();

	public void StartConversation(GptConversationBehaviour behaviour) {
		_gptConversationBehaviour = behaviour;
		_requests.connectionSettings = gptConnectionSettings;
		SetLegend();
	}

	public void StopConversation() {
		_messagingHistory.Clear();
	}

	public async UniTask<string> SendUser(string message) {
		_messagingHistory.Add(new UserApiMessage() {content = message});
		var request = CreateChatRequest();
		
		var response= await _requests.Send(request);
		return response.isSuccess ? response.choices[0].message.content : response.error;
	}
	
	private void SetLegend() {
		var legend = string.Join("\n",_gptConversationBehaviour.facts);
		legend += $"\"\n\"{_gptConversationBehaviour.mainLegend}";
		_messagingHistory.Add(new SystemApiMessage() {content = legend});
	}
	
	protected ChatApiRequest CreateChatRequest() {
		return new ChatApiRequest {
				model = _gptConversationBehaviour.gptModelName,
				messages = _messagingHistory.ToArray(),
				frequency_penalty = _gptConversationBehaviour.frequencyPenalty,
				presence_penalty = _gptConversationBehaviour.presencePenalty,
				temperature = _gptConversationBehaviour.temperature,
				top_p = _gptConversationBehaviour.topP,
				max_tokens = _gptConversationBehaviour.maxTokenLength,
				n = _gptConversationBehaviour.choicesCount,
		};
	}
}