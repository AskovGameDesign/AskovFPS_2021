using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimpleEnemy : MonoBehaviour, IDamageable
{
    public Transform player;
    public float health;
    public AudioClip gotHitSound;
    public AudioClip deathSound;

    private NavMeshAgent agent;
    private Rigidbody rb;
    private Animator animator;
    private AudioSource audio;

    private bool isDead = false;

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (audio && gotHitSound)
            audio.PlayOneShot(gotHitSound);

        if(health <= 0f)
        {
            if(animator)
                animator.SetTrigger("Dying");

            if (audio && deathSound)
                audio.PlayOneShot(deathSound);

            isDead = true;
            agent.enabled = false;

            Collider[] colliders = GetComponentsInChildren<Collider>();
            foreach (var col in colliders)
            {
                col.enabled = false;
            }
            this.enabled = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();

        //animator.SetFloat("WalkOffset", Random.Range(0f, 1f));
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
            return;

        agent.SetDestination(player.position);

        if(animator)
            animator.SetFloat("Speed", agent.velocity.magnitude);
    }
}
