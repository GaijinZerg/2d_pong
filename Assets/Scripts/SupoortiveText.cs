using System;
using TMPro;
using UnityEngine;

/// <summary>
/// Output game version and studio name on the main screen.
/// </summary>
public class SupoortiveText : MonoBehaviour
{
    [SerializeField] private GameObject _versionObject, _studioObject;
    private TextMeshProUGUI _versionText, _studioText;

    void Start()
    {
        _versionText = _versionObject.GetComponent<TextMeshProUGUI>();
        _studioText = _studioObject.GetComponent<TextMeshProUGUI>();
        _versionText.text = "v" + Application.version;
        _studioText.text = Application.companyName + ", " + DateTime.Now.Year;
    }
}
