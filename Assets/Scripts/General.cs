using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class General : MonoBehaviour
{
    [SerializeField] private GameObject finishMenu, nextLevelMenu, scoreText, player;
    private PlayerController playerController;
    void Start()
    {
        playerController = player.GetComponent<PlayerController>();
        Time.timeScale = 1;
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            PlayerPrefs.DeleteKey("Score");
            PlayerPrefs.DeleteKey("Lives");
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void ExitGame()
    {
        PlayerPrefs.DeleteKey("Score");
        PlayerPrefs.DeleteKey("Lives");
        Application.Quit();
    }

    public void ReturnToMenu()
    {
        PlayerPrefs.DeleteKey("Score");
        PlayerPrefs.DeleteKey("Lives");
        SceneManager.LoadScene("MainMenu");
    }

    public void BackToGame()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartNextLevel()
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
                nextLevelMenu.SetActive(true);
            }
            else
            {
                Time.timeScale = 0;
                playerController.SetGameOverFlag(true);
                Cursor.visible = true;
                finishMenu.SetActive(true);
                scoreText.GetComponent<TextMeshProUGUI>().text = data[0].ToString();
            }
        }
    }
}
