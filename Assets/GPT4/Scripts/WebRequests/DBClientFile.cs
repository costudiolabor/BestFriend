using UnityEngine.Networking;
using Cysharp.Threading.Tasks;
using Enums;

public class DBClientFile : IDBClientFile {
    public HttpStatus responseCode{ get; set; }

    public string authorKey{ get; set; } = string.Empty;

    public async UniTask<bool> RequestFile(string url, string savePath){
        responseCode = HttpStatus.ReadyToReceive;

        using (var webRequest =  UnityWebRequest.Get(url)){
            var downloadHandlerFile = new DownloadHandlerFile(savePath);
            downloadHandlerFile.removeFileOnAbort = true;

            webRequest.downloadHandler = downloadHandlerFile;
            webRequest.certificateHandler = new ForceAcceptAllCertificates();
            webRequest.SetRequestHeader("Authorization", authorKey);

            var operation = webRequest.SendWebRequest();
            while (!operation.isDone) await UniTask.Yield();

            responseCode = (HttpStatus)webRequest.responseCode;

            return webRequest.result == UnityWebRequest.Result.Success;
        }
    }
}