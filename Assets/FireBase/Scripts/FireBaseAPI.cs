using System.Threading.Tasks;
using Firebase.Auth;

public static class FireBaseAPI
{
	public static async Task<AuthResult> TryRegister(string email, string password) {
		return await ConnectionFirebase.authorizationPlayer.CreateUserWithEmailAndPasswordAsync(email, password);
	}
}

