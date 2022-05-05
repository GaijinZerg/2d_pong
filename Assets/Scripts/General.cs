using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Provides general functions for game flow.
/// </summary>
public class General : MonoBehaviour
{
    [SerializeField] private GameObject _finishMenu, _nextLevelMenu, _scoreText, _player, _pauseMenu;
    private PlayerController _playerController;

    void Start()
    {
        _playerController = _player.GetComponent<PlayerController>();
        Time.timeScale = 1;
        Cursor.visible = false;
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            PlayerPrefs.DeleteKey("Score");
            PlayerPrefs.DeleteKey("Lives");
        }
    }

    public static void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public static void ExitGame()
    {
        PlayerPrefs.DeleteKey("Score");
        PlayerPrefs.DeleteKey("Lives");
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
        PlayerPrefs.DeleteKey("Lives");
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

    public static void ReloadLevel()
    {
        PlayerPrefs.SetInt("Lives", 3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public static void StartNextLevel()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
        SceneManager.LoadScene("Level2");
    }

    public void SceneChanger(int[] data)
    {
        if (GameObject.FindGameObjectsWithTag("Brick").Length == 1)
        {
            if (SceneManager.GetActiveScene().name == "Level1")
            {
                PlayerPrefs.SetInt("Score", data[0]);
                PlayerPrefs.SetInt("Lives", data[1]);
                Time.timeScale = 0;
                Cursor.visible = true;
                _nextLevelMenu.SetActive(true);
            }
            else
            {
                Time.timeScale = 0;
                _playerController.gameOverFlag = true;
                Cursor.visible = true;
                _finishMenu.SetActive(true);
                _scoreText.GetComponent<TextMeshProUGUI>().text = data[0].ToString();
            }
        }
    }
}
