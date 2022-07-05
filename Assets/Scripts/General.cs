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
    private TextMeshProUGUI _levelText, _nextLevelText;
    private AudioSource _audioSource;
    private SpriteRenderer _renderer;
    private PlayerController _playerController;
    private int _currentLevel = 0;
    private bool _isSecretLevel = false;
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
            _levelText = _levelTextObject.GetComponent<TextMeshProUGUI>();
            _levelText.text = "LEVEL: 1";
        }
        _audioSource = gameObject.GetComponent<AudioSource>();
        _playerController = _player.GetComponent<PlayerController>();
        _renderer = _background.GetComponent<SpriteRenderer>();
        _nextLevelText = _nextLevel.GetComponent<TextMeshProUGUI>();
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
        _levelsData[_currentLevel].SetActive(false);
        _levelsData[_currentLevel + 1].SetActive(true);
        _currentLevel++;
        _renderer.sprite = _sprites[_currentLevel / 3];
        _levelText.text = "LEVEL: " + (_currentLevel + 1).ToString();
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
                if (_currentLevel < (_levelsData.Length - 2))
                {
                    _audioSource.clip = _audioClips[0];
                    _audioSource.Play();
                    _nextLevelMenu.SetActive(true);
                }
                else if ((_currentLevel == (_levelsData.Length - 2)) && _isSecretLevel)
                {
                    _audioSource.clip = _audioClips[0];
                    _audioSource.Play();
                    _nextLevelMenu.SetActive(true);
                    _nextLevelText.text = "Congratulations!\nYou have unlocked the secret level!";
                }
                else if ((_currentLevel == (_levelsData.Length - 1)) && _isSecretLevel)
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
        _isSecretLevel = true;
    }

    public void ButtonClickSound()
    {
        _audioSource.volume = PlayerPrefs.HasKey("Sound") ? PlayerPrefs.GetFloat("Sound") : 1;
        _audioSource.clip = _audioClips[2];
        _audioSource.Play();
    }
}
