using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doNotDestroy : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] musicOject = GameObject.FindGameObjectsWithTag("Gamemusic");
        if(musicOject.Length > 1)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
}
