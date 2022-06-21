using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

using UnityEngine;

public class SessionsManager : MonoBehaviour
{
    public static int SessionCount = 0;
    public static SessionsManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SessionIncrement()
    {
        SessionCount++;
        Debug.Log(SessionCount);
    }

    [System.Serializable]
    class SaveData
    {
        public int SessionCount;
    }

    public void Save()
    {
        SaveData data = new SaveData();
        data.SessionCount = SessionCount;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void Load()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            SessionCount = data.SessionCount;
        }
    }
}
