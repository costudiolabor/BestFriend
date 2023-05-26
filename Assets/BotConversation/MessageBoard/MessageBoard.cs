using UnityEngine;
using System;

public class MessageBoard : MonoBehaviour
{
   [SerializeField] private Message userMessagePrefab, companionMessagePrefab;
   [SerializeField] private RectTransform messageParent;

   public void CreateUserMessage(string sender, string message) {
	   var userMessage = Instantiate(userMessagePrefab, messageParent);
	   
	   userMessage.Set(sender, message,(DateTimeOffset.Now.ToUnixTimeSeconds()));
   }

   public void CreateCompanionMessage(string sender, string message) {
	   var companionMessage = Instantiate(companionMessagePrefab, messageParent);
	   
	   companionMessage.Set(sender, message, DateTimeOffset.Now.ToUnixTimeSeconds());
   }

}
