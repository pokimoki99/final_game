using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Boss_AI : MonoBehaviour
{
    public float chaseSpeed = 5f;                           // The nav mesh agent's speed when chasing.

    private UnityEngine.AI.NavMeshAgent nav;                                // Reference to the nav mesh agent.
    private Transform player;                               // Reference to the player's transform.
    private GameObject play;

    public string text;
    public float timeBetweenAttacks = 3.0f;     // The time in seconds between each attack.
    public int attackDamage = 10;               // The amount of health taken away per attack.
    //Playerhp playerHealth;                  // Reference to the player's health.

    float timer=3;                                // Timer for counting up to the next attack.
    enum AIState { Chasing, Attacking };

    AIState state;

    float enemydist;   //how far away is enemy



    public Animator anim;

    int attack;

    //Text messagetext;


    //Colliders
    public GameObject Leg_Sweep;
    public GameObject Swipe;
    public GameObject Cast;
    public GameObject Punch;
    public GameObject Kick;

    void Awake()
    {
        // Setting up the references.
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();

        play = GameObject.FindGameObjectWithTag("Player");

        player = GameObject.FindGameObjectWithTag("Player").transform;

        anim = this.gameObject.GetComponent<Animator>();

        anim.SetBool("IsBattlecry",true);
        StartCoroutine(battlecry_timer());

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
        }
        Debug.Log(timer);
    }


    void Chasing()
    {
        nav.speed = 0;
        //nav.destination = player.transform.position;
        //nav.speed = chaseSpeed;
        //nav.isStopped = false;
    }

    void Attacking()
    {
        if (timer >= timeBetweenAttacks)
        { 

            nav.speed = 0;
            if (attack == 0)
            {
                anim.SetBool("IsAttacking", true);
                anim.SetFloat("attack", 0);
                StartCoroutine(Attack_timer());
                Debug.Log("Leg_Sweep");
                //legsweep
            }
            else if (attack == 1)
            {
                anim.SetBool("IsAttacking", true);
                anim.SetFloat("attack", 0.25f);
                StartCoroutine(Attack_timer());
                Debug.Log("Swipe");
                //clawattack
            }
            else if (attack == 2)
            {
                anim.SetBool("IsAttacking", true);
                anim.SetFloat("attack", 0.5f);
                StartCoroutine(Attack_timer());
                Debug.Log("cast");
                //cast
            }
            else if (attack == 3)
            {
                anim.SetBool("IsAttacking", true);
                anim.SetFloat("attack", 0.75f);
                StartCoroutine(Attack_timer());
                Debug.Log("punch");
                //swipe
            }
            else if (attack == 4)
            {
                anim.SetBool("IsAttacking", true);
                anim.SetFloat("attack", 1);
                StartCoroutine(Attack_timer());
                Debug.Log("kick");
            }



        }
    }

    void attack_type()
    {
        attack = Random.Range(0, 4);
    }

    IEnumerator Attack_timer()
    {
        yield return new WaitForSeconds(2.8f);
        anim.SetBool("IsAttacking", false);
        timer = 0;
        attack_type();
    }
   IEnumerator battlecry_timer()
    {
        yield return new WaitForSeconds(2.8f);
        anim.SetBool("IsBattlecry", false);
        yield return new WaitForSeconds(0.00001f);
        state = AIState.Chasing;
    }

}

