using UnityEngine;

public class PlayerLife : MonoBehaviour {

    public virtual void OnParticleCollision(GameObject other)
    {
        Character attacker = other.transform.parent.GetComponent<Character>();
        if (attacker == null)
            attacker = other.transform.parent.transform.parent.GetComponent<Character>();
        Character player = GetComponent<Character>();
        if (!player.Dead)
            player.damageHp(attacker.AttackStrenght);
    }
}