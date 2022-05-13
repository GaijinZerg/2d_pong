using UnityEngine;

/// <summary>
/// Controls the music playing.
/// </summary>
public class MusicController : MonoBehaviour
{
    private void Start()
    {
        gameObject.GetComponent<AudioSource>().Play();
        gameObject.GetComponent<AudioSource>().volume = PlayerPrefs.HasKey("Music") ? PlayerPrefs.GetFloat("Music") : 1;
    }
}
