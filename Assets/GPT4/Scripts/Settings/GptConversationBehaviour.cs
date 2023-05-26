using UnityEngine;
using Enums;
[CreateAssetMenu(fileName = "ConversationBehaviour", menuName = "ScriptableObjects/ConversationBehaviour", order = 1)]
public class GptConversationBehaviour : ScriptableObject {
	private const string MODEL_GPT_3_5_TURBO = "gpt-3.5-turbo";
	private const string MODEL_GPT_4 = "gpt-4";

	[SerializeField] private ChatModels model = ChatModels.GPT_3_5_TURBO;
	public string gptModelName => model == ChatModels.GPT_3_5_TURBO ? MODEL_GPT_3_5_TURBO : MODEL_GPT_4;
	
	[Multiline(4)]
	public string mainLegend;
	public string[] facts;
	[Space]

	[Range(0, 2)]
	public float temperature = 0.7f;
	[Range(0, 1)]
	public float topP = 1f;
	[Range(-2, 2)]
	public float presencePenalty = 0f;
	[Range(-2, 2)]
	public float frequencyPenalty = 0f;
	[Range(0, 4096)]
	public int maxTokenLength = 600;

	public int choicesCount =1;
}
