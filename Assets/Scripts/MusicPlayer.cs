using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        // Get the Type of the object we are (e.g. MusicPlayer)
        // This is a reusable singleton example
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            // If there is already a Music Player then get rid of the new one
            Destroy(gameObject);
        }
        else
        {
            // If we're the first then don't destroy us
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
