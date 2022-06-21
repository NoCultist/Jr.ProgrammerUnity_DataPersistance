using UnityEngine;
using UnityEngine.UI;

public class SessionController : MonoBehaviour
{
    public Text playerName;
    public int sesionNumber = 0;
    // Start is called before the first frame update
    void Start()
    {
        playerName.text = SessionsManager.PlayerName;
        SessionsManager.SessionIncrement();
        sesionNumber = SessionsManager.SessionCount;
    }
}
