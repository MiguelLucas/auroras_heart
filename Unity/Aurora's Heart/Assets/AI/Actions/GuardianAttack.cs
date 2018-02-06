using UnityEngine;
using RAIN.Core;
using RAIN.Action;
using RAIN.Representation;

[RAINAction("Guardian Attack")]
public class GuardianAttack : RAINAction
{
    public override void Start(AI ai)
    {
        base.Start(ai);
    }

    public override ActionResult Execute(AI ai)
    {
        Animator animator = ai.Body.GetComponent<Animator>();
        animator.enabled = true;
        animator.Play("Attack");
        var attackParticles = ai.Body.GetComponentInChildren<ParticleSystem>();
        attackParticles.Emit(1);
        return ActionResult.SUCCESS;
    }
}
