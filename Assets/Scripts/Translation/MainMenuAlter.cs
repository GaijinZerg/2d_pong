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
                menuStartText.text = "�v���[";
                menuOptionsText.text = "�ݒ�";
                menuScoresText.text = "�g�b�v�X�R�A";
                menuCreditText.text = "�N���W�b�g";
                menuExitText.text = "�I��";
                optionsTitleText.text = "�ݒ�";
                optionsMouseText.text = "�}�E�X�̊��x";
                optionsMusicText.text = "BGM";
                optionsSoundText.text = "�T�E���h";
                optionsReturnText.text = "�߂�";
                scoresTitleText.text = "�g�b�v�X�R�A";
                scoresReturnText.text = "�߂�";
                creditsTitleText.text = "�N���W�b�g";
                creditsTitleText.fontSize = 86;
                creditsMain1Text.text = "���̃Q�[���́AgothSoft�i�J���҈�l�������Ȃ����ǁj���t���[�����T�[�̗͂��؂�ĊJ�����܂����B\r\n���킱�͒N�����āH\r\n�o���[���̂��F�B�ł�^^\r\n���킱��o���[���ɂ��Ă͂���Instagram�Ń`�F�b�N���Ă��������B";
                creditsMain2Text.text = "�o���[���̃Q�[��������܂���I";
                creditsInstagramText.text = "�o���[����Instagram";
                creditsGameText.text = "�o���[���̃Q�[��";
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
