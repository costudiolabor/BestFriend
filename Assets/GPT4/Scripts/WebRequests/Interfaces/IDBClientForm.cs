using Cysharp.Threading.Tasks;
using Enums;
using UnityEngine;

public interface IDBClientForm : IDBClient {
    public UniTask<string> Request(string url, WWWForm body);
}
