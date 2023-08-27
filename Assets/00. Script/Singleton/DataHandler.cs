using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.SocialPlatforms;

public class DataHandler : SingletonBase<DataHandler>
{
    [HideInInspector] public UserData userData;

    private void Start()
    {
        
    }

    void ReadCSVData(string csvFilePath, List<List<String>> stringTable)
    {
        // Read the CSV file
        TextAsset csvFile = Resources.Load<TextAsset>(csvFilePath);

        string[] csvLines = csvFile.text.Split('\n');
        string[] headers = csvLines[0].Split(',');

        // Parse the CSV data
        for (int i = 1; i < csvLines.Length - 1; i++)
        {
            string[] values = SplitCSVLine(csvLines[i]);

            List<string> rowData = new List<string>();

            for (int j = 0; j < headers.Length; j++)
            {
                rowData.Add(values[j]);
            }
            stringTable.Add(rowData);
        }
    }

    private string[] SplitCSVLine(string line)
    {
        List<string> values = new List<string>();
        bool insideQuotes = false;
        string currentValue = "";

        for (int i = 0; i < line.Length; i++)
        {
            char c = line[i];

            if (c == '\"')
            {
                insideQuotes = !insideQuotes;
            }
            else if (c == ',' && !insideQuotes)
            {
                values.Add(currentValue);
                currentValue = "";
            }
            else
            {
                currentValue += c;
            }
        }

        values.Add(currentValue);

        return values.ToArray();
    }
}


[Serializable]
public class MapInfo
{
    public string mapName;
    public bool isClear;
}

[Serializable]
public class UserData
{
    public List<MapInfo> mapInfo;
    public string userName;
    public int curBGM;
    public int gold;
    public int stamina;
    public float exp;
    public int karendia;
}

[Serializable]
public class SCPInfo
{
    public string cardName;
    public int secureLevel;
    public string soundName;
    public string videoName;
    public string spotPrefabName;
    public string[] spotDescription;
    public string[] spotImagePath;
}
[Serializable]
public class SCPDataList
{
    public List<SCPInfo> scpInfos;
}
