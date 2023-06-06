using System;
using UnityEngine;

[Serializable]
public class Registration {
	[SerializeField] private RegistrationView view;

	public event Action BackEvent, LoginEvent;
	
	public void Initialize() {
		view.BackEvent += OnBack;
		view.LoginEvent += OnLogin;
		view.ContinueEvent += OnRegistration;
	}
	public void Close() => view.Close();
	public void Open() => view.Open();

	private void OnBack() {
		BackEvent?.Invoke();
	}

	private void OnLogin() {
		LoginEvent?.Invoke();
	}
	
	private async void OnRegistration() {
	//var f= await	FireBaseAPI.TryRegister(view.login, view.password);
	}
}
