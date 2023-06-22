using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkingState : StateMachineBehaviour
{
    private float timer;
    List<Transform> wayPoints = new List<Transform>();
    NavMeshAgent agent;
    Transform player;

    [SerializeField]
    private float chaseRange = 10;
    [SerializeField] 
    private float attackRange = 3;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
        

        GameObject goTo = GameObject.FindGameObjectWithTag("WayPoints");
        foreach (Transform t in goTo.transform)
            wayPoints.Add(t);

        agent = animator.GetComponent<NavMeshAgent>();
        agent.SetDestination(wayPoints[Random.Range(0, wayPoints.Count)].position);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;
        
        float distanceToPlayer = Vector3.Distance(player.position, animator.transform.position);
        if (distanceToPlayer < chaseRange)
        {
            agent.speed =  2f;
            agent.SetDestination(player.position);
            if (distanceToPlayer < attackRange)
            {
                animator.SetBool("isAttacking", true);
            }
        }
        else
        {
            agent.speed = 1.2f;
            if (timer > 8)
            {
                animator.SetBool("isWalking", false);
            }

            if (agent.remainingDistance <= agent.stoppingDistance)
                agent.SetDestination(wayPoints[Random.Range(0, wayPoints.Count)].position);
        }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
    }

}
