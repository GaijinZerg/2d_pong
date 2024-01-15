using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelAlter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI mainScoreText;
    [SerializeField] private TextMeshProUGUI mainLivesText;
    [SerializeField] private TextMeshProUGUI mainLevelText;
    [SerializeField] private TextMeshProUGUI mainBonus1Text;
    [SerializeField] private TextMeshProUGUI mainBonus2Text;
    [SerializeField] private TextMeshProUGUI mainBonus1ScoreText;
    [SerializeField] private TextMeshProUGUI mainBonus2ScoreText;
    [SerializeField] private TextMeshProUGUI gameOverDescriptionText;
    [SerializeField] private TextMeshProUGUI gameOverReturnText;
    [SerializeField] private TextMeshProUGUI pauseResumeText;
    [SerializeField] private TextMeshProUGUI pauseOptionsText;
    [SerializeField] private TextMeshProUGUI pauseExitText;
    [SerializeField] private TextMeshProUGUI optionsSensitivityText;
    [SerializeField] private TextMeshProUGUI optionsMusicText;
    [SerializeField] private TextMeshProUGUI optionsSoundText;
    [SerializeField] private TextMeshProUGUI optionsResumeText;
    [SerializeField] private TextMeshProUGUI nextLevelDescriptionText;
    [SerializeField] private TextMeshProUGUI nextLevelNextText;
    [SerializeField] private TextMeshProUGUI gameEndDescriptionText;
    [SerializeField] private TextMeshProUGUI gameEndNextText;

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
        textObjects.Add(mainScoreText);
        textObjects.Add(mainLivesText);
        textObjects.Add(mainLevelText);
        textObjects.Add(mainBonus1Text);
        textObjects.Add(mainBonus2Text);
        textObjects.Add(mainBonus1ScoreText);
        textObjects.Add(mainBonus2ScoreText);
        textObjects.Add(gameOverDescriptionText);
        textObjects.Add(gameOverReturnText);
        textObjects.Add(pauseResumeText);
        textObjects.Add(pauseOptionsText);
        textObjects.Add(pauseExitText);
        textObjects.Add(optionsSensitivityText);
        textObjects.Add(optionsMusicText);
        textObjects.Add(optionsSoundText);
        textObjects.Add(optionsResumeText);
        textObjects.Add(nextLevelDescriptionText);
        textObjects.Add(nextLevelNextText);
        textObjects.Add(gameEndDescriptionText);
        textObjects.Add(gameEndNextText);
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
                mainScoreText.text = "SCORE";
                mainLivesText.text = "LIVES";
                //mainLevelText.text = "LEVEL:";
                mainBonus1Text.text = "GET";
                mainBonus2Text.text = "GET";
                mainBonus1ScoreText.text = "30000 points";
                mainBonus2ScoreText.text = "40000 points";
                gameOverDescriptionText.text = "You have lost all your lives�c\r\nBut you can try again!";
                gameOverReturnText.text = "To main menu";
                pauseResumeText.text = "Resume";
                pauseOptionsText.text = "Options";
                pauseExitText.text = "Exit";
                optionsSensitivityText.text = "Sensitivity";
                optionsMusicText.text = "Music";
                optionsSoundText.text = "Sound";
                optionsResumeText.text = "Resume";
                nextLevelDescriptionText.text = "Congratulations!\r\nTry the next level!";
                nextLevelNextText.text = "Next";
                gameEndDescriptionText.text = "Congratulations!\r\nYou have completed all the levels!";
                gameEndNextText.text = "Next";
                break;
            case "ja":
                mainScoreText.text = "�X�R�A";
                mainLivesText.text = "�c��";
                //mainLevelText.text = "���x��:";
                mainBonus1Text.text = "30000 pt";
                mainBonus2Text.text = "40000 pt";
                mainBonus1ScoreText.text = "�l��";
                mainBonus2ScoreText.text = "�l��";
                gameOverDescriptionText.text = "�c�O�I\r\n�܂�����ĂˁI";
                gameOverReturnText.text = "���C�����j���[";
                pauseResumeText.text = "�Q�[���ɖ߂�";
                pauseOptionsText.text = "�ݒ�";
                pauseExitText.text = "���C�����j���[";
                optionsSensitivityText.text = "�}�E�X�̊��x";
                optionsMusicText.text = "BGM";
                optionsSoundText.text = "�T�E���h";
                optionsResumeText.text = "�Q�[���ɖ߂�";
                nextLevelDescriptionText.text = "���߂łƂ��I\r\n���̃��x���ɐi��łˁI";
                nextLevelNextText.text = "����";
                gameEndDescriptionText.text = "�������I\r\n���ׂẴ��x�����N���A�ł����ˁI";
                gameEndNextText.text = "����";
                break;
        }
    }
}
