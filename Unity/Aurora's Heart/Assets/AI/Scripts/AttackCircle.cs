using System.Collections.Generic;
using UnityEngine;
using RAIN.Navigation;

public enum AttackState
{
    None,
    Wait,
    Ready,
    Attack
}

public class AttackCircle : MonoBehaviour {

    private const int maxCnst = 10;

    public int maxAttackers;
    public float attackingDistance;
    public int maxWaiting;
    public float waitingDistance;

    private Vector3 waitOrientation;
    private Vector3 attackOrientation;

    [System.NonSerialized]
    public GameObject[] attackers;

    [System.NonSerialized]
    public GameObject[] waiting;

    public static float distance2D(Vector3 vec, Vector3 vec2)
    {
        Vector3 tmpVec = new Vector3(vec.x, 0, vec.z);
        Vector3 tmpVec2 = new Vector3(vec2.x, 0, vec2.z);
        return Vector3.Distance(tmpVec, tmpVec2);
    }

    void Start()
    {
        maxAttackers = Mathf.Clamp(maxAttackers, 0, maxCnst);
        attackers = new GameObject[maxAttackers];
        maxWaiting = Mathf.Clamp(maxWaiting, 0, maxCnst);
        waiting = new GameObject[maxWaiting];
        waitOrientation = Vector3.zero;
        attackOrientation = Vector3.zero;
        clear();
    }

    void clear()
    {
        for (int i = 0; i < attackers.Length; i++)
            attackers[i] = null;
        for (int i = 0; i < waiting.Length; i++)
            waiting[i] = null;
    }

    public int countWaiting()
    {
        int filledSpots = 0;
        for (int i = 0; i < waiting.Length; i++)
            if (waiting[i] != null)
                filledSpots++;
        return filledSpots;
    }

    public void freeWaitingSlot(GameObject attacker)
    {
        int freeSpots = 0;
        for (int i = 0; i < waiting.Length; i++)
        {
            if (waiting[i] == attacker)
                waiting[i] = null;
            else if (waiting[i] == null)
                freeSpots++;
        }
        if (freeSpots == 0)
            waitOrientation = Vector3.zero;
    }

    public void freeAttackSlot(GameObject attacker)
    {
        int freeSpots = 0;
        for (int i = 0; i < attackers.Length; i++)
        {
            if (attackers[i] == attacker)
                attackers[i] = null;
            else if (attackers[i] == null)
                freeSpots++;
        }
        if (freeSpots == 0)
            attackOrientation = Vector3.zero;
    }

    public int occupyWaitSlot(GameObject attacker)
    {
        int slot = -1;
        if (waitOrientation.Equals(Vector3.zero))
        {
            slot = 0;
            waiting[slot] = attacker;
            waitOrientation = closestSlot(attacker, waitingDistance);
        }
        else
        {
            float bestDistance = float.MaxValue;
            int bestSlot = -1;
            List<int> openList = new List<int>();

            for (int i = 0; i < waiting.Length; i++)
            {
                if (waiting[i] == attacker)
                    return i;
                else if (waiting[i] == null)
                    openList.Add(i);
            }

            for (int i = 0; i < openList.Count; i++)
            {
                Vector3 attackPosition = slotWaitingPosition(openList[i]);
                float distance = (attacker.transform.position - attackPosition).magnitude;
                if (distance < bestDistance)
                {
                    bestDistance = distance;
                    bestSlot = openList[i];
                }
            }

            slot = bestSlot;
            if (slot != -1)
                waiting[slot] = attacker;
        }
        return slot;
    }

    public int occupyAttackSlot(GameObject attacker)
    {
        int slot = -1;
        if (attackOrientation.Equals(Vector3.zero))
        {
            slot = 0;
            attackers[slot] = attacker;
            attackOrientation = closestSlot(attacker, attackingDistance);
        }
        else
        {
            float bestDistance = float.MaxValue;
            int bestSlot = -1;
            List<int> openList = new List<int>();

            for (int i = 0; i < attackers.Length; i++)
            {
                if (attackers[i] == attacker)
                    return i;
                else if (attackers[i] == null)
                    openList.Add(i);
            }

            for (int i = 0; i < openList.Count; i++)
            {
                Vector3 attackPosition = slotAttackingPosition(openList[i]);
                float distance = (attacker.transform.position - attackPosition).magnitude;
                if (distance < bestDistance)
                {
                    bestDistance = distance;
                    bestSlot = openList[i];
                }
            }

            slot = bestSlot;
            if (slot != -1)
                attackers[slot] = attacker;
        }
        return slot;
    }

    public Vector3 slotWaitingPosition(int slot)
    {
        float angle = slot * (2 * Mathf.PI / maxWaiting);
        Vector3 pivot = gameObject.transform.position;
        float newX = pivot.x + waitOrientation.x * Mathf.Cos(angle) - waitOrientation.z * Mathf.Sin(angle);
        float newZ = pivot.z + waitOrientation.x * Mathf.Sin(angle) + waitOrientation.z * Mathf.Cos(angle);
        return new Vector3(newX,pivot.y + waitOrientation.y, newZ);
    }

    public Vector3 slotAttackingPosition(int slot)
    {
        float angle = (2 * Mathf.PI / maxAttackers);
        angle = slot * angle + angle / 2;
        Vector3 pivot = gameObject.transform.position;
        float newX = pivot.x + attackOrientation.x * Mathf.Cos(angle) - attackOrientation.z * Mathf.Sin(angle);
        float newZ = pivot.z + attackOrientation.x * Mathf.Sin(angle) + attackOrientation.z * Mathf.Cos(angle);
        return new Vector3(newX, pivot.y + attackOrientation.y, newZ);
    }

    private Vector3 closestSlot(GameObject attacker, float radius)
    {
        //V = (P - C); Answer = V / |V| * R;
        var distanceVec = attacker.transform.position - gameObject.transform.position;
        return (distanceVec / distanceVec.magnitude) * radius;
    }
}
