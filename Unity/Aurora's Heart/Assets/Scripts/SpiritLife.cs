using UnityEngine;

public class SpiritLife : PlayerLife {

    public GameObject light = null;

    void OnParticleCollision(GameObject other)
    {
        base.OnParticleCollision(other);
        Character player = GetComponent<Character>();
        if (player.Dead)
        {
            var pos = gameObject.transform.position;
            Destroy(gameObject);
            Instantiate(light, pos, Quaternion.identity);
        }
    }
}
