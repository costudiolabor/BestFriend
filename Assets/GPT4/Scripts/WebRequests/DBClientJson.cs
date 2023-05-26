#nullable enable
using System.Text;
using UnityEngine.Networking;
using Cysharp.Threading.Tasks;
using Enums;
using UnityEngine;

public class DBClientJson : IDBClientJson {
    private const string REQUEST_CONTENT_TYPE = "application/json";
    public HttpStatus responseCode{ get; set; }
    public RequestMethod method{ get; set; }
    public string authorKey{ get; set; } = string.Empty;

    public  async UniTask<string?> Request(string url, string paramJson = ""){
        responseCode = HttpStatus.ReadyToReceive;

        using (var webRequest = new UnityWebRequest(url, method.ToString())){
            webRequest.downloadHandler = new DownloadHandlerBuffer();
            webRequest.SetRequestHeader("accept", REQUEST_CONTENT_TYPE);
            webRequest.SetRequestHeader("Content-Type", REQUEST_CONTENT_TYPE);
            webRequest.SetRequestHeader("Authorization", authorKey);
            webRequest.certificateHandler = new ForceAcceptAllCertificates();

            if (paramJson != "")
                webRequest.uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(paramJson));

            var operation = webRequest.SendWebRequest();
            while (!operation.isDone) await UniTask.Yield();

            responseCode = (HttpStatus)webRequest.responseCode;
            
            return webRequest.downloadHandler.text;
        }
    }
}