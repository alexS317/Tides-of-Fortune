using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkStateGhost : StateMachineBehaviour
{

    //private float timer;
    List<Transform> wayPoints = new List<Transform>();
    NavMeshAgent agent;
    Transform player;
    private float chaseRange = 15;
    

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
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

        float distanceToPlayer = Vector3.Distance(player.position, animator.transform.position);
        if (distanceToPlayer < chaseRange)
        {
            animator.SetBool("isAttacking", true);
        }
        else if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            int nextWaypointIndex = Random.Range(0, wayPoints.Count);
            agent.SetDestination(wayPoints[nextWaypointIndex].position);
        }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
    }
    
}
