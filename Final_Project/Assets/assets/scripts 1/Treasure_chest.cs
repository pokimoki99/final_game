using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure_chest : MonoBehaviour
{

    //weapon drop
    public Weapon_RNG weapon;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Destroy(gameObject);
            weapon.rarity_switch = true;
            weapon.RNG(300000);

        }
    }

}
