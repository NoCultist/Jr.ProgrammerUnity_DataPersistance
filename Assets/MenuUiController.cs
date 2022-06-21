using System.Collections;
using System.Collections.Generic;

using UnityEditor;

using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUiController : MonoBehaviour
{
 

    public void Play()
    {
        SessionsManager.Instance.Load();
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
}
