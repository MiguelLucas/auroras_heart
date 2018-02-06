using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritSpell : MonoBehaviour {


    [SerializeField]
    private float projectileSpeed = 10f;
    [SerializeField]
    private AudioClip[] audioclips;
    private Transform target;
    private bool shootProjectile = false;
    private ParticleSystem projectile;

    private GvrAudioSource audioSource;

    public bool ShootProjectile
    {
        get
        {
            return shootProjectile;
        }

        set
        {
            shootProjectile = value;
        }
    }

    public Transform Target
    {
        get
        {
            return target;
        }

        set
        {
            target = value;
        }
    }


    // Use this for initialization
    void Start () {

        projectile = this.GetComponent<ParticleSystem>();
        projectile.Stop();

        audioSource = GetComponent<GvrAudioSource>();


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (ShootProjectile)
        {
            if (!projectile.isPlaying) {
                projectile.Play();
                int random = Random.Range(0, audioclips.Length);
                audioSource.PlayOneShot(audioclips[random]);
            }
               

            CastMagic(transform);
        }

    }


    public void CastMagic(Transform transform)
    {
        
        transform.position = Vector3.Lerp(transform.position, target.position, projectileSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //TODO: REMOVE HP FROM PLAYER
            //Debug.Log("Hit player");
            Destroy(gameObject);
        }
    }

}
