using System;
namespace SerializeDeserialize {

	// the api response for chat requests
	[Serializable]
	public class ChatApiResponse :ResponseData {
		public string id; // the id of the response
		public long created; //public string object;
		public ChatApiChoice[] choices; // an array of choices for the response
		public ApiUsage usage; // api usage for the request
	}

	[Serializable]
	public class ResponseData {
		public string error;
		public bool isSuccess = true;
	}

	[Serializable]
	public class ChatApiChoice {
		public int index; // this index of the choice
		public ChatApiMessage message; // the message completion for the choice
		public string finish_reason; // the finish reason for choice
	}

	[Serializable]
	public class ChatApiMessage {
		public string role;
		public string content;
	}

	[Serializable]
	public class SystemApiMessage : ChatApiMessage {
		private const string SYSTEM_ROLE = "system";
		public SystemApiMessage() { role = SYSTEM_ROLE; }
	}

	[Serializable]
	public class UserApiMessage : ChatApiMessage {
		private const string USER_ROLE = "user";
		public UserApiMessage() { role = USER_ROLE; }
	}

	[Serializable]
	public class ApiUsage {
		public int prompt_tokens; // the amount of tokens in the request
		public int completion_tokens; // the amount of tokens int the response
		public int total_tokens; // the total amount of tokens in both the request and response
	}

	[Serializable]
	public class ChatApiRequest {
		public string model; // ID of the model to use
		public ChatApiMessage[] messages; // The messages to generate chat completions for
		public int max_tokens; // The maximum number of tokens allowed for the generated answer. By default, the number of tokens the model can return will be (4096 - prompt tokens).
		public double temperature; // What sampling temperature to use, between 0 and 2. Higher values like 0.8 will make the output more random, while lower values like 0.2 will make it more focused and deterministic.
		public double top_p; // An alternative to sampling with temperature, called nucleus sampling, where the model considers the results of the tokens with top_p probability mass. So 0.1 means only the tokens comprising the top 10% probability mass are considered.
		public double presence_penalty; //Number between -2.0 and 2.0. Positive values penalize new tokens based on whether they appear in the text so far, increasing the model's likelihood to talk about new topics.
		public double frequency_penalty; // Number between -2.0 and 2.0. Positive values penalize new tokens based on their existing frequency in the text so far, decreasing the model's likelihood to repeat the same line verbatim.
		public int n; // How many chat completion choices to generate for each input message.
		public bool stream = false;
		/// <summary>
		/// A unique identifier representing your end-user, which can help OpenAI to monitor and detect abuse.
		/// </summary>
		//public string user;
	}
}
