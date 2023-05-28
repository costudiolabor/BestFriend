using Unity.Services.Core.Environments;
using Object = UnityEngine.Object;
using System.Threading.Tasks;
using UnityEngine.Purchasing;
using Unity.Services.Core;
using UnityEngine;
using System.Linq;
using System;

[Serializable]
public class Store: IStoreListener {
    [SerializeField] private StoreView prefabStoreView;
    [SerializeField] private Transform parentView;
    private StoreView _storeView;
    private static IStoreController _storeController;          // доступ к системе Unity Purchasing
    private static IExtensionProvider _extensionProvider;     // подсистема закупок для конкр магазинов

    public Action PurchaseCompletedEvent;
    public Action OpenStoreEvent, CloseStoreEvent;
    public Action<Product, ItemProduct.PurchaseDelegate> CreateItemEvent;
    public Action<int> DonePurchaseEvent;
    
    public async void Initialize() {
        CreateView();
        var options = new InitializationOptions()  // параметры инициализации
#if UNITY_EDITOR || development_build
            .SetEnvironmentName("test");  
#else
            .SetEnvironmentName("production");
#endif
        await UnityServices.InitializeAsync(options);
        var operation = Resources.LoadAsync<TextAsset>("IAPProductCatalog"); // загружаем асинхронно продукты
        operation.completed += HandleIAPCatalogLoaded;

        Subscription();
    }

    private void CreateView() {
        _storeView  = Object.Instantiate(prefabStoreView, parentView.transform);
        _storeView.Initialize();
    }

    public void OpenStore() {
        _storeView.Open();
    }

    public void CloseStore() {
        _storeView.Close();
    }
    
    private void Subscription() {
        OpenStoreEvent += OpenStore;
        CloseStoreEvent += CloseStore;
        CreateItemEvent += _storeView.CreateItem;
    }

    private void HandleIAPCatalogLoaded(AsyncOperation operation) {
        var request = operation as ResourceRequest;
        Debug.Log($"Loaded Asset: {request.asset}");
        var catalog = JsonUtility.FromJson<ProductCatalog>((request.asset as TextAsset).text);
        Debug.Log($"Loaded catalog with {catalog.allProducts.Count} items");
       
        StandardPurchasingModule.Instance().useFakeStoreUIMode = FakeStoreUIMode.StandardUser;  // Тестовый магазин 
        StandardPurchasingModule.Instance().useFakeStoreAlways = true;                          //  Unity
        
        // конструктор конфигураций
#if UNITY_ANDROID
        ConfigurationBuilder builder = ConfigurationBuilder.Instance(
             StandardPurchasingModule.Instance(AppStore.GooglePlay)
        );
#elif UNITY_IOS
        ConfigurationBuilder builder = ConfigurationBuilder.Instance(
             StandardPurchasingModule.Instance(AppStore.AppleAppSrore)
        );
#else
        var builder = ConfigurationBuilder.Instance(
            StandardPurchasingModule.Instance(AppStore.NotSpecified)
        );
#endif
        foreach (var item in catalog.allProducts) {
            builder.AddProduct(item.id, item.type);
        }
        UnityPurchasing.Initialize(this, builder); // инициализируем процесс покупки
    }
    
    //если процесс инициализации терпит неудачу
    public void OnInitializeFailed(InitializationFailureReason error) {
        Debug.Log($"Error initializing IAP because of {error}." +
                  $"\r\nShow a message to the player depending on the error.");
    }

    //если процесс инициализации терпит неудачу
    public void OnInitializeFailed(InitializationFailureReason error, string message) {
        throw new System.NotImplementedException();
    }

    // если процесс успешен и игрок приобрел покупку, сняли плату и
    // теперь нуно отдать предмет
    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs purchaseEvent) {
        string id = purchaseEvent.purchasedProduct.definition.id;
        Debug.Log($"Successfully purchased {id}");
        PurchaseCompletedEvent?.Invoke();
        PurchaseCompletedEvent = null;
        // здесь логика передачи товара игроку или разблокировки и сохранения
        DonePurchase(id);
        return PurchaseProcessingResult.Complete;
    }
    
    private void DonePurchase(string id) {
        var coins = id switch {
            "1Coin" => 1,
            "50Coins" => 50,
            "100Coins" => 100,
            _ => 0
        };
        DonePurchaseEvent?.Invoke(coins);
        Debug.Log($"Done Purchase!!! Coins: {coins}");
    }

    //если процесс покупки терпит неудачу
    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason) {
        Debug.Log($"FAILED to purchase {product.definition.id} because {failureReason}");
        PurchaseCompletedEvent?.Invoke();
        PurchaseCompletedEvent = null;
    }

    // если успешно инициализировался 
    public void OnInitialized(IStoreController controller, IExtensionProvider extensions) {
        _storeController = controller;
        _extensionProvider = extensions;
        StoreIconProvider.Initialize(_storeController.products);
        StoreIconProvider.OnLoadComplete += () => { HandleAllIconsLoaded();}
        ;
    }

    private async Task HandleAllIconsLoaded() {
        await CreateAllProducts();
    }
    
    private Task CreateAllProducts() {
        var sortedProducts = _storeController.products.all
            .OrderBy(item => item.metadata.localizedPrice)              // Сортируем по цене
            .ToList();
        foreach (var product in sortedProducts) {
            CreateItem(product);
        }
        return Task.CompletedTask;
    }
    
    private void CreateItem(Product product) {
        CreateItemEvent?.Invoke(product, HandlePurchase);
    }

    private void HandlePurchase(Product product, Action PurchaseCompletedEvent) {
        this.PurchaseCompletedEvent = PurchaseCompletedEvent;
        _storeController.InitiatePurchase(product);
    }

   
}
