using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Allows to adjust mouse sensitivity.
/// </summary>
public class SoundSlider : MonoBehaviour
{
    private Slider _slider;

    void Start()
    {
        if (!PlayerPrefs.HasKey("Sound"))
        {
            PlayerPrefs.SetFloat("Sound", 1);
        }
        _slider = gameObject.GetComponent<Slider>();
        _slider.value = PlayerPrefs.GetFloat("Sound");
        _slider.onValueChanged.AddListener ((sound) =>
        {
            PlayerPrefs.SetFloat("Sound", sound);
        });
    }
}
