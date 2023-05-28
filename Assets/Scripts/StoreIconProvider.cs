using System.Collections.Generic;
using UnityEngine.Purchasing;
using UnityEngine;
using System;

public class StoreIconProvider {
   private static Dictionary<string, Texture2D> Icons { get; set; } = new();
   private static int _targetIconCount;
   public delegate void LoadCompleteAction();
   public static event LoadCompleteAction OnLoadComplete;

   public static void Initialize(ProductCollection products) {
      LoadIcons(products);
   }

   private static void LoadIcons(ProductCollection products) {
      if (Icons.Count == 0) {
         Debug.Log($"Loading store icons for {products.all.Length} products");
         _targetIconCount = products.all.Length;
         
         // загрузка икнок товаров !!!название icon должно совпадать с ID
         foreach (var product in products.all) {
            Debug.Log($"Loading store icon at path StoreIcons/ {product.definition.id}");
            var operation = Resources.LoadAsync<Texture2D>($"StoreIcons/{product.definition.id}");
            operation.completed += HandleLoadIcon;
         }
      }
      else {
         Debug.LogError($"StoreIconProvider has alredy been initialized!");
      }
   }
   
   public static Texture2D GetIcon(string id) {
      if (Icons.Count == 0) {
         Debug.LogError("Called StoreIconProvider.GetIcon before initializing!"+"This is not a supported operarion");
         throw new InvalidOperationException("StoreIconProvider.GetIcon() cannot be called before calling"+"StoreIconProvider.Initialize()");
      }
      else {
         Icons.TryGetValue(id, out var icon);
         return icon;
      }
   } 

   private static void HandleLoadIcon(AsyncOperation operation) {
      var request = operation as ResourceRequest;
      if (request.asset != null) {
         Debug.Log($"Successfully loaded {request.asset.name}");
         Icons.Add(request.asset.name, request.asset as  Texture2D);
         if (Icons.Count == _targetIconCount) {
            OnLoadComplete?.Invoke();
         }
      }
      else {
         // Subtract from total because something failed to load
         _targetIconCount--;
      }
   }
}
