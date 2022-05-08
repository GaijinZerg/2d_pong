using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScoresDisplay : MonoBehaviour
{
    [SerializeField] private GameObject namesColumn, scoresColumn;
    private TextMeshProUGUI _namesText, _scoresText;
    private List<string> _scoresLines = new();

    void Start()
    {
        _namesText = namesColumn.GetComponent<TextMeshProUGUI>();
        _scoresText = scoresColumn.GetComponent<TextMeshProUGUI>();
        CSVManager.SortCSV();
        _scoresLines = CSVManager.ReadCSV();
        DisplayScores();
    }

    private void DisplayScores()
    {
        string names = "", scores = "";
        for (int i = 1; i < 6; i++)
        {
            names = names + _scoresLines[i].Split(";")[0] + "\n";
            scores = scores + _scoresLines[i].Split(";")[1].ToString() + "\n";
        }
        _namesText.text = names;
        _scoresText.text = scores;
    }
}
