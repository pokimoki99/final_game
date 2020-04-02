using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bullet : MonoBehaviour
{


    public GameObject bullet;

    public float force = 1000.0f;
    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), GetComponent<Collider>());
        GetComponent<Rigidbody>().AddForce(transform.forward * force);
    }

    void main()
    {
        if (gameObject.transform.position.y <= 0)
        {
            Destroy(gameObject);
        }

    }

    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "Terrain")
        {
            Destroy(gameObject);

        }
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Hit player");
            Destroy(gameObject);
        }
    }
}
