using UnityEngine.Purchasing;
using UnityEngine.UI;
using UnityEngine;

public class StoreView : View {
    [SerializeField] private HorizontalLayoutGroup contentPanel;
    [SerializeField] private ItemProduct itemProductPrefab;
    
    public void Initialize() {
        Close();
    }
    
    public void CreateItem(Product product, ItemProduct.PurchaseDelegate purchaseEvent) {
        var itemProduct = Instantiate(itemProductPrefab, contentPanel.transform, false);
        itemProduct.Initialize(product);
        itemProduct.PurchaseEvent += purchaseEvent;
    }
}
