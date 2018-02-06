using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;
using RAIN.BehaviorTrees;
using RAIN.Navigation;
using RAIN.Minds;

[RAINAction]
public class AIStartLeviathanQuest : RAINAction
{
    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
		TextAsset bt = Resources.Load<TextAsset> ("LeviathanQuest");
		((BasicMind)ai.Mind).SetBehavior(bt, new Dictionary <string, TextAsset>());
		ai.Mind.AIInit ();
        return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}