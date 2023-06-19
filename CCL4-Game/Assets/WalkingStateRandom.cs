using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class WalkingStateRandom : StateMachineBehaviour
{
    private float timer;
    //List<Transform> wayPoints = new List<Transform>();
    NavMeshAgent agent;
    Transform player;
    private float chaseRange = 10;
    [SerializeField]
    private float attackRange = 3;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        player = GameObject.FindGameObjectWithTag("Player").transform;

        agent = animator.GetComponent<NavMeshAgent>();

        //agent.SetDestination(wayPoints[Random.Range(0, wayPoints.Count)].position);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;

        float distanceToPlayer = Vector3.Distance(player.position, animator.transform.position);
        if (distanceToPlayer < chaseRange)
        {
            //agent.speed = 2f;
            //agent.SetDestination(player.position);
            if (distanceToPlayer < attackRange)
            {
                animator.SetBool("isAttacking", true);
            }
        }
        else
        {
            //agent.speed = 1.2f;
            if (timer > 8)
            {
                animator.SetBool("isWalking", false);
            }

            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                // Calculate a random position within a range around the object
                Vector3 randomPosition = animator.transform.position + Random.insideUnitSphere * 5f;
                NavMeshHit navMeshHit;

                // Find the closest valid position on the NavMesh to the random position
                if (NavMesh.SamplePosition(randomPosition, out navMeshHit, 5f, NavMesh.AllAreas))
                {
                    agent.SetDestination(navMeshHit.position);
                }
            }
        }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
    }

  
}
