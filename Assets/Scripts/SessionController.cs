using UnityEngine;

public class SessionController : MonoBehaviour
{
    public int sesionNumber = 0;
    // Start is called before the first frame update
    void Start()
    {
        
        SessionsManager.SessionIncrement();
        sesionNumber = SessionsManager.SessionCount;
    }
}
