using System;
using Cysharp.Threading.Tasks;
using SerializeDeserialize;

public class GptRequests : Requests {
  public GptConnectionSettings connectionSettings {
		set => _connectionSettings = value;
	}
	
	private GptConnectionSettings _connectionSettings;

	public async UniTask<ChatApiResponse> Send(ChatApiRequest request) {
		if (!_connectionSettings) throw new Exception("Connection settings not found");
		
		authorKey = $"Bearer {_connectionSettings.privateApiKey}";
		return await PostJsonBodyAsync<ChatApiResponse, ChatApiRequest>(_connectionSettings.completionUrl, request);
	}
}
