using UnityEngine;
using TMPro;

public class VR01_TextController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _messageText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _messageText.text = "Warning: <color=red><b> <size=150%>Enemy </size> Nearby!</b></color>";
    }

    public void ChangeText()
    {
        _messageText.text = "Button diklik!";
    }
}
