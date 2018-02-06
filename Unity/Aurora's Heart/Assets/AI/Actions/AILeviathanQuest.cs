using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;
using RAIN.Navigation.Targets;
using RAIN.BehaviorTrees;
using RAIN.Minds;

[RAINAction]
public class AILeviathanQuest : RAINAction
{
    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);

    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
        return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}