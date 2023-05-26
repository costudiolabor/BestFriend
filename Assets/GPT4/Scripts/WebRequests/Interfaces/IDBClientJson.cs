using Cysharp.Threading.Tasks;
using Enums;

public interface IDBClientJson : IDBClient {
    public RequestMethod method{ get; set; }
    public UniTask<string> Request(string url, string paramJson = "");
}
