using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Serialization;

public abstract class ItemsList<TItem, TData> : MonoBehaviour where TItem : Item<TData> where TData : class {
    [SerializeField] protected RectTransform itemsParent;
    [SerializeField] protected TItem prefab;
    
    public int count => itemsList.Count;
    protected readonly List<TItem> itemsList = new List<TItem>();
    public bool AddItems(List<TData> items, bool isTexture){
        if (itemsList.Count != 0) Clear();
        //Debug.Log("clear");

        foreach (var task in items)
            Add(task, isTexture);

        return true; // return value for await until
    }

    public virtual void Clear(){
        foreach (var item in itemsList){
            OnItemDestroy(item);
            Destroy(item.gameObject);
        }
        itemsList.Clear();
    }

    public void Add(TData data,  bool isTexture){
        var item = Spawn(data);
        itemsList.Add(item);
        OnItemCreate(item);
        item.SetData(data, isTexture);
    }

    public void Remove(TItem item){
        itemsList.Remove(item);
        OnItemDestroy(item);
        Destroy(item.gameObject);
    }

    protected virtual TItem Spawn(TData data = null) =>
        Instantiate(prefab, itemsParent);

    protected abstract void OnItemCreate(TItem item);
    protected abstract void OnItemDestroy(TItem item);
}