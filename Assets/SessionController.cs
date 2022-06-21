using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SessionsManager.Instance.SessionIncrement();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
