using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BulletScript : MonoBehaviour
{

    GameManager gm;
    GameObject explosion;
    

    public GameObject bullet;
    public GameObject explosionprefab;

    public float force = 500.0f;


    public bool pistol_spread = false;
    public bool shotgun_spread = false;
    public bool Assault_rifle_spread = false;
    public bool sniper_spread = false;

    //public healthbar _hp;

    public GameObject Pistol, Shotgun, Rifle, Sniper;

    Vector3 rand;
    public float damage;

    // Use this for initialization
    void Start()
    {
        Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), GetComponent<Collider>());

        Pistol = GameObject.FindGameObjectWithTag("Pistol");
        Shotgun = GameObject.FindGameObjectWithTag("Shotgun");
        Rifle = GameObject.FindGameObjectWithTag("Rifle");
        Sniper = GameObject.FindGameObjectWithTag("Sniper");

        //if (shotgun_spread == true)
        if (GameManager.Instance.Shotgun.activeInHierarchy)
        {
            GetComponent<Rigidbody>().AddForce(transform.forward * (force - 250.0f));
            Debug.Log("work?");
            Pistol.SetActive(false);

        }
        if (Sniper.activeInHierarchy)
        //else if (sniper_spread == true)

        {
            GetComponent<Rigidbody>().AddForce(transform.forward * (force * 10));
        }
        //else if (Assault_rifle_spread == true)
        if (Rifle.activeInHierarchy)
        {
            Debug.Log("rifle?");
            GetComponent<Rigidbody>().AddForce(transform.forward * (force + 200.0f));
        }
        //else if (pistol_spread == true)
        if (Pistol.activeInHierarchy)
        {
            //Debug.Log("pistol?");
            GetComponent<Rigidbody>().AddForce(transform.forward * force);
        }
        else
        {
            Debug.Log("something else?");
            GetComponent<Rigidbody>().AddForce(transform.forward * force);
        }

        gm = GameObject.Find("GameManager").GetComponent<GameManager>();


    }

    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "Terrain")
        {
            Destroy(gameObject);

        }
        if (col.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);

        }
        if (col.gameObject.tag == "Player")
        {
            gm.incscore(1);
            Destroy(gameObject);
        }
    }

    void main()
    {
        if (gameObject.transform.position.y <= 0)
        {
            Destroy(gameObject);
        }

    }
    public void random()
    {
        rand = new Vector3(0, Random.Range(0.0f, 1.0f), 0);
    }
    public void gun_stats()
    {
        damage  = Random.Range(0.0f, 10.0f);
    }
}
