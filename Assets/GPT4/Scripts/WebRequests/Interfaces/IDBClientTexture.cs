using Cysharp.Threading.Tasks;
using Enums;
using UnityEngine;

public interface IDBClientTexture : IDBClient {
    
    public UniTask<Texture2D> RequestTexture(string url);
}
