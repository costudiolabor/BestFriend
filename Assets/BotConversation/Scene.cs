using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Scene : MonoBehaviour {
	[SerializeField] private TMP_InputField input;
	[SerializeField] private GptConversationBehaviour behaviour;
	[SerializeField] private GptConversation gptConversation;
	[SerializeField] private MessageBoard messageBoard;

	private void Awake() {
		gptConversation.StartConversation(behaviour);
		input.onSubmit.AddListener(OnSubmit);
	}
	private async void OnSubmit(string text) {
		input.interactable = false;
		messageBoard.CreateUserMessage("Работяга", text);
		
		var f = await gptConversation.SendUser(text);

		input.interactable = true;
		messageBoard.CreateCompanionMessage("Начальник", f);

		//text.text = string.Join("\n", f);
		input.text = string.Empty;
	}


}
