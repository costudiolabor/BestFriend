using System;
using UnityEngine;
using UnityEngine.UI;

public class AccountView : View {
    [SerializeField] private Button buttonEmail;
    [SerializeField] private Button buttonGoogle;

    public event Action EmailEvent, GoogleEvent; 
    
    private void Awake() {
        buttonEmail.onClick.AddListener(OnEmail);
        buttonGoogle.onClick.AddListener(OnGoogle);
    }
    private void OnEmail() =>
        EmailEvent?.Invoke();
    
    private void OnGoogle() =>
        GoogleEvent?.Invoke();

    
    
}
