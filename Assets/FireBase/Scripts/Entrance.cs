using UnityEngine;

public class Entrance : MonoBehaviour
{
	[SerializeField] private Account account;
	[SerializeField] private Registration registration;
	[SerializeField] private Login login;
	[SerializeField] private Recovery recovery;

	private void Awake() {
		account.Initialize();
		registration.Initialize();
		Subscription();
		account.Open();
	}

	private void OnEmail() { 
		account.Close();
		registration.Open();
	}
	private void OnGoogle() {
		account.Close();
		registration.Open();
	}
	
	private void OnBackRegistration() {
		registration.Close();
		account.Open();
	}
	
	private void Subscription() {
		account.EmailEvent += OnEmail;
		account.GoogleEvent += OnGoogle;

		registration.BackEvent += OnBackRegistration;
	}
	
}
