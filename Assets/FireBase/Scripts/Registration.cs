using UnityEngine;

[System.Serializable]
public class Registration {
	[SerializeField] private RegistrationView view;

	public void Initialize() {
		view.ContinueEvent += OnRegistration;
	}
	
	public void Close() => view.Close();
	public void Open() => view.Open();
	
	private async void OnRegistration() {
	//var f= await	FireBaseAPI.TryRegister(view.login, view.password);
	}
}
