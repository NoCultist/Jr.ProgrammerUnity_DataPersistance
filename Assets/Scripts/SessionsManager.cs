using System.IO;

using UnityEngine;

public class SessionsManager : MonoBehaviour
{
    private static int sessionCount = -1;
    public static string PlayerName = "Player";
    public static string bestPlayerName = "";
    public static int bestScore = 0;

    public static void SetBestScore(int score, string playerName)
    {
        bestPlayerName = playerName;
        bestScore = score;
        SessionsManager.Instance.Save();
    }

    public static void SetPlayerName(string name)
    {
        PlayerName = name;
    }

    public static int SessionCount
    {
        get
        {
            if (sessionCount == -1)
                Instance.Load();
            return sessionCount;
        }
    }
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

    public static void SessionIncrement()
    {
        sessionCount++;
        Debug.Log(sessionCount);
    }

    [System.Serializable]
    class SaveData
    {
        public int SessionCount;
        public int bestScore;
        public string bestPlayerName;
    }

    public void Save()
    {
        SaveData data = new SaveData();
        data.SessionCount = sessionCount;
        data.bestScore = bestScore;
        data.bestPlayerName = bestPlayerName;

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

            sessionCount = data.SessionCount;
            bestScore = data.bestScore;
            bestPlayerName = data.bestPlayerName;
        }
    }
}
