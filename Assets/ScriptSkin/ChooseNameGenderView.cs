using System;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;

public class ChooseNameGenderView : View {
    [SerializeField] private TMP_InputField name;
    [SerializeField] private Toggle male;
    [SerializeField] private Toggle trans;
    [SerializeField] private Toggle female;
    [SerializeField] private Button buttonDone;

    public event Action<Gender> ChooseAvatarEvent;
    public event Action<string> EndEditNameEvent;
    public event Action DoneEvent;

    public void Awake() {
        name.onEndEdit.AddListener(OnEndEditName);
        male.onValueChanged.AddListener(OnSelectMale);
        trans.onValueChanged.AddListener(OnSelectTrans);
        female.onValueChanged.AddListener(OnSelectFeMale);
        buttonDone.onClick.AddListener(OnButtonDone);
    }

    private void OnEndEditName(string name) {
        EndEditNameEvent?.Invoke(name);
    }
    
    private void OnSelectMale(bool isOn) {
        ChooseAvatarEvent?.Invoke(Gender.Male);
    }
    
    private void OnSelectTrans(bool isOn) {
        ChooseAvatarEvent?.Invoke(Gender.Trans);
    }
    
    private void OnSelectFeMale(bool isOn) {
        ChooseAvatarEvent?.Invoke(Gender.Female);
    }

    private void OnButtonDone() {
        DoneEvent?.Invoke();
    }
}

public enum Gender {
    Male,
    Trans,
    Female
}