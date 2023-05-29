using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoDestroyOnLoad : MonoBehaviour
{
    private void Awake()
    {
        var exists = GameObject.FindWithTag(gameObject.tag);
        if (exists is not null && exists != transform.gameObject)
        {
            DestroyImmediate(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
}
