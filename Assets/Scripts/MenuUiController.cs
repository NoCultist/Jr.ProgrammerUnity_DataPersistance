
using UnityEditor;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUiController : MonoBehaviour
{
    
    public Text sessionCountDisplay;
    public Text nameDisplay;

    private void Start()
    {
        sessionCountDisplay.text = $"Sessions Played: {SessionsManager.SessionCount}";
        UpdateName(SessionsManager.PlayerName);
    }
    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        SessionsManager.Instance.Save();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }

    public void UpdateName(string name)
    {
        nameDisplay.text = name;
    }
}
