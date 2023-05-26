#nullable enable

using Enums;
using UnityEngine;
using Cysharp.Threading.Tasks;
using SerializeDeserialize;

public class Requests : DBClientDecorator {
	private bool requestSuccess => responseCode is HttpStatus.IsOk or HttpStatus.Created;
	protected async UniTask<TResult?> PostJsonBodyAsync<TResult, TParam>(string requestUrl, TParam body) where TResult : ResponseData, new() where TParam : class {
		method = RequestMethod.POST;
		var operationIdParamInJson = JsonUtility.ToJson(body);
		var jsonString = await Request(requestUrl, operationIdParamInJson);

		return requestSuccess ? JsonUtility.FromJson<TResult>(jsonString) : new TResult() {error = jsonString, isSuccess = requestSuccess};
	}
	
    protected async UniTask<TResult?> GetAsync<TResult>(string requestUrl) where TResult : class{
        method = RequestMethod.GET;
        var jsonString = await Request(requestUrl);

        return jsonString != null ? JsonUtility.FromJson<TResult>(jsonString) : default;
    }

    protected async UniTask<TResult?> GetQueryParamsAsync<TResult, TParam>(string requestUrl, TParam queryParams) where TResult : class where TParam : class{
        method = RequestMethod.GET;
        var param = JsonUtility.ToJson(queryParams);

      //  if (param != null)
        //    param = Utils.JsonToQueryParams(param);

        requestUrl += param;
        var jsonString = await Request(requestUrl);

        return jsonString != null ? JsonUtility.FromJson<TResult>(jsonString) : default;
    }

    protected async UniTask<TResult?> PostAsync<TResult>(string requestUrl) where TResult : class{
        method = RequestMethod.POST;
        var jsonString = await Request(requestUrl);

        return jsonString != null ? JsonUtility.FromJson<TResult>(jsonString) : default;
    }



    protected async UniTask<TResult?> PostFormBodyAsync<TResult>(string requestUrl, WWWForm body) where TResult : class{
        var jsonString = await Request(requestUrl, body);

        return jsonString != null ? JsonUtility.FromJson<TResult>(jsonString) : default;
    }
    protected async UniTask<TResult?> PutAsync<TResult, TParam>(string requestUrl, TParam body) where TResult : class where TParam : class{
        method = RequestMethod.PUT;
        var operationIdParamInJson = JsonUtility.ToJson(body);
        var jsonString = await Request(requestUrl, operationIdParamInJson);

        return jsonString != null ? JsonUtility.FromJson<TResult>(jsonString) : default;
    }

    protected async UniTask<Texture2D> GetTexture(string requestUrl){
        var texture = await RequestTexture(requestUrl);

        return texture != null ? texture : new Texture2D(0, 0);
    }

    protected async UniTask<bool> DeleteAsync(string requestUrl){
        method = RequestMethod.DELETE;
        var jsonString = await Request(requestUrl);
        return responseCode == HttpStatus.IsOk;
    }
    
}