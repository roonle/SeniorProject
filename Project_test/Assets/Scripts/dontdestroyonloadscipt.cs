using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontdestroyonloadscipt : MonoBehaviour
{
    public bool delete = false;

    private void Awake()
    {
        if (!delete)
        {
            DontDestroyOnLoad(this.gameObject);
        }
        else 
            Destroy(this.gameObject);
    }
}
