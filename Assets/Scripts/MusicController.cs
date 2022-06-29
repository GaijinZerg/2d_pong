using UnityEngine;

/// <summary>
/// Controls the music playing.
/// </summary>
public class MusicController : MonoBehaviour
{
    private void Start()
    {
        gameObject.GetComponent<AudioSource>().volume = PlayerPrefs.HasKey("Music") ? PlayerPrefs.GetFloat("Music") : 0.5f;
        gameObject.GetComponent<AudioSource>().Play();
    }
}
