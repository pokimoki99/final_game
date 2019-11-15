using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour
{

    GameManager gm;
    GameObject explosion;
    public GameObject explosionprefab;
    public float force = 500.0f;
    Weapon_RNG _rng;

    // Use this for initialization
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * force);
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
            gm.incscore(10);
            Destroy(gameObject);

        }
        //else if (col.gameObject.tag == "Sphere")
        //{
        //    gm.incscore(20);
        //    Destroy(col.gameObject);// the cube
        //    explosion = Instantiate(explosionprefab, this.transform.position, this.transform.rotation) as GameObject;
        //    Destroy(explosion, 5.0f); // the explosion
        //}

        Destroy(gameObject); // the bullet

    }
    void main()
    {
        if (gameObject.transform.position.y <=0)
        {
            Destroy(gameObject);
        }
        
    }
}
