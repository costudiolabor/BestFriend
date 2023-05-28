using UnityEngine.Purchasing;
using UnityEngine.UI;
using UnityEngine;
using System;
using TMPro;

public class ItemProduct : MonoBehaviour {
   [SerializeField] private TextMeshProUGUI nameText;
   [SerializeField] private TextMeshProUGUI descriptionText;
   [SerializeField] private Image icon;
   [SerializeField] private TextMeshProUGUI priceText;
   [SerializeField] private Button purchaseButton;

   public delegate void PurchaseDelegate(Product model, Action onComplete);
   public event PurchaseDelegate PurchaseEvent;
   
   private Product _model;
   
   public void Initialize(Product product) {
      _model = product;
      SetText(product);
      SetTexture(product);
      purchaseButton.onClick.AddListener(Purchase);
   }

   private void SetText(Product product) {
       nameText.SetText(product.metadata.localizedTitle);
       descriptionText.SetText(product.metadata.localizedDescription);
       priceText.SetText($"{product.metadata.localizedPriceString} "+ $"{product.metadata.isoCurrencyCode}");
   }

   private void SetTexture(Product product) {
       var texture = StoreIconProvider.GetIcon(product.definition.id);
       if (texture != null) {
           CreateSprite(texture);
       }
       else {
           Debug.Log($"No Sprite found for {product.definition.id}");
       }
   }

   private void CreateSprite(Texture2D texture) {
       var sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.one / 2f);
       icon.sprite = sprite;
   }

   private void Purchase() {
       purchaseButton.enabled = false;
       PurchaseEvent?.Invoke(_model, HandlePurchaseComplete);
   }

   private void HandlePurchaseComplete() {
       purchaseButton.enabled = true;
   }
}
