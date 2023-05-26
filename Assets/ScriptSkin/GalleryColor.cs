using System.Collections.Generic;
using UnityEngine;
using System;

public class GalleryColor: ItemsList<ItemColor, Material> {
   
    public event Action<int> ClickItemEvent;
    private void OnClickItem(int index) {
        ClickItemEvent?.Invoke(index);
    }
  
    public void SetContent(List<Material> materials, bool isTexture = true) {
        AddItems(materials, isTexture);
    }

    public void SetActive(bool state) {
        gameObject.SetActive(state);
    }

    protected override void OnItemCreate(ItemColor item) {
        var indexButton = itemsList.IndexOf(item);
        item.ClickItemEvent += () => { OnClickItem(indexButton); };
    }

    protected override void OnItemDestroy(ItemColor item) {
    }
}