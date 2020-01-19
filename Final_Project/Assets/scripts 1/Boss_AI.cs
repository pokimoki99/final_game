using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Boss_AI : MonoBehaviour
{
    public float chaseSpeed = 5f;                           // The nav mesh agent's speed when chasing.

    private UnityEngine.AI.NavMeshAgent nav;                                // Reference to the nav mesh agent.
    private Transform player;                               // Reference to the player's transform.
    private GameObject play;

    private GameManager GameManager;
    public string text;
    public float timeBetweenAttacks = 0.9f;     // The time in seconds between each attack.
    public int attackDamage = 10;               // The amount of health taken away per attack.
    //Playerhp playerHealth;                  // Reference to the player's health.

    float timer;                                // Timer for counting up to the next attack.
    enum AIState { Chasing, Attacking };

    AIState state;

    float enemydist;   //how far away is enemy
    bool enemy;
    bool loc;


    public Animator anim;
    float speed;
    bool afk;
    int idle_anim_selector;

    //Text messagetext;

    void Awake()
    {
        // Setting up the references.
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();

        play = GameObject.FindGameObjectWithTag("Player");

        player = GameObject.FindGameObjectWithTag("Player").transform;

        anim = this.gameObject.GetComponent<Animator>();

        state = AIState.Chasing;

        //messagetext = GameObject.Find("MessageText").GetComponent<Text>();

    }


    void Update()
    {
        // Add the time since Update was last called to the timer.
        timer += Time.deltaTime;

        switch (state)
        {
            case AIState.Chasing:
                Chasing();
                break;
            case AIState.Attacking:
                Attacking();
                break;
        }

        enemydist = Vector3.Distance(player.transform.position, transform.position);

        if (enemydist <= 20)
        {
            state = AIState.Chasing;

        }

        if (timer >= timeBetweenAttacks && enemydist <= 5)
        {

            state = AIState.Attacking;
            timer = 0;

        }

    }


    void Chasing()
    {
        nav.destination = player.transform.position;
        nav.speed = chaseSpeed;
        nav.isStopped = false;
    }

    void Attacking()
    {
        nav.speed = 0;

    }

}

