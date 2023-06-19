using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkingStateTree : StateMachineBehaviour
{
    private float timer;
    List<Transform> wayPoints = new List<Transform>();
    NavMeshAgent agent;
    Transform player;
    private float chaseRange = 10;
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
        agent.speed = 1.4f;
        agent.SetDestination(wayPoints[Random.Range(0, wayPoints.Count)].position);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;
        
        
        agent.speed = 1.2f;
            if (timer > 8)
            {
                animator.SetBool("isWalking", false);
            }

            if (agent.remainingDistance <= agent.stoppingDistance)
                agent.SetDestination(wayPoints[Random.Range(0, wayPoints.Count)].position);

        float distanceToPlayer = Vector3.Distance(player.position, animator.transform.position);
        if (distanceToPlayer < chaseRange)
        {
            agent.speed = 2f;
            agent.SetDestination(player.position);
            if (distanceToPlayer < chaseRange)
            {
                animator.SetBool("isChasing", true);
            }
        }
        

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
