//Purpose: This script will move the enemy.
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

    private UI_Controller ui;


    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        target = GameObject.FindGameObjectWithTag("Player");
        ui = GameObject.FindObjectOfType<UI_Controller>();
        if (ui.getSlow()) agent.speed = 1f;
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
