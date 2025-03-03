using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TargetPlayer : MonoBehaviour
{
    private GameObject target;
    private Transform position;

    [SerializeField] private float speed;

    private NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        target = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (target != null)
            position = target.transform;
    }

    private void FixedUpdate()
    {
        if (position != null)
            agent.SetDestination(position.position);
    }
}
