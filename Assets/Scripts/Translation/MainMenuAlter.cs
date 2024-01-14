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
        langcode =  PlayerPrefs.HasKey("Language") ? PlayerPrefs.GetString("Language") : "ja";
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
                menuStartText.text = "PLAY";
                menuOptionsText.text = "OPTIONS";
                menuScoresText.text = "HIGH SCORES";
                menuCreditText.text = "CREDITS";
                menuExitText.text = "EXIT";
                optionsTitleText.text = "OPTIONS";
                optionsMouseText.text = "mouse sensitivity";
                optionsMusicText.text = "music";
                optionsSoundText.text = "sound";
                optionsReturnText.text = "RETURN";
                scoresTitleText.text = "HIGH SCORES";
                scoresReturnText.text = "RETURN";
                creditsTitleText.text = "CREDITS";
                creditsMain1Text.text = "This game was developed by gothSoft studio (well, it is actually only one developer) with the freelancers' support.\r\nWho is Tawako? \r\nShe is Valera's friend :)\r\n\r\nCheck this Instagram page to know more about them:";
                creditsMain2Text.text = "You can also try our game about Valera:";
                creditsInstagramText.text = "Valera's Instagram";
                creditsGameText.text = "Valera's game";
                creditsReturnText.text = "RETURN";
                break;
            case "ja":
                menuStartText.text = "プレー";
                menuOptionsText.text = "設定";
                menuScoresText.text = "トップスコア";
                menuCreditText.text = "クレジット";
                menuExitText.text = "終了";
                optionsTitleText.text = "設定";
                optionsMouseText.text = "マウスの感度";
                optionsMusicText.text = "BGM";
                optionsSoundText.text = "サウンド";
                optionsReturnText.text = "戻る";
                scoresTitleText.text = "トップスコア";
                scoresReturnText.text = "戻る";
                creditsTitleText.text = "クレジット";
                creditsTitleText.fontSize = 86;
                creditsMain1Text.text = "このゲームは、gothSoft（開発者一人しかいないけど）がフリーランサーの力を借りて開発しました。\r\nたわこは誰かって？\r\nバレーラのお友達です^^\r\nたわこやバレーラについてはぜひInstagramでチェックしてください。";
                creditsMain2Text.text = "バレーラのゲームもありますよ！";
                creditsInstagramText.text = "バレーラのInstagram";
                creditsGameText.text = "バレーラのゲーム";
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
