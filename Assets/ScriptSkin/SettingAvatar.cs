using System;
using UnityEngine;
using Object = UnityEngine.GameObject;

[Serializable]
public class SettingAvatar {
    [SerializeField] private SettingAvatarView settingAvatarView;
    [SerializeField] private SettingsModel settingFemale;
    [SerializeField] private SettingsModel settingsMale;
    [SerializeField] private HandlerAvatar prefabFemale; 
    [SerializeField] private HandlerAvatar prefabMale; 
    [SerializeField] private Transform spawnAvatar;
    [SerializeField] private ChooseNameGender chooseNameGender;
    [SerializeField] private CustomerAvatar customerAvatar;
    [SerializeField] private int stepRotate = 5;
    public event Action DoneGenderEvent, DoneCustomerEvent;

    private string _nameAvatar;
    private HandlerAvatar _currentAvatar;
    private SettingsModel _currentSettingModel;

    public void Initialize() {
        settingAvatarView.DragEvent += RotateAvatar;
        
        chooseNameGender.Initialize();
        chooseNameGender.ChooseAvatarEvent += ChooseAvatar;
        chooseNameGender.EndEditNameEvent += SetName;
        chooseNameGender.DoneEvent += DoneGender;
        
        customerAvatar.Initialize();
        customerAvatar.ButtonBackEvent += BackCustomer; 
        customerAvatar.ButtonDoneEvent += DoneCustomer;

        customerAvatar.SetHairEvent += SetHair;
        customerAvatar.SetColHairEvent += SetColHair;
        customerAvatar.SetSkinEvent += SetColSkin;
        customerAvatar.SetColEyes += SetColEyes;
        
        ChooseAvatar(Gender.Male);
    }

    private void RotateAvatar(Vector2 delta) {
        var rotateY = -delta.x / stepRotate;
        _currentAvatar.transform.Rotate(0.0f, rotateY,0.0f);
    }
    
    private void ChooseAvatar(Gender gender) {
        HandlerAvatar currentPrefab = null;
        switch (gender) {
            case Gender.Male:
                currentPrefab = prefabMale;
                _currentSettingModel = settingsMale;
                break;

            case Gender.Trans:
                currentPrefab = prefabFemale;
                _currentSettingModel = settingFemale;
                break;
            
            case Gender.Female:
                currentPrefab = prefabFemale;
                _currentSettingModel = settingFemale;
                break;
        }
        CreateAvatar(currentPrefab);
    }

    private void SetName(string name) {
        _nameAvatar = name;
    }

    private void DoneGender() {
        DoneGenderEvent?.Invoke();
        chooseNameGender.CloseView();
        customerAvatar.OpenView();
        customerAvatar.SetSettingModel(_currentSettingModel);
    }

    private void CreateAvatar(HandlerAvatar avatar) {
        CheckAvatar();
        _currentAvatar = Object.Instantiate(avatar, spawnAvatar);
    }

    public void SetHair(int index) {
        var itemHairs = _currentSettingModel.GetItemHairs();
        var mesh = itemHairs[index].mesh;
        _currentAvatar.SetHair(mesh);
    }
    
    public void SetColHair(int index) {
        var materials = _currentSettingModel.GetColHair();
        var material = materials[index];
        _currentAvatar.SetColHair(material);
    }
    
    public void SetColSkin(int index) {
        var material = _currentSettingModel.GetColSkins()[index];
        _currentAvatar.SetColSkin(material);
    } 
    
    public void SetColEyes(int index) {
        var material = _currentSettingModel.GetColEyes()[index];
        _currentAvatar.SetColEyes(material);
    }
    
    private void CheckAvatar() {
        if (_currentAvatar == null) return;
        Object.Destroy(_currentAvatar.gameObject); 
    }

    private void DoneCustomer() {
        DoneCustomerEvent?.Invoke();
        customerAvatar.CloseView();
    }

    private void BackCustomer() {
        DoneCustomerEvent?.Invoke();
        customerAvatar.CloseView();
        chooseNameGender.OpenView();
    }
}
