using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenuAlter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI menuStartText;
    [SerializeField] private TextMeshProUGUI menuOptionsText;
    [SerializeField] private TextMeshProUGUI menuScoresText;
    [SerializeField] private TextMeshProUGUI menuCreditText;
    [SerializeField] private TextMeshProUGUI menuExitText;
    [SerializeField] private TextMeshProUGUI optionsTitleText;
    [SerializeField] private TextMeshProUGUI optionsMouseText;
    [SerializeField] private TextMeshProUGUI optionsMusicText;
    [SerializeField] private TextMeshProUGUI optionsSoundText;
    [SerializeField] private TextMeshProUGUI optionsReturnText;
    [SerializeField] private TextMeshProUGUI scoresTitleText;
    [SerializeField] private TextMeshProUGUI scoresReturnText;
    [SerializeField] private TextMeshProUGUI creditsTitleText;
    [SerializeField] private TextMeshProUGUI creditsMain1Text;
    [SerializeField] private TextMeshProUGUI creditsMain2Text;
    [SerializeField] private TextMeshProUGUI creditsInstagramText;
    [SerializeField] private TextMeshProUGUI creditsGameText;
    [SerializeField] private TextMeshProUGUI creditsReturnText;
    private List<TextMeshProUGUI> textObjects = new List<TextMeshProUGUI>();
    private TMP_FontAsset japaneseFont;
    private TMP_FontAsset englishFont;
    private string langcode = "en";

    void Start()
    {
        TranslationTrigger.initiateTranslation += PrepareAndReloadTranslations;
        japaneseFont = Resources.Load<TMP_FontAsset>("Font/mplus-1p-bold_SDF_Dynamic");
        englishFont = Resources.Load<TMP_FontAsset>("Font/yoster_SDF");
        langcode =  PlayerPrefs.HasKey("Language") ? PlayerPrefs.GetString("Language") : "en";
        AddObjectsToList();
        ReloadTranslations();
    }

    private void AddObjectsToList()
    {
        textObjects.Add(menuStartText);
        textObjects.Add(menuOptionsText);
        textObjects.Add(menuScoresText);
        textObjects.Add(menuCreditText);
        textObjects.Add(menuExitText);
        textObjects.Add(optionsTitleText);
        textObjects.Add(optionsMouseText);
        textObjects.Add(optionsMusicText);
        textObjects.Add(optionsSoundText);
        textObjects.Add(optionsReturnText);
        textObjects.Add(scoresTitleText);
        textObjects.Add(scoresReturnText);
        textObjects.Add(creditsTitleText);
        textObjects.Add(creditsMain1Text);
        textObjects.Add(creditsMain2Text);
        textObjects.Add(creditsInstagramText);
        textObjects.Add(creditsGameText);
        textObjects.Add(creditsReturnText);
    }

    private void SetFontAsset(string langcode)
    {
        switch(langcode)
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
        langcode = PlayerPrefs.HasKey("Language") ? PlayerPrefs.GetString("Language") : "ja";
        SetFontAsset(langcode);
        switch(langcode)
        {
            case "en":
            default:
                menuStartText.fontSize = 24;
                menuStartText.text = "PLAY";
                menuOptionsText.fontSize = 24;
                menuOptionsText.text = "OPTIONS";
                menuScoresText.fontSize = 24;
                menuScoresText.text = "HIGH SCORES";
                menuCreditText.fontSize = 24;
                menuCreditText.text = "CREDITS";
                menuExitText.fontSize = 24;
                menuExitText.text = "EXIT";
                optionsTitleText.fontStyle = FontStyles.Bold;
                optionsTitleText.fontSize = 100;
                optionsTitleText.text = "OPTIONS";
                optionsMouseText.fontSize = 40;
                optionsMouseText.text = "mouse sensitivity";
                optionsMusicText.fontSize = 40;
                optionsMusicText.text = "music";
                optionsSoundText.fontSize = 40;
                optionsSoundText.text = "sound";
                optionsReturnText.fontSize = 24;
                optionsReturnText.text = "RETURN";
                scoresTitleText.fontStyle = FontStyles.Bold;
                scoresTitleText.fontSize = 100;
                scoresTitleText.text = "HIGH SCORES";
                scoresReturnText.fontSize = 24;
                scoresReturnText.text = "RETURN";
                creditsTitleText.fontStyle = FontStyles.Bold;
                creditsTitleText.fontSize = 100;
                creditsTitleText.text = "CREDITS";
                creditsMain1Text.fontSize = 32;
                creditsMain1Text.text = "This game was developed by gothSoft studio (well, it is actually only one developer) with the freelancers' support.\r\nWho is Tawako? \r\nShe is Valera's friend :)\r\n\r\nCheck this Instagram page to know more about them:";
                creditsMain2Text.fontSize = 32;
                creditsMain2Text.text = "You can also try our game about Valera:";
                creditsInstagramText.fontSize = 36;
                creditsInstagramText.text = "Valera's Instagram";
                creditsGameText.fontSize = 36;
                creditsGameText.text = "Valera's game";
                creditsReturnText.fontSize = 36;
                creditsReturnText.text = "RETURN";
                break;
            case "ja":
                menuStartText.fontSize = 22;
                menuStartText.text = "プレイ";
                menuOptionsText.fontSize = 22;
                menuOptionsText.text = "設定";
                menuScoresText.fontSize = 22;
                menuScoresText.text = "トップスコア";
                menuCreditText.fontSize = 22;
                menuCreditText.text = "クレジット";
                menuExitText.fontSize = 22;
                menuExitText.text = "終了";
                optionsTitleText.fontStyle = FontStyles.Normal;
                optionsTitleText.fontSize = 90;
                optionsTitleText.text = "設定";
                optionsMouseText.fontSize = 36;
                optionsMouseText.text = "マウスの感度";
                optionsMusicText.fontSize = 40;
                optionsMusicText.text = "BGM";
                optionsSoundText.fontSize = 36;
                optionsSoundText.text = "サウンド";
                optionsReturnText.fontSize = 22;
                optionsReturnText.text = "戻る";
                scoresTitleText.fontStyle = FontStyles.Normal;
                scoresTitleText.fontSize = 90;
                scoresTitleText.text = "トップスコア";
                scoresReturnText.fontSize = 22;
                scoresReturnText.text = "戻る";
                creditsTitleText.fontStyle = FontStyles.Normal;
                creditsTitleText.fontSize = 90;
                creditsTitleText.text = "クレジット";
                creditsMain1Text.fontSize = 32;
                creditsMain1Text.text = "このゲームは、gothSoft（開発者一人しかいないけど）がフリーランサーの力を借りて開発しました。\r\nたわこは誰かって？\r\nバレーラのお友達です^^\r\nたわこやバレーラについてはぜひInstagramでチェックしてください。";
                creditsMain2Text.fontSize = 32;
                creditsMain2Text.text = "バレーラのゲームもありますよ！";
                creditsInstagramText.fontSize = 36;
                creditsInstagramText.text = "バレーラのInstagram";
                creditsGameText.fontSize = 36;
                creditsGameText.text = "バレーラのゲーム";
                creditsReturnText.fontSize = 36;
                creditsReturnText.text = "戻る";
                break;
        }
    }

    private void PrepareAndReloadTranslations(string code)
    {
        langcode = code;
        ReloadTranslations();
    }

    private void OnDisable()
    {
        TranslationTrigger.initiateTranslation -= PrepareAndReloadTranslations;
    }
}
