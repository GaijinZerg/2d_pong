using Steamworks;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Provides general functions for game flow.
/// </summary>
public class General : MonoBehaviour
{
    [SerializeField] private GameObject _finishMenu, _nextLevelMenu, _player, _pauseMenu, _gameEndMenu,
        _nameInputMenu, _gameScoresMenu, _mainMenu, _highScoresMenu, _background, _nextLevel;
    [SerializeField] private GameObject _levelTextObject;
    [SerializeField] private GameObject[] _levelsData;
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private AudioClip[] _audioClips;
    private TextMeshProUGUI levelText, nextLevelText;
    private AudioSource _audioSource;
    private SpriteRenderer _renderer;
    private PlayerController _playerController;
    private int currentLevel = 0;
    private bool isSecretLevel = false;
    private TMP_FontAsset japaneseFont;
    private TMP_FontAsset englishFont;
    public bool lockUI = false;
    public GameObject optionsMenu;

    void Start()
    {
        if (!PlayerPrefs.HasKey("Music"))
        {
            PlayerPrefs.SetFloat("Music", 0.5f);
        }
        if (_levelTextObject.GetComponent<TextMeshProUGUI>() != null)
        {
            levelText = _levelTextObject.GetComponent<TextMeshProUGUI>();
            levelText.text = "LEVEL: 1";
        }
        _audioSource = gameObject.GetComponent<AudioSource>();
        _playerController = _player.GetComponent<PlayerController>();
        _renderer = _background.GetComponent<SpriteRenderer>();
        nextLevelText = _nextLevel.GetComponent<TextMeshProUGUI>();
        Time.timeScale = 1;
        Cursor.visible = false;
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            PlayerPrefs.DeleteKey("Score");
            if (PlayerPrefs.HasKey("SceneMode"))
            {
                if (PlayerPrefs.GetInt("SceneMode") == 1)
                {
                    _mainMenu.SetActive(false);
                    _highScoresMenu.SetActive(true);
                    PlayerPrefs.SetInt("SceneMode", 0);
                }
            }
        }
        if (SceneManager.GetActiveScene().name != "Level")
        {
            Cursor.visible = true;
        }
        if (SceneManager.GetActiveScene().name == "GameEnd")
        {
            List<string> scoresList = CSVManager.ReadCSV();

            List<int> scoresSort = new List<int>();
            for (int i = 1; i < scoresList.Count; i++)
            {
                scoresSort.Add(int.Parse(scoresList[i].Split(";")[1]));
            }
            scoresSort.Sort();
            scoresSort.Reverse();

            if (PlayerPrefs.GetInt("Score") > scoresSort[4])
            {
                if (SteamManager.Initialized && (PlayerPrefs.GetInt("Score") > scoresSort.Max()))
                {
                    SteamUserStats.SetAchievement("TOP_SCORE");
                    SteamUserStats.StoreStats();
                }
                _nameInputMenu.SetActive(true);
                _gameScoresMenu.SetActive(false);
            }
            else
            {
                _nameInputMenu.SetActive(false);
                _gameScoresMenu.SetActive(true);
            }
        }
    }

    public static void StartGame()
    {
        SceneManager.LoadScene("Level");
    }

    public static void ExitGame()
    {
        PlayerPrefs.DeleteKey("Score");
        Application.Quit();
    }

    public void PauseGame()
    {
        if (!_playerController.gameOverFlag)
        {
            Cursor.visible = true;
            Time.timeScale = 0;
            _pauseMenu.SetActive(true);
        }
    }

    public static void ReturnToMenu(int mode)
    {
        PlayerPrefs.SetInt("SceneMode", mode);
        PlayerPrefs.DeleteKey("Score");
        SceneManager.LoadScene("MainMenu");
    }

    public void BackToGame()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
        _pauseMenu.SetActive(false);
    }

    public void StartNextLevel()
    {
        lockUI = false;
        Time.timeScale = 1;
        Cursor.visible = false;
        _nextLevelMenu.SetActive(false);
        _playerController.GameEndController();
        _levelsData[currentLevel].SetActive(false);
        _levelsData[currentLevel + 1].SetActive(true);
        currentLevel++;
        _renderer.sprite = _sprites[currentLevel / 3];
        levelText.text = "LEVEL: " + (currentLevel + 1).ToString();
    }

    public void GameEnd()
    {
        SceneManager.LoadScene("GameEnd");
    }

    public void SceneChanger()
    {
        _audioSource.volume = PlayerPrefs.HasKey("Sound") ? PlayerPrefs.GetFloat("Sound") : 1;
        if ((GameObject.FindGameObjectsWithTag("Brick").Length == 0) && (GameObject.FindGameObjectsWithTag("Bonus").Length == 0))
        {
            lockUI = true;
            if (SceneManager.GetActiveScene().name == "Level")
            {
                Time.timeScale = 0;
                Cursor.visible = true;
                Destroy(GameObject.FindGameObjectWithTag("Ball"));
                if (currentLevel < (_levelsData.Length - 2))
                {
                    _audioSource.clip = _audioClips[0];
                    _audioSource.Play();
                    _nextLevelMenu.SetActive(true);
                }
                else if ((currentLevel == (_levelsData.Length - 2)) && isSecretLevel)
                {
                    _audioSource.clip = _audioClips[0];
                    _audioSource.Play();
                    _nextLevelMenu.SetActive(true);
                    if (PlayerPrefs.GetString("Language") == "ja")
                    {
                        japaneseFont = Resources.Load<TMP_FontAsset>("Font/mplus-1p-bold_SDF_Dynamic");
                        nextLevelText.font = japaneseFont;
                        nextLevelText.text = "おめでとう！\nシークレットレベルが見つかりました！";
                    }
                    else
                    {
                        englishFont = Resources.Load<TMP_FontAsset>("Font/yoster_SDF");
                        nextLevelText.font = englishFont;
                        nextLevelText.text = "Congratulations!\nYou have unlocked the secret level!";
                    }
                }
                else if ((currentLevel == (_levelsData.Length - 1)) && isSecretLevel)
                {
                    if (SteamManager.Initialized)
                    {
                        SteamUserStats.SetAchievement("GAME_COMPLETED");
                        SteamUserStats.StoreStats();
                    }
                    _audioSource.clip = _audioClips[1];
                    _audioSource.Play();
                    _gameEndMenu.SetActive(true);
                }
                else
                {
                    _audioSource.clip = _audioClips[1];
                    _audioSource.Play();
                    _gameEndMenu.SetActive(true);
                }
            }
            else
            {
                Time.timeScale = 0;
                _playerController.gameOverFlag = true;
                Cursor.visible = true;
                _finishMenu.SetActive(true);
            }
        }
    }

    public void SetSecretLevel()
    {
        isSecretLevel = true;
    }

    public void ButtonClickSound()
    {
        _audioSource.volume = PlayerPrefs.HasKey("Sound") ? PlayerPrefs.GetFloat("Sound") : 1;
        _audioSource.clip = _audioClips[2];
        _audioSource.Play();
    }
}
