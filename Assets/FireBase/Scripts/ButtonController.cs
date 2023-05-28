using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private InputField _inputField;
    private DB db;
    private void Start()
    {
        db = GetComponent<DB>();
    }


    public void ClickButton()
    {
        db.SaveData(_inputField.text); 
    }
}
