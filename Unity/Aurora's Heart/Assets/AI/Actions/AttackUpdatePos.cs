using RAIN.Core;
using RAIN.Action;
using UnityEngine;

[RAINAction("Update Position")]

public class AttackUpdatePos : RAINAction
{
    private static float threshold = 0.2f;

    // Use this for initialization
    public override void Start(AI ai)
    {
        if (getCircle(ai) == null)
        {
            base.Start(ai);
            setState(ai, AttackState.None);
            setSlot(ai, -1);
            setDestination(ai, Vector3.zero);
        }
    }

    private void setState(AI ai, AttackState state)
    {
        ai.WorkingMemory.SetItem("state", state);
    }

    private AttackState getState(AI ai)
    {
        return ai.WorkingMemory.GetItem<AttackState>("state");
    }

    private void setSlot(AI ai, int slot)
    {
        ai.WorkingMemory.SetItem("slot", slot);
    }

    private int getSlot(AI ai)
    {
        return ai.WorkingMemory.GetItem<int>("slot");
    }

    private void setCircle(AI ai, AttackCircle circle)
    {
        ai.WorkingMemory.SetItem("circle", circle);
    }

    private AttackCircle getCircle(AI ai)
    {
        return ai.WorkingMemory.GetItem<AttackCircle>("circle");
    }

    private void setDestination(AI ai, Vector3 destination)
    {
        ai.WorkingMemory.SetItem("destination", destination);
    }

    private Vector3 getDestination(AI ai)
    {
        return ai.WorkingMemory.GetItem<Vector3>("destination");
    }

    public override ActionResult Execute(AI ai)
    {
        AttackCircle circle = getCircle(ai);
        AttackState state = getState(ai);
        int slot = getSlot(ai);
        Vector3 destination = getDestination(ai);

        GameObject attackTarget = ai.WorkingMemory.GetItem<GameObject>("enemyDetected");
        if (attackTarget != null)
        {
            if (!circle)
            {
                circle = attackTarget.GetComponentInChildren<AttackCircle>();
                setCircle(ai, circle);
            }
            if (state == AttackState.None)
            {
                slot = circle.occupyWaitSlot(ai.Body);
                if(slot != -1)
                    state = AttackState.Wait;
            }

            if (state == AttackState.Wait)
            {
                destination = circle.slotWaitingPosition(slot);
                if (AttackCircle.distance2D(ai.Body.transform.position, destination) < threshold)
                {
                    int tmpSlot = circle.occupyAttackSlot(ai.Body);
                    if (tmpSlot != -1)
                    {
                        circle.freeWaitingSlot(ai.Body);
                        slot = tmpSlot;
                        state = AttackState.Ready;
                    }
                }
            }

            if (state == AttackState.Ready)
            {
                destination = circle.slotAttackingPosition(slot);
                if (AttackCircle.distance2D(ai.Body.transform.position, destination) < threshold)
                {
                    state = AttackState.Attack;
                    ai.WorkingMemory.SetItem("resTime", 0);
                }
            }

            if (state == AttackState.Attack)
            {
                destination = circle.slotWaitingPosition(slot);
                if (AttackCircle.distance2D(ai.Body.transform.position, destination) < threshold)
                {
                    
                    if (circle.countWaiting() > 0)
                    {
                        /*
                        circle.freeAttackSlot(ai.Body);
                        slot = -1;
                        state = AttackState.None;
                        */
                    }
                }
            }

            setState(ai, state);
            setSlot(ai, slot);
            setDestination(ai, destination);
            return ActionResult.SUCCESS;
        }
        else
        {
            if (circle)
            {
                circle.freeWaitingSlot(ai.Body);
                circle.freeAttackSlot(ai.Body);
                setSlot(ai, -1);
                setState(ai, AttackState.None);
            }
            return ActionResult.SUCCESS;
        }
    }
}
