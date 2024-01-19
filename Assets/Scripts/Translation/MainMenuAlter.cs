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
                menuStartText.text = "�v���C";
                menuOptionsText.fontSize = 22;
                menuOptionsText.text = "�ݒ�";
                menuScoresText.fontSize = 22;
                menuScoresText.text = "�g�b�v�X�R�A";
                menuCreditText.fontSize = 22;
                menuCreditText.text = "�N���W�b�g";
                menuExitText.fontSize = 22;
                menuExitText.text = "�I��";
                optionsTitleText.fontStyle = FontStyles.Normal;
                optionsTitleText.fontSize = 90;
                optionsTitleText.text = "�ݒ�";
                optionsMouseText.fontSize = 36;
                optionsMouseText.text = "�}�E�X�̊��x";
                optionsMusicText.fontSize = 40;
                optionsMusicText.text = "BGM";
                optionsSoundText.fontSize = 36;
                optionsSoundText.text = "�T�E���h";
                optionsReturnText.fontSize = 22;
                optionsReturnText.text = "�߂�";
                scoresTitleText.fontStyle = FontStyles.Normal;
                scoresTitleText.fontSize = 90;
                scoresTitleText.text = "�g�b�v�X�R�A";
                scoresReturnText.fontSize = 22;
                scoresReturnText.text = "�߂�";
                creditsTitleText.fontStyle = FontStyles.Normal;
                creditsTitleText.fontSize = 90;
                creditsTitleText.text = "�N���W�b�g";
                creditsMain1Text.fontSize = 32;
                creditsMain1Text.text = "���̃Q�[���́AgothSoft�i�J���҈�l�������Ȃ����ǁj���t���[�����T�[�̗͂��؂�ĊJ�����܂����B\r\n���킱�͒N�����āH\r\n�o���[���̂��F�B�ł�^^\r\n���킱��o���[���ɂ��Ă͂���Instagram�Ń`�F�b�N���Ă��������B";
                creditsMain2Text.fontSize = 32;
                creditsMain2Text.text = "�o���[���̃Q�[��������܂���I";
                creditsInstagramText.fontSize = 36;
                creditsInstagramText.text = "�o���[����Instagram";
                creditsGameText.fontSize = 36;
                creditsGameText.text = "�o���[���̃Q�[��";
                creditsReturnText.fontSize = 36;
                creditsReturnText.text = "�߂�";
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
