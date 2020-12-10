using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

[RequireComponent(typeof(NavMeshAgent))]
// from https://www.youtube.com/watch?v=UjkSFoLxesw
public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform player;
    public LayerMask whatIsGround, whatIsPlayer;

    public List<Transform> patrolPoints;
    public Transform myCameraTransform;
    private Transform currentDestination, healthBar;

    public float timeBetweenAttacks;
    private bool alreadyAttacked;
    private int i, randomNum;

    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;
    private int seconds = 2, pauseSeconds = 1;

    private Animator anim;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        if (healthBar)
        {
             healthBar = gameObject.transform.Find("Canvas").transform;
        }

        anim = gameObject.transform.Find("Enemy").GetComponent<Animator>();


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
        if (healthBar) healthBar.forward = myCameraTransform.forward;
        

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInSightRange && playerInAttackRange) AttackPlayer();
    }

    private void Patroling()
    { 
        randomNum = Random.Range(1, patrolPoints.Count);

        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            agent.destination = patrolPoints[i].position;
            i = (i + randomNum) % patrolPoints.Count;
            StartCoroutine(pause());
        }
    }
    

    private IEnumerator pause()
    {
        yield return new WaitForSeconds(pauseSeconds);
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
            anim.SetTrigger("isAttacking");
            alreadyAttacked = true;
            StartCoroutine(ResetAttack());
        }
    }

    private IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(timeBetweenAttacks);
        anim.ResetTrigger("isAttacking");
        alreadyAttacked = false;
    }
}
