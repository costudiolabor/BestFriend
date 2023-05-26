using UnityEngine;

public class MainEntry : MonoBehaviour {
    [SerializeField] private CameraHandler cameraHandler = new CameraHandler();
    [SerializeField] private SettingAvatar settingAvatar;
    
    private void Awake() {
        cameraHandler.Initialize();
        settingAvatar.Initialize();
        settingAvatar.DoneGenderEvent += cameraHandler.SetPointCustomerCamera;
        settingAvatar.DoneCustomerEvent += cameraHandler.SetPointMainCamera;
    }
}
