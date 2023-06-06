using TMPro;
using System;
using UnityEngine;
using UnityEngine.UI;

public class LoginView : MonoBehaviour {
    [SerializeField] private Button buttonBack;
    [SerializeField] private TMP_InputField loginField;
    [SerializeField] private TMP_InputField passwordField;
    [SerializeField] private Button buttonForgot;
    [SerializeField] private Button buttonCreate;
    [SerializeField] private Button buttonContinue;
    
    public event Action BackEvent, ForgotEvent, CreateEvent, ContinueEvent; 

    private void Awake() {
        buttonBack.onClick.AddListener(OnBack);
        buttonForgot.onClick.AddListener(OnForgot);
        buttonCreate.onClick.AddListener(OnCreate);
        buttonContinue.onClick.AddListener(OnContinue);
    }

    private void OnBack() {
        BackEvent?.Invoke();
    }

    private void OnForgot() {
        ForgotEvent?.Invoke();
    }
    
    private void OnCreate() {
        CreateEvent?.Invoke();
    }
    private void OnContinue() {
        ContinueEvent?.Invoke();
    }
    
}
