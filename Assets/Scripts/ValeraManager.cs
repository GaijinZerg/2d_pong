using System.Linq;
using UnityEngine;

public class ValeraManager : MonoBehaviour
{
    [SerializeField] private GameObject[] characters;
    private General _general;
    private bool[] _characters = { false, false, false, false, false, false };

    private void Start()
    {
        _general = GameObject.FindGameObjectWithTag("General").GetComponent<General>();
    }

    // ToDo: we need event here.
    public void ActivateCharacter(int number)
    {
        _characters[number] = true;
        characters[number].SetActive(true);
        if (Valera())
        {
            _general.SetSecretLevel();
        }
    }

    private bool Valera()
    {
        if (!_characters.Contains(false))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}