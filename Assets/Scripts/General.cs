using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class General : MonoBehaviour
{
    [SerializeField] private GameObject finishMenu, scoreText, player;
    private PlayerController playerController;
    void Start()
    {
        playerController = player.GetComponent<PlayerController>();
        Time.timeScale = 1;
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            PlayerPrefs.DeleteAll();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void ExitGame()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }

    public void ReturnToMenu()
    {
        PlayerPrefs.DeleteAll();
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

    public void SceneChanger(int[] data)
    {
        if (GameObject.FindGameObjectsWithTag("Brick").Length == 1)
        {
            if (SceneManager.GetActiveScene().name == "Level1")
            {
                PlayerPrefs.SetInt("Score", data[0]);
                PlayerPrefs.SetInt("Lives", data[1]);
                SceneManager.LoadScene("Level2");
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
