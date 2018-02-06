using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class StopLooking : RAINAction
{
    private GameObject leviathan;
    private LeviathanInteraction interaction;

    public override void Start(RAIN.Core.AI ai)
    {
        leviathan = GameObject.Find("InteractionLeviathan");
        Debug.Log(leviathan);
        interaction = leviathan.GetComponent<LeviathanInteraction>();

        base.Start(ai);
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {

        interaction.StopLooking();
        return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}