using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Provides general functions for game flow.
/// </summary>
public class General : MonoBehaviour
{
    [SerializeField] private GameObject _finishMenu, _nextLevelMenu, _player, _pauseMenu, _gameEndMenu, _nameInputMenu, _gameScoresMenu, _mainMenu, _highScoresMenu, _background;
    [SerializeField] private GameObject[] _levelsData;
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private AudioClip[] _audioClips;
    private AudioSource _audioSource;
    private SpriteRenderer _renderer;
    private PlayerController _playerController;
    private int _currentLevel = 0;
    private bool _isSecretLevel = false;

    void Start()
    {
        _audioSource = gameObject.GetComponent<AudioSource>();
        _playerController = _player.GetComponent<PlayerController>();
        _renderer = _background.GetComponent<SpriteRenderer>();
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
        // ToDo: add announce for the secret level.
        if (_currentLevel == (_levelsData.Length - 1))
        {
            _gameEndMenu.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            Cursor.visible = false;
            _nextLevelMenu.SetActive(false);
            _playerController.GameEndController();
            _levelsData[_currentLevel].SetActive(false);
            _levelsData[_currentLevel + 1].SetActive(true);
            _currentLevel++;
        }
        _renderer.sprite = _sprites[_currentLevel / 3];
    }

    public void GameEnd()
    {
        SceneManager.LoadScene("GameEnd");
    }

    public void SceneChanger()
    {
        _audioSource.volume = PlayerPrefs.HasKey("Sound") ? PlayerPrefs.GetFloat("Sound") : 1;
        if (GameObject.FindGameObjectsWithTag("Brick").Length == 0)
        {
            if (SceneManager.GetActiveScene().name == "Level")
            {
                Time.timeScale = 0;
                Cursor.visible = true;
                Destroy(GameObject.FindGameObjectWithTag("Ball"));
                if (_currentLevel < (_levelsData.Length - 2))
                {
                    // ToDo: check this. Is it a correct place to play sound?
                    // ToDo: add defeat sound into PlayerController::GameEndController.
                    _audioSource.clip = _audioClips[0];
                    _audioSource.Play();
                    _nextLevelMenu.SetActive(true);
                }
                else if ((_currentLevel == (_levelsData.Length - 2)) && _isSecretLevel)
                {
                    _audioSource.clip = _audioClips[0];
                    _audioSource.Play();
                    _nextLevelMenu.SetActive(true);
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
