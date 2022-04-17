using UnityEngine;
using UnityEngine.SceneManagement;

public class AuxiliaryMusicController : MonoBehaviour
{
    private void Start()
    {
        if (GameObject.FindGameObjectWithTag("Music") != null)
        {
            if (SceneManager.GetActiveScene().name != "MainMenu")
            {
                GameObject.FindGameObjectWithTag("Music").GetComponent<MusicController>().PlayMusic();
            }
            else
            {
                GameObject.FindGameObjectWithTag("Music").GetComponent<MusicController>().StopMusic();
            }
        }
    }
}
