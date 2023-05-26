using System;
using TMPro;
using UnityEngine;

public class Message : MonoBehaviour
{
    [SerializeField] private TMP_Text senderText, contentText, timeText;
 
    public void Set(string sender, string content, double time) {
        senderText.text = sender;
        contentText.text = content;
        timeText.text = UnixTimeStampToDateTime(time).ToShortTimeString();
    }

    private static DateTime UnixTimeStampToDateTime(double unixTimeStamp) {
        DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        return dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
    }
}
