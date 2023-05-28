using UnityEngine;
using UnityEngine.UI;

public class Entry : MonoBehaviour {
   [SerializeField] private Store _store;
   [SerializeField] private Button openButton; 
   [SerializeField] private Button closeButton;
   [SerializeField] private Text textCoins;

   private int coins; 
   
   private void Awake() {
       _store.Initialize();
       
       _store.OpenStoreEvent?.Invoke();
       _store.DonePurchaseEvent += SetCoins;
       openButton.onClick.AddListener(() => {_store.OpenStoreEvent?.Invoke();});
       closeButton.onClick.AddListener(() => {_store.CloseStoreEvent?.Invoke();});
       SetCoins(0);
   }

   private void SetCoins(int coins) {
       this.coins += coins;
       textCoins.text = this.coins.ToString();
   }
}
