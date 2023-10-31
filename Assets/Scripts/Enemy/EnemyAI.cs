using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;


public class EnemyAI : MonoBehaviour
{
    public AudioSource audioScream;
    private Animator anim;
    public NavMeshAgent agent;
    public Transform player;
    public float health;
    public LayerMask whatIsGround, WhatIsPlayer;

    //public GameObject projectile;

    //Patrolling
    public Vector3 walkPoint;
    private bool walkPointSet;
    public float walkPointRange;


    //Attacking
    public float timeBetweenAttacks;
    private bool alreadyAttacked;

    //Stats
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

   // PlayerHealth target;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        anim = gameObject.GetComponent<Animator>();
       // target = player.transform.GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, WhatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, WhatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patrolling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();

    }

    private void Patrolling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached 
        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }


    }

    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        float randomZ = Random.Range(-walkPointRange, walkPointRange);


        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;


    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
        Walk();
        Debug.Log("ChasePlayer!");
    }

    private void AttackPlayer()
    {
        Debug.Log("AttackPlayer!");
        //make sure enemy doesn't move
        agent.SetDestination(transform.position);
        transform.LookAt(player);






        anim.SetFloat("Attack", 0.4f, 0.1f, Time.deltaTime);

        if (!alreadyAttacked)
        {

            //Attack code here
            //Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            //rb.AddForce(transform.forward * 32f,ForceMode.Impulse);
            //rb.AddForce(transform.up * 8f,ForceMode.Impulse);
            //

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {

        //if (target.health > 0)
       // {
         //   target.TakeDamage(2);
        //}

        alreadyAttacked = false;
        anim.SetFloat("Attack", 0.0f, 0.0f, Time.deltaTime);
    }

    public void TakeDamage(float _damage)
    {
        health -= _damage;
        if (health <= 0f)
        {
            Invoke(nameof(DestroyEnemy), 0f);
        }
    }

    private void DestroyEnemy()
    {
        gameObject.GetComponent<NavMeshAgent>().isStopped = true;
        Patrolling();
        anim.SetFloat("Death", 0.4f, 0.1f, Time.deltaTime);
        Destroy(gameObject, 10f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);

    }


    private void Walk()
    {
        Debug.Log("Walk");
        audioScream.Play();
        anim.SetFloat("Speed", 0.4f, 0.1f, Time.deltaTime);

    }
}
