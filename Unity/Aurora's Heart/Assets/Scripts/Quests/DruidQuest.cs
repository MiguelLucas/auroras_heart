using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DruidQuest : Quest {

    [SerializeField]
    private GameObject caveBarrier;
    [SerializeField]
    private int numberMushrooms = 3;

    // Use this for initialization
    void Start()
    {

        Finish = false;
        State = 0;

    }

    protected override bool OnComplete(int curr_value)
    {
        if (curr_value >= numberMushrooms)
            return true;

        return false;
    }

    public void RemoveCaveBarrier()
    {
        Destroy(caveBarrier);
    }
}
