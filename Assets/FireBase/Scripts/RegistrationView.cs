using TMPro;
using System;
using UnityEngine;
using UnityEngine.UI;

public class RegistrationView : View {
	[SerializeField] private Button buttonBack;
	[SerializeField] private TMP_InputField loginField;
	[SerializeField] private TMP_InputField passwordField;
	[SerializeField] private Button buttonLogin;
	[SerializeField] private Button buttonContinue;

	public string login => loginField.text;
	public string password => passwordField.text;
	
	public event Action BackEvent, LoginEvent,ContinueEvent; 

	private void Awake() {
		buttonBack.onClick.AddListener(OnBack);
		buttonLogin.onClick.AddListener(OnLogin);
		buttonContinue.onClick.AddListener(OnContinue);
	}

	private void OnBack() {
		BackEvent?.Invoke();
	}

	private void OnLogin() {
		LoginEvent?.Invoke();
	}
	private void OnContinue() {
		ContinueEvent?.Invoke();
	}

}
