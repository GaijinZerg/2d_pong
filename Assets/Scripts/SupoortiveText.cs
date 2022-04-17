using System;
using TMPro;
using UnityEngine;

public class SupoortiveText : MonoBehaviour
{
    [SerializeField] private GameObject versionObject, studioObject;
    private TextMeshProUGUI versionText, studioText;

    void Start()
    {
        versionText = versionObject.GetComponent<TextMeshProUGUI>();
        studioText = studioObject.GetComponent<TextMeshProUGUI>();
        versionText.text = "v" + Application.version;
        studioText.text = Application.companyName + ", " + DateTime.Now.Year;
    }
}
