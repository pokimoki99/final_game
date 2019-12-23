using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour
{
    public float patrolSpeed = 2f;                          // The nav mesh agent's speed when patrolling.
    public float chaseSpeed = 5f;                           // The nav mesh agent's speed when chasing.
    public float patrolWaitTime = 5f;                       // The amount of time to wait when the patrol way point is reached.
    protected DrawWaypoint[] patrolWayPoints;         // An array of transforms for the patrol route.
    protected DrawWaypoint WayPoints;         // An array of transforms for the patrol route.

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
    enum AIState { Patrolling, Shooting, Chasing };

    AIState state;

    float enemydist;   //how far away is enemy
    public Transform enemybullet;
    bool enemy;
    bool loc;

    public GameObject bulletpos;

    //Text messagetext;

    void Awake()
    {
        // Setting up the references.
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();

        play = GameObject.FindGameObjectWithTag("Player");
        //playerHealth = play.GetComponent<Playerhp>();

        player = GameObject.FindGameObjectWithTag("Player").transform;

        patrolWayPoints = FindObjectsOfType<DrawWaypoint>();
       

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
            case AIState.Shooting:
                Shooting();
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
        if (enemydist <= 20 && enemydist >= 11)
        {
            state = AIState.Shooting;
           
        }
        if (enemydist <= 10)
        {
            //state = AIState.Chasing;
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
    void Shooting()
    {

        nav.speed = 0;
        var rotation = Quaternion.LookRotation(player.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 0.5f);
        if (enemy == false)
        {
            Instantiate(enemybullet, bulletpos.transform.position, transform.rotation);
            StartCoroutine(Rapid());
        }

    }


    void Patrolling()
    {
        nav.isStopped = false;

        // Set an appropriate speed for the NavMeshAgent.
        nav.speed = patrolSpeed;
        if (loc==false)
        {
            location();
            loc = true;
        }

        nav.SetDestination(WayPoints.transform.position);


        if (nav.remainingDistance <= nav.stoppingDistance)
        {
            loc = false;
        }
        else
        {

        }



    }

    IEnumerator Rapid()
    {
        enemy = true;
        yield return new WaitForSeconds(1.5f);
        enemy = false;
    }

    void location()
    {
        WayPoints = patrolWayPoints[Random.Range(0, patrolWayPoints.Length)];
    }
}
