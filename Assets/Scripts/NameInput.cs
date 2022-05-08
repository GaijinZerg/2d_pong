using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NameInput : MonoBehaviour
{
    [SerializeField] private GameObject inputTextObject, nextButton;
    private TextMeshProUGUI _inputText;

    void Start()
    {
        _inputText = inputTextObject.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (_inputText.text.Length > 1)
        {
            nextButton.GetComponent<Button>().interactable = true;
        }
        else
        {
            nextButton.GetComponent<Button>().interactable = false;
        }
    }

    public void SaveScore()
    {
        CSVManager.AddLineToCSV(_inputText.text, PlayerPrefs.GetInt("Score"));
    }
}
