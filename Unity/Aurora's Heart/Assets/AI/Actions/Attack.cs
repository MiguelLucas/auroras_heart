using UnityEngine;
using RAIN.Core;
using RAIN.Action;
using RAIN.Representation;

[RAINAction("Attack")]
public class SpiritAttack : RAINAction
{
    public Expression timeSpan = new Expression();
    private float defaultTimeSpan = 1f;
    private float currentTime = -1;
    private SpiritCastSpell castSpell;
    private Character character;

    public override void Start(AI ai)
    {
        base.Start(ai);
        castSpell = ai.Body.GetComponentInChildren<SpiritCastSpell>();
        character = ai.Body.GetComponentInParent<Character>();
    }

    public override ActionResult Execute(AI ai)
    {
        float dTimeSpan = 0;
        dTimeSpan = timeSpan.Evaluate<float>(ai.DeltaTime, ai.WorkingMemory);
        if (dTimeSpan <= 0)
            dTimeSpan = defaultTimeSpan;

        AttackState state = ai.WorkingMemory.GetItem<AttackState>("state");
        if (state == AttackState.Attack && !character.Dead)
        {
            character.IsAttacking = true;
            currentTime -= Time.deltaTime;
            if (currentTime <= 0)
            {
                castSpell.ShootProjectile();
                currentTime = dTimeSpan;
            }
           
        }
        character.IsAttacking = false;
        return ActionResult.SUCCESS;
    }

}
