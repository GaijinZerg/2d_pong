using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameEndAlter : MonoBehaviour
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
        langcode = PlayerPrefs.HasKey("Language") ? PlayerPrefs.GetString("Language") : "en";
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
        SetFontAsset(langcode);
        switch(langcode)
        {
            case "en":
            default:
                gameEndTitleText.fontSize = 60;
                gameEndReturnText.fontSize = 24;
                gameEndScoresTitleText.fontSize = 100;
                gameEndScoresReturnText.fontSize = 24;
                gameEndTitleText.text = "Please enter your name";
                gameEndReturnText.text = "Next";
                gameEndScoresTitleText.text = "YOUR SCORE";
                gameEndScoresReturnText.text = "Next";
                break;
            case "ja":
                gameEndTitleText.fontSize = 60;
                gameEndReturnText.fontSize = 24;
                gameEndScoresTitleText.fontSize = 100;
                gameEndScoresReturnText.fontSize = 24;
                gameEndTitleText.text = "–¼‘O‚ð“ü—Í‚µ‚Ä‚­‚¾‚³‚¢";
                gameEndReturnText.text = "ŽŸ‚Ö";
                gameEndScoresTitleText.font = englishFont;
                gameEndScoresTitleText.text = "YOUR SCORE";
                gameEndScoresReturnText.text = "ŽŸ‚Ö";
                break;
        }
    }
}
