using UnityEngine;
using UnityEngine.UI;

public class SensitivityController : MonoBehaviour
{
    private Slider slider;
    void Start()
    {
        slider = gameObject.GetComponent<Slider>();
        if (!PlayerPrefs.HasKey("Sensitivity"))
        {
            PlayerPrefs.SetFloat("Sensitivity", 1);
        }
        slider.value = PlayerPrefs.GetFloat("Sensitivity");
        slider.onValueChanged.AddListener ((sens) =>
        {
            PlayerPrefs.SetFloat("Sensitivity", sens);
        });
    }
}
