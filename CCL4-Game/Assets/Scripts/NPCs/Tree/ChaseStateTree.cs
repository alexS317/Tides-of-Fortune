using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseStateTree : StateMachineBehaviour
{
    private float timer;
    Transform player;
    NavMeshAgent agent;

    private float innerAttackRange = 4;
    private float aggroRange = 10;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = animator.GetComponent<NavMeshAgent>();
        agent.speed = 2f;
        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(player.position);

        float distanceToPlayer = Vector3.Distance(player.position, animator.transform.position);
        if (distanceToPlayer > aggroRange)
        {
            animator.SetBool("isChasing", false);
        }
        
        if (distanceToPlayer < innerAttackRange)
        {
            animator.SetBool("isAttacking", true);
        }
        

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(animator.transform.position);
    }

}
