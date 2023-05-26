#nullable enable
using System.Text;
using UnityEngine.Networking;
using Cysharp.Threading.Tasks;
using Enums;
using UnityEngine;

public class DBClientForm : IDBClientForm {
    private const string ACCEPT_TYPE = "application/json";
    public HttpStatus responseCode{ get; set; }
    public string authorKey{ get; set; } = string.Empty;

    public async UniTask<string?> Request(string url, WWWForm body){
        responseCode = HttpStatus.ReadyToReceive;

        using (var webRequest = UnityWebRequest.Post(url, body)){
            webRequest.SetRequestHeader("accept", ACCEPT_TYPE);
            webRequest.SetRequestHeader("Authorization", authorKey);
            webRequest.certificateHandler = new ForceAcceptAllCertificates();

            var operation = webRequest.SendWebRequest();
            while (!operation.isDone) await UniTask.Yield();

            responseCode = (HttpStatus)webRequest.responseCode;

            return webRequest.downloadHandler.text;
        }
    }
}