using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritCastSpell : MonoBehaviour {

    [SerializeField]
    private Transform target;
    [SerializeField]
    private Transform spwanPoint;

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }
    public void ShootProjectile()
    {
        
        SpiritSpell projectile = (SpiritSpell)Resources.Load("Spells/SpiritSpell", typeof(SpiritSpell));

        SpiritSpell prefab = Instantiate(projectile, spwanPoint.position, transform.rotation);
        prefab.Target = target;
        prefab.ShootProjectile = true;

        Destroy(prefab, 2);
    }
	

   


}
