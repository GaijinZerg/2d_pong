using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Provides general functions for game flow.
/// </summary>
public class General : MonoBehaviour
{
    [SerializeField] private GameObject _finishMenu, _nextLevelMenu, _player, _pauseMenu, _gameEndMenu;
    [SerializeField] private GameObject[] _levelsData;
    private PlayerController _playerController;
    private int _currentLevel = 0;

    void Start()
    {
        _playerController = _player.GetComponent<PlayerController>();
        Time.timeScale = 1;
        Cursor.visible = false;
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            PlayerPrefs.DeleteKey("Score");
        }
        if (SceneManager.GetActiveScene().name != "Level")
        {
            Cursor.visible = true;
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

    public static void ReturnToMenu()
    {
        PlayerPrefs.DeleteKey("Score");
        if (GameObject.FindGameObjectWithTag("Music") != null) 
            GameObject.FindGameObjectWithTag("Music").GetComponent<MusicController>().StopMusic();
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
    }

    public void GameEnd()
    {
        SceneManager.LoadScene("GameEnd");
    }

    public void SceneChanger()
    {
        if (GameObject.FindGameObjectsWithTag("Brick").Length == 0)
        {
            if (SceneManager.GetActiveScene().name == "Level")
            {
                Time.timeScale = 0;
                Cursor.visible = true;
                Destroy(GameObject.FindGameObjectWithTag("Ball"));
                if (_currentLevel != (_levelsData.Length - 1))
                {
                    _nextLevelMenu.SetActive(true);
                }
                else
                {
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
}
