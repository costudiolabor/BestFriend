using Firebase;
using Firebase.Auth;
using UnityEngine;

public class ConnectionFirebase : MonoBehaviour {
	public static FirebaseAuth authorizationPlayer;
	public static FirebaseUser firebaseUser;

	private void Awake() {
		FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
			DependencyStatus dependencyStatus = task.Result;

			if (dependencyStatus == DependencyStatus.Available)
				authorizationPlayer = FirebaseAuth.DefaultInstance;
			else
				Debug.Log(dependencyStatus);
			
		});
	}
}