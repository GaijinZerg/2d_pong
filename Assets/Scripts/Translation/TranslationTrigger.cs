using System;
using UnityEngine;

public class TranslationTrigger : MonoBehaviour
{
    public static event Action<string> initiateTranslation;

    public void InitiateTranslation(string langcode)
    {
        PlayerPrefs.SetString("Language", langcode);
        initiateTranslation?.Invoke(langcode);
    }
}
