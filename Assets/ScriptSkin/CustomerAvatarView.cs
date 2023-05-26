using System;
using UnityEngine;
using UnityEngine.UI;

public class CustomerAvatarView : View {
    [SerializeField] private Button buttonBack;
    [SerializeField] private Button buttonDone;
    [SerializeField] private Toggle hair;
    [SerializeField] private Toggle skin;
    [SerializeField] private Toggle eyes;

    public event Action ButtonBackEvent ,ButtonDoneEvent;
    public event Action<bool> SelectHairEvent, SelectSkinEvent, SelectEyesEvent;

    public void Initialize() {
        buttonBack.onClick.AddListener(OnButtonBack);
        hair.onValueChanged.AddListener(OnSelectHair);
        skin.onValueChanged.AddListener(OnSelectSkin);
        eyes.onValueChanged.AddListener(OnSelectEyes);
        buttonDone.onClick.AddListener(OnButtonDone);
    }
    
    private void OnButtonBack() {
        ButtonBackEvent?.Invoke();
    }

    private void OnSelectHair(bool isOn) {
        if (!hair.isOn) return;
        SelectHairEvent?.Invoke(isOn);
    }

    private void OnSelectSkin(bool isOn) {
        if (!skin.isOn) return;
        SelectSkinEvent?.Invoke(isOn);
    }

    private void OnSelectEyes(bool isOn) {
        if (!eyes.isOn) return;
        SelectEyesEvent?.Invoke(isOn);
    }

    private void OnButtonDone() {
        ButtonDoneEvent?.Invoke();
    }
}


