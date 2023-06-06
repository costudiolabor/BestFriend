using System;
using UnityEngine;

[Serializable]
public class Account {
    [SerializeField] private AccountView view;
    
    public event Action EmailEvent, GoogleEvent; 
    
    public void Initialize() {
        view.EmailEvent += OnEmail;
        view.GoogleEvent += OnGoogle;
    }
    public void Close() => view.Close();
    public void Open() => view.Open();
  
    private void OnEmail() {
        EmailEvent?.Invoke();
    }
    private void OnGoogle() {
        GoogleEvent?.Invoke();
    }
}
