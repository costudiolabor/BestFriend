using UnityEngine;
using Firebase.Database;

public class DB : MonoBehaviour
{
   private DatabaseReference dbRef;

   private void Awake()
   {
       dbRef = FirebaseDatabase.DefaultInstance.RootReference;
   }

   public void SaveData(string str)
   {
       dbRef.Child("users").SetValueAsync(str);
   }
   
}
