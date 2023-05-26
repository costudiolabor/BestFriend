using UnityEngine;
using Enums;

[CreateAssetMenu(fileName = "GptConnectionSettings", menuName = "ScriptableObjects/GptConnectionSettings", order = 1)]
public class GptConnectionSettings : ScriptableObject {
	private const string DEFAULT_URL = @"https://api.openai.com/v1/chat/completions";
	public string completionUrl => DEFAULT_URL;
	public string privateApiKey;
	public string organization;
}
