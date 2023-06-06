using TMPro;
using System;
using UnityEngine;
using UnityEngine.UI;

public class RecoveryView : MonoBehaviour {
    [SerializeField] private Button buttonBack;
    [SerializeField] private TMP_InputField loginField;
    [SerializeField] private Button buttonContinue;
    
    public event Action BackEvent, ContinueEvent; 

    private void Awake() {
        buttonBack.onClick.AddListener(OnBack);
        buttonContinue.onClick.AddListener(OnContinue);
    }

    private void OnBack() {
        BackEvent?.Invoke();
    }
    
    private void OnContinue() {
        ContinueEvent?.Invoke();
    }
}
