using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour
{

    GameManager gm;
    GameObject explosion;
    public GameObject explosionprefab;
    public float force = 500.0f;
    public bool shotgun_spread = false;
    public bool Assault_rifle_spread = false;
    Weapon_RNG _rng;
    Vector3 rand;

    // Use this for initialization
    void Start()
    {
        Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), GetComponent<Collider>());
        if (shotgun_spread == true)
        {
            //GetComponent<Rigidbody>().AddForce((transform.forward+rand) * force);
            //GetComponent<Rigidbody>().AddForce(rand * force);
            //bullet.transform.Rotate(0.0f,bullet.transform.rotation.y + 10.0f,0.0f);
            Debug.Log("shotgun?");
            GetComponent<Rigidbody>().AddForce(transform.forward * force);

        }
        else if(Assault_rifle_spread == true)
        {
            Debug.Log("rifle?");
            GetComponent<Rigidbody>().AddForce(transform.forward * force);
        }

        else
        {
            GetComponent<Rigidbody>().AddForce(transform.forward * force);
        }
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        _rng = GameObject.Find("GameManager").GetComponent<Weapon_RNG>();
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            //gm.incscore(10);
            //Destroy(col.gameObject);// the cube
            //explosion = Instantiate(explosionprefab, this.transform.position, this.transform.rotation) as GameObject;
            //Destroy(explosion, 5.0f); // the explosion
            _rng.rarity_switch = true;
            _rng.Random_system();
        }
        if (col.gameObject.tag == "Terrain")
        {
            Destroy(gameObject);

        }


        //Destroy(gameObject); // the bullet

    }
    void main()
    {
        if (gameObject.transform.position.y <=0)
        {
            //Destroy(gameObject);
        }
        
    }
    public void random()
    {
        rand = new Vector3(0, Random.Range(0.0f, 1.0f), 0);
    }
}
