using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Provides functionality for non-stop music playing.
/// </summary>
public class AuxiliaryMusicController : MonoBehaviour
{
    private void Start()
    {
        // ToDo: redo considering new scene structure.
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
