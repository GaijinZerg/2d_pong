using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;

public class CSVManager : MonoBehaviour
{
    private string _folderPath;

    void Start()
    {
        _folderPath = Path.Combine(Application.dataPath, "../");
        // Write initial file if does not exist.
        if (!File.Exists(_folderPath + "/highscores.sav"))
        {
            TextWriter writer = new StreamWriter(_folderPath + "/highscores.sav", true);
            writer.WriteLine("Player Name;Player Score");
            writer.Close();
            AddLineToCSV("Tawako", 130000);
            AddLineToCSV("Valera", 120000);
            AddLineToCSV("Red Fish", 110000);
            AddLineToCSV("Harry", 100000);
            AddLineToCSV("Mina", 90000);
            writer.Close();
        }
    }

    public static void AddLineToCSV(string name, int score)
    {
        TextWriter writer = new StreamWriter(Path.Combine(Application.dataPath, "../") + "/highscores.sav", true);
        writer.WriteLine(name + ";" + score.ToString());
        writer.Close();
    }

    public static List<string> ReadCSV()
    {
        List<string> scoresLines = new();
        string line;
        TextReader reader = new StreamReader(Path.Combine(Application.dataPath, "../") + "/highscores.sav");
        while ((line = reader.ReadLine()) != null)
        {
            scoresLines.Add(line);
        }
        reader.Close();
        return scoresLines;
    }

    public static void SortCSV()
    {
        List<string> scoresLines = ReadCSV();
        List<string> namesList = new();
        List<int> scoresList = new();
        for (int i = 1; i < scoresLines.Count; i++)
        {
            namesList.Add(scoresLines[i].Split(";")[0]);
            scoresList.Add(int.Parse(scoresLines[i].Split(";")[1]));
        }
        string[] namesArray = namesList.ToArray();
        int[] scoresArray = scoresList.ToArray();
        Array.Sort(scoresArray, namesArray);
        Array.Reverse(scoresArray);
        Array.Reverse(namesArray);
        DeleteCSV();
        TextWriter writer = new StreamWriter(Path.Combine(Application.dataPath, "../") + "/highscores.sav", true);
        writer.WriteLine("Player Name;Player Score");
        writer.Close();
        for (int i = 0; i < scoresArray.Length; i++)
        {
            AddLineToCSV(namesArray[i], scoresArray[i]);
        }
    }

    public static void DeleteCSV()
    {
        File.Delete(Path.Combine(Application.dataPath, "../") + "/highscores.sav");
    }
}
