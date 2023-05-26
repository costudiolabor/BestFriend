using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item<TData> : MonoBehaviour {
    public abstract void SetData(TData data,  bool isTexture);
}
