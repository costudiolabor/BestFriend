using System;
using UnityEngine;
using UnityEngine.UI;
public class ItemColor : Item<Material>
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
    
    public void SetImage(Texture texture) {
        imageSample.texture = texture;
    }
    
    public void SetColor(Color color) {
        imageSample.color = color;
    }

    public override void SetData(Material data,  bool isTexture)
    {
        if (isTexture) SetImage(data.mainTexture);
        else
            SetColor(data.color);
    }
}
