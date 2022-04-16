using UnityEngine;
using UnityEngine.SceneManagement;

public class Brick : MonoBehaviour
{
    [SerializeField] private GameObject scoreBonusPrefab, liveBonusPrefab;
    protected void BonusAction(GameObject generator)
    {
        if (Random.Range(0f, 1f) < 0.5f)
        {
            _ = Instantiate(scoreBonusPrefab, generator.transform.position, Quaternion.Euler(0, 0, 0));
        }
        else
        {
            _ = Instantiate(liveBonusPrefab, generator.transform.position, Quaternion.Euler(0, 0, 0));
        }
    }

    protected void SceneChanger(int[] data)
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
                // SHow scores
                // Go to the main menu
            }
        }
    }
}
