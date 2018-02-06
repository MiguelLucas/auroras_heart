using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class HolleSpell : RAINAction
{

    private GameObject holle;
    private HolleInteraction interaction;

    public override void Start(RAIN.Core.AI ai)
    {
        holle = GameObject.Find("InteractionHolle");
        interaction = holle.GetComponent<HolleInteraction>();
        base.Start(ai);
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
        interaction.StartAltarSpell();
        return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}