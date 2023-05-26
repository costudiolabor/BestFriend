using System;
using UnityEngine;
using UnityEngine.UI;

public class ItemImage : Item<ItemHair>
{
    [SerializeField] private RawImage imageSample;
    [SerializeField] private Button buttonItem;

    public event Action ClickItemEvent;
    private void Awake() {
        buttonItem.onClick.AddListener(OnClickItem);
    }

    private void OnClickItem() {
        ClickItemEvent?.Invoke();
    }
    
    // public void SetImage(Texture texture) {
    //     imageSample.texture = texture;
    // }
    //
    // public void SetColor(Color color) {
    //     imageSample.color = color;
    // }

    public override void SetData(ItemHair data, bool isTexture) {
        imageSample.texture = data.texture;
    }
}
