﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour
{
    public float patrolSpeed = 2f;                          // The nav mesh agent's speed when patrolling.
    public float chaseSpeed = 5f;                           // The nav mesh agent's speed when chasing.
    public float patrolWaitTime = 5f;                       // The amount of time to wait when the patrol way point is reached.
    public Transform[] patrolWayPoints;         // An array of transforms for the patrol route.

    private UnityEngine.AI.NavMeshAgent nav;                                // Reference to the nav mesh agent.
    private Transform player;                               // Reference to the player's transform.
    private GameObject play;

    private float patrolTimer;                              // A timer for the patrolWaitTime.
    private int wayPointIndex;                              // A counter for the way point array.
    private GameManager GameManager;
    public string text;
    public float timeBetweenAttacks = 0.9f;     // The time in seconds between each attack.
    public int attackDamage = 10;               // The amount of health taken away per attack.
    //Playerhp playerHealth;                  // Reference to the player's health.

    float timer;                                // Timer for counting up to the next attack.
    enum AIState { Patrolling, Chasing };

    AIState state;

    float enemydist;   //how far away is enemy

    //Text messagetext;

    void Awake()
    {
        // Setting up the references.
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();

        play = GameObject.FindGameObjectWithTag("Player");
        //playerHealth = play.GetComponent<Playerhp>();

        player = GameObject.FindGameObjectWithTag("Player").transform;
       

        state = AIState.Patrolling;

        //messagetext = GameObject.Find("MessageText").GetComponent<Text>();
       
    }


    void Update()
    {
        // Add the time since Update was last called to the timer.
        timer += Time.deltaTime;

        /*  if (Input.GetKeyDown(KeyCode.X))
              state = AIState.Shooting;

          if (Input.GetKeyDown(KeyCode.C))
              state = AIState.Chasing;

              */

        switch (state)
        {
            case AIState.Chasing:
                Chasing();
                break;
            case AIState.Patrolling:
                Patrolling();
                break;
        }
        
        enemydist = Vector3.Distance(player.transform.position, transform.position);
        if (enemydist >= 10)
        {
            state = AIState.Patrolling;
        }
        if (enemydist<=10)
        {
            state = AIState.Chasing;
        }
        if (timer >= timeBetweenAttacks && enemydist  <= 5)
        {
            //playerHealth.TakeDamage(10);
            //playerHealth.currentHealth = playerHealth.currentHealth - attackDamage;
            timer = 0;
            //Debug.Log("AIplayerhealth"+playerHealth.currentHealth);
            
        }

    }


    void Chasing()
    {
        //messagetext.text = "Chasing: Nav rem dist= " + nav.remainingDistance + " navstop=" + nav.stoppingDistance;

        nav.destination = player.transform.position;
        nav.speed = chaseSpeed;
        nav.isStopped = false;
    }


    void Patrolling()
    {
        nav.isStopped = false;
        text = "Nav rem dist= " + nav.remainingDistance + " navstop=" + nav.stoppingDistance + " wp = " + wayPointIndex + "dest " + patrolWayPoints[wayPointIndex].position;

        //messagetext.text = "Patrolling: " + text;

        // Set an appropriate speed for the NavMeshAgent.
        nav.speed = patrolSpeed;

        // If near the next waypoint or there is no destination...
        //print(nav.remainingDistance);
            //print(nav.stoppingDistance);
        if (nav.remainingDistance < nav.stoppingDistance)
        {
            // ... increment the timer.
            patrolTimer += Time.deltaTime;

            // If the timer exceeds the wait time...
            if (patrolTimer >= patrolWaitTime)
            {
                // ... increment the wayPointIndex.
                if (wayPointIndex == patrolWayPoints.Length - 1)
                    wayPointIndex = 0;
                else
                    wayPointIndex++;

                // Reset the timer.
                patrolTimer = 0;
            }
        }
        else
            // If not near a destination, reset the timer.
            patrolTimer = 0;

        // Set the destination to the patrolWayPoint.
        nav.destination = patrolWayPoints[wayPointIndex].position;
    }

}
