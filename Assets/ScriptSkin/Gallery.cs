using System.Collections.Generic;
using System;

public class Gallery : ItemsList<ItemImage, ItemHair> {
   public event Action<int> ClickItemEvent;
  private void OnClickItem(int index) {
     ClickItemEvent?.Invoke(index);
  }
  
   public void SetContent(List<ItemHair> itemHairs,  bool isTexture) {
    AddItems(itemHairs, isTexture);
   }

   public void SetActive(bool state) {
    gameObject.SetActive(state);
   }

   protected override void OnItemCreate(ItemImage item) {
    var indexButton = itemsList.IndexOf(item);
    item.ClickItemEvent += () => { OnClickItem(indexButton); };
   }

   protected override void OnItemDestroy(ItemImage item) {
    
   }
}




