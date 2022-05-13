using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Allows to adjust mouse sensitivity.
/// </summary>
public class MusicSlider : MonoBehaviour
{
    [SerializeField] private GameObject musicObject;
    private Slider _slider;

    void Start()
    {
        if (!PlayerPrefs.HasKey("Music"))
        {
            PlayerPrefs.SetFloat("Music", 1);
        }
        _slider = gameObject.GetComponent<Slider>();
        _slider.value = PlayerPrefs.GetFloat("Music");
        _slider.onValueChanged.AddListener ((music) =>
        {
            PlayerPrefs.SetFloat("Music", music);
            musicObject.GetComponent<AudioSource>().volume = music;
        });
    }
}
