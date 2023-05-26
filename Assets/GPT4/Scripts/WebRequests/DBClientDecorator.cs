#nullable enable

using Enums;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class DBClientDecorator : IDBClientJson, IDBClientForm, IDBClientTexture, IDBClientFile {
    public HttpStatus responseCode{ get; set; }
    public RequestMethod method{ get; set; }
    public string authorKey{ get; set; } = string.Empty;

    private readonly IDBClientJson _clientJson = new DBClientJson();
    private readonly IDBClientForm _clientForm = new DBClientForm();
    private readonly IDBClientFile _clientFile = new DBClientFile();
    private readonly IDBClientTexture _clientTexture = new DBClientTexture();
    
    public async UniTask<string> Request(string url, WWWForm body){
        _clientForm.authorKey = authorKey;
        var requestResult = await _clientForm.Request(url, body);

        responseCode = _clientForm.responseCode;
        return requestResult;
    }

    public async UniTask<string> Request(string url, string paramJson = ""){
        _clientJson.method = method;
        _clientJson.authorKey = authorKey;
        var requestResult = await _clientJson.Request(url, paramJson);

        responseCode = _clientJson.responseCode;
        return requestResult;
    }

    public async UniTask<Texture2D> RequestTexture(string url){
        _clientTexture.authorKey = authorKey;
        var requestResult = await _clientTexture.RequestTexture(url);

        responseCode = _clientTexture.responseCode;
        return requestResult;
    }

    public async UniTask<bool> RequestFile(string url, string savePath){
        _clientFile.authorKey = authorKey;
        var requestResult = await _clientFile.RequestFile(url, savePath);

        responseCode = _clientFile.responseCode;
        return requestResult;
    }
}