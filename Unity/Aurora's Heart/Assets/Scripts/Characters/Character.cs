using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
    
    [SerializeField]
    protected float movementSpeed;
    [SerializeField]
    protected float attackStrenght;
    [SerializeField]
    protected float maxHp;
    [SerializeField]
    private bool isAttacking = false;

    protected float hp;
    protected bool dead;

    public bool Dead {
        get {
            return dead;
        }

        set {
            dead = value;
        }
    }

    public float AttackStrenght {
        get {
            return attackStrenght;
        }

        set {
            attackStrenght = value;
        }
    }

    public bool IsAttacking {
        get {
            return isAttacking;
        }

        set {
            isAttacking = value;
        }
    }

    public void instantKill() {
        dead = true;
    }

    // Use this for initialization
    void Start () {
        hp = maxHp;
        dead = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public virtual void damageHp(float damage) {
        hp -= damage;
        if (hp <= 0)
            dead = true;
    }
}