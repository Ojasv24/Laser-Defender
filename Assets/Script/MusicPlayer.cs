using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    void Awake()
    {
        /* int numOfThings = FindObjectsOfType<MusicPlayer>().Length;
         if(numOfThings > 1)
         {
             gameObject.SetActive(false);
             Destroy(gameObject);
         }
         else
         {
             DontDestroyOnLoad(gameObject);
         }*/
        SetUpSingleton();

    }

    private void SetUpSingleton()
    {
        if(FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
