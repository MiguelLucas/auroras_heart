using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeviathanQuest : Quest {

    [SerializeField]
    private GameObject bridgeBarriers;
	public int numberSpirits = 20;
    private YggdrasilQuest.Rune rune = YggdrasilQuest.Rune.Verthandi;

    // Use this for initialization
    void Start () {

		Finish = false;
		State = 0;
		
	}

    protected override bool OnComplete(int curr_value)
    {
        if (curr_value >= numberSpirits)
            return true;

        return false;
    }

    public void RemoveBridgeBarriers()
    {
        Destroy(bridgeBarriers);
    }

    public YggdrasilQuest.Rune runeReward()
    {
        return this.rune;
    }
}
