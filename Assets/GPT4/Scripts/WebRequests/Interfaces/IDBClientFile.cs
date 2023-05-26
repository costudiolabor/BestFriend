using Cysharp.Threading.Tasks;

public interface IDBClientFile:IDBClient {
    public UniTask<bool> RequestFile(string url, string savePath);
}