using UnityEngine.Networking;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Enums;

public class DBClientTexture : IDBClientTexture {
    private const string REQUEST_CONTENT_TYPE = "application/json";
    public HttpStatus responseCode{ get; set; }
    public string authorKey{ get; set; } = string.Empty;

    public async UniTask<Texture2D> RequestTexture(string url){
        responseCode = HttpStatus.ReadyToReceive;

        using (var webRequest = UnityWebRequestTexture.GetTexture(url)){
            webRequest.SetRequestHeader("Authorization", authorKey);
            webRequest.certificateHandler = new ForceAcceptAllCertificates();

            var operation = webRequest.SendWebRequest();
            while (!operation.isDone) await UniTask.Yield();

            responseCode = (HttpStatus)webRequest.responseCode;

            return DownloadHandlerTexture.GetContent(webRequest);
        }
    }
}