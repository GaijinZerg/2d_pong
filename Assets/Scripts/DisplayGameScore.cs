using TMPro;
using UnityEngine;

public class DisplayGameScore : MonoBehaviour
{
    [SerializeField] private GameObject playerScore;

    private void Start()
    {
        playerScore.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("Score").ToString();
    }
}
