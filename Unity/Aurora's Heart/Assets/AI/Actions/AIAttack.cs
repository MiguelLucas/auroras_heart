using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Core;
using RAIN.Action;
using RAIN.Perception.Sensors;

[RAINAction("Attack Player")]
public class AIAttacK : RAINAction
{
    public AIAttacK()
    {
        actionName = "AIAttacK";
    }

    public override void Start(AI ai)
    {
        base.Start(ai);
    
    }

    public override ActionResult Execute(AI ai)
    {
        Debug.Log("atack");

        return ActionResult.RUNNING;
    }

    public override void Stop(AI ai)
    {
        base.Stop(ai);
    }
}
