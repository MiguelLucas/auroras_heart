using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour {



    public static DontDestroyOnLoad Object;

    void Awake()
    {
        MakeThisTheOnlyObject();
    }


    void MakeThisTheOnlyObject()
    {
        if (Object == null)
        {
            DontDestroyOnLoad(gameObject);
            Object = this;
        }
        else
        {
            if (Object != this)
            {
                Destroy(gameObject);
            }
        }
    }

    // Use this for initialization
    void Start () {

        DontDestroyOnLoad(transform.gameObject);
    }

}
