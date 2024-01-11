using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameAlterAlter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gameEndTitleText;
    [SerializeField] private TextMeshProUGUI gameEndReturnText;
    [SerializeField] private TextMeshProUGUI gameEndScoresTitleText;
    [SerializeField] private TextMeshProUGUI gameEndScoresReturnText;

    private List<TextMeshProUGUI> textObjects = new List<TextMeshProUGUI>();
    private TMP_FontAsset japaneseFont;
    private TMP_FontAsset englishFont;
    private string langcode = "en";

    void Start()
    {
        japaneseFont = Resources.Load<TMP_FontAsset>("Font/mplus-1p-bold_SDF_Dynamic");
        englishFont = Resources.Load<TMP_FontAsset>("Font/yoster_SDF");
        langcode = PlayerPrefs.HasKey("Language") ? PlayerPrefs.GetString("Language") : "ja";
        AddObjectsToList();
        ReloadTranslations();
    }

    private void AddObjectsToList()
    {
        textObjects.Add(gameEndTitleText);
        textObjects.Add(gameEndReturnText);
        textObjects.Add(gameEndScoresTitleText);
        textObjects.Add(gameEndScoresReturnText);
    }

    private void SetFontAsset(string langcode)
    {
        switch (langcode)
        {
            case "en":
            default:
                foreach (TextMeshProUGUI textObject in textObjects)
                {
                    textObject.font = englishFont;
                }
                break;
            case "ja":
                foreach (TextMeshProUGUI textObject in textObjects)
                {
                    textObject.font = japaneseFont;
                }
                break;
        }
    }

    private void ReloadTranslations()
    {
        //langcode = PlayerPrefs.HasKey("Language") ? PlayerPrefs.GetString("Language") : "ja";
        SetFontAsset(langcode);
        switch(langcode)
        {
            case "en":
            default:
                gameEndTitleText.text = "Please enter your name";
                gameEndReturnText.text = "Next";
                gameEndScoresTitleText.text = "YOUR SCORE:";
                gameEndScoresReturnText.text = "Next";
                break;
            case "ja":
                // ToDo: translation
                gameEndTitleText.text = "Please enter your name";
                gameEndReturnText.text = "Next";
                gameEndScoresTitleText.text = "YOUR SCORE:";
                gameEndScoresReturnText.text = "Next";
                break;
        }
    }
}
