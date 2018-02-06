using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draugr : Character {

    [SerializeField]
    private GameManager gameManager;
    [SerializeField]
    private int numberSpiritsWhenKilled = 2;
    [SerializeField]
    private ParticleSystem deathExplosion;
    private bool check = true;
    Animator animator;
    private float currentValue = 0.25f;
    private float targetValue = 0.25f;
    private float dampTime = 2f;

    private GvrAudioSource audioSource;
    // Use this for initialization
    void Start () {

        gameManager = GameObject.FindObjectOfType<GameManager>();
        hp = maxHp;
        dead = false;
        animator = GetComponent<Animator>();
        deathExplosion.Stop();


    }
	
	// Update is called once per frame
	void FixedUpdate () {

        currentValue = Mathf.Lerp(currentValue, targetValue, Time.deltaTime * dampTime);

        if (check)
        {
            if (Dead)
            {
                audioSource.Play();
                animator.SetFloat("State", 1);
                deathExplosion.Play();
                Destroy(gameObject, 3);
                check = false;
                gameManager.Spirits += numberSpiritsWhenKilled;
            }
            else if (IsAttacking && animator.IsInTransition(0))
            {
                targetValue = 0f;
                animator.SetFloat("State", currentValue);
            }
            else
            {
                targetValue = 0.25f;
                animator.SetFloat("State", currentValue);
            }
        }
        
    }

    public override void damageHp(float damage)
    {

        hp -= damage;
        if (hp <= 0)
            dead = true;

        currentValue = 1f;
        targetValue = 0.25f;
        animator.SetFloat("State", currentValue);
    }
}
