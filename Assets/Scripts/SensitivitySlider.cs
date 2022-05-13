using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Allows to adjust mouse sensitivity.
/// </summary>
public class SensitivitySlider : MonoBehaviour
{
    private Slider _slider;

    void Start()
    {
        _slider = gameObject.GetComponent<Slider>();
        if (!PlayerPrefs.HasKey("Sensitivity"))
        {
            PlayerPrefs.SetFloat("Sensitivity", 1);
        }
        _slider.value = PlayerPrefs.GetFloat("Sensitivity");
        _slider.onValueChanged.AddListener ((sens) =>
        {
            PlayerPrefs.SetFloat("Sensitivity", sens);
        });
    }
}
