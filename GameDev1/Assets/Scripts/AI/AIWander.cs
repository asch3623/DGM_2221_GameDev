using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

[RequireComponent(typeof(NavMeshAgent))]
// from https://www.youtube.com/watch?v=UjkSFoLxesw
public class AIWander : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform player;
    public LayerMask whatIsGround, whatIsPlayer;

    public Vector3 walkPoint;
    private bool walkPointSet;
    public float walkPointRange;

    public List<Transform> patrolPoints;
    public Transform myCameraTransform;
    private Transform currentDestination;

    public float timeBetweenAttacks;
    private bool alreadyAttacked;
    private int i, randomNum;

    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange, isMovingToPen;
    private int seconds = 1;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();



    }

    private void Start()
    {
        foreach (var obj in patrolPoints)
        {
           var mesh = obj.GetComponent<MeshRenderer>();
           mesh.enabled = false;
        }
    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange && !isMovingToPen) Wander();
        if (playerInSightRange && !playerInAttackRange && !isMovingToPen) ChasePlayer();
        if (playerInSightRange && playerInAttackRange && !isMovingToPen) AttackPlayer();
        if (agent.velocity == Vector3.zero )
        {
            walkPointSet = false;
        }
    }

    // private void Patroling()
    // { 
    //     randomNum = Random.Range(1, patrolPoints.Count);
    //
    //     if (!agent.pathPending && agent.remainingDistance < 0.5f)
    //     {
    //         agent.destination = patrolPoints[i].position;
    //         i = (i + randomNum) % patrolPoints.Count;
    //         StartCoroutine(pause());
    //     }
    // }
    

    private void Wander()
    {
        if (!walkPointSet) SearchWalkPoint();
        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == whatIsGround)
        {
            
        }
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }
    }

    private IEnumerator pause()
    {
        yield return new WaitForSeconds(seconds);
    }
    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            // my attack code here
            
            //end
            alreadyAttacked = true;
            StartCoroutine(ResetAttack());
        }
    }

    private IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(seconds);
        alreadyAttacked = false;
    }
}

