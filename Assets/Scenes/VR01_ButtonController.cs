using UnityEngine;
using UnityEngine.UI;

public class VR01_ButtonController : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private VR01_TextController _textController;
    private void Start()
    {
        _startButton.interactable = true;
        _startButton.onClick.AddListener(_textController.ChangeText);
    }
}
