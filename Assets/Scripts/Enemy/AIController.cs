using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    private GameObject destination;
    private NavMeshAgent agent;
    private Animator animator;
    void Start()
    {
        destination = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        agent.SetDestination(destination.transform.position);
    }

    public void IncreaseSpeed(float amount)
    {
        agent.speed += amount;
    }

    public IEnumerable<WaitForSeconds> StopMovement()
    {
        agent.isStopped = true;
        animator.SetBool("isStanding", true);
        yield return new WaitForSeconds(6f);
        agent.isStopped = false;
        animator.SetBool("isStanding", false);
    }
}