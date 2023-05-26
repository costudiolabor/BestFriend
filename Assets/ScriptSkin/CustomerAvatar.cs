using System;
using UnityEngine;

[Serializable]
public class CustomerAvatar {
   [SerializeField] private CustomerAvatarView view;
   [SerializeField] private Gallery gallery;
   [SerializeField] private GalleryColor galleryColor;
   
   public event Action ButtonBackEvent, ButtonDoneEvent;
   public event Action<int> SetHairEvent, SetColHairEvent, SetSkinEvent, SetColEyes;

   private SettingsModel _settingsModel;
   private TypeItem _currentTypeItem;

   public void Initialize() {
      view.Initialize();
      view.SelectHairEvent += OnSelectHair;
      view.SelectSkinEvent += OnSelectSkin;
      view.SelectEyesEvent += OnSelectEyes;
      view.ButtonBackEvent += OnBack;
      view.ButtonDoneEvent += OnDone;
      gallery.ClickItemEvent += OnClickItem;
      galleryColor.ClickItemEvent += OnClickItemCol;
   }

   public void SetSettingModel(SettingsModel settingsModel) {
      this._settingsModel = settingsModel;
   }
   
   public void OpenView() {
      view.Open();
   }

   public void CloseView() {
      view.Close();
   }

   private void OnBack() {
      ButtonBackEvent?.Invoke();
   }

   private void OnDone() {
      ButtonDoneEvent?.Invoke();
   }
   
   private void OnSelectHair(bool isOn) {
      gallery.SetActive(isOn);
      galleryColor.SetActive(isOn);
      gallery.SetContent(_settingsModel.GetItemHairs(), true);
      galleryColor.SetContent(_settingsModel.GetColHair(), false);
      _currentTypeItem = TypeItem.Hair;
   }
    
   private void OnSelectSkin(bool isOn) {
      gallery.SetActive(!isOn);
      galleryColor.SetActive(isOn);
      galleryColor.SetContent(_settingsModel.GetColSkins(), false);
      _currentTypeItem = TypeItem.Skin;
   }
    
   private void OnSelectEyes(bool isOn) {
      gallery.SetActive(!isOn);
      galleryColor.SetActive(isOn);
      galleryColor.SetContent(_settingsModel.GetColEyes(), true);
      _currentTypeItem = TypeItem.Eyes;
   }

   private void OnClickItem(int index) {
      //Debug.Log(index);
      switch (_currentTypeItem) {
         case TypeItem.Hair:
            SetHairEvent?.Invoke(index);
            break;
      }
   }

   private void OnClickItemCol(int index) {
      //Debug.Log(index);
      switch (_currentTypeItem) {
         case TypeItem.Hair:
            SetColHairEvent?.Invoke(index);
            break;
         case TypeItem.Skin:
            SetSkinEvent?.Invoke(index);
            break;
         case TypeItem.Eyes:
            SetColEyes?.Invoke(index);
            break;
      }
   }
}
