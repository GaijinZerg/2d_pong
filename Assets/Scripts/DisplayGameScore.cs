using TMPro;
using UnityEngine;

public class DisplayGameScore : MonoBehaviour
{
    [SerializeField] private GameObject playerScore;

    public void DisplayPlayerScore()
    {
        playerScore.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("Score").ToString();
    }
}
