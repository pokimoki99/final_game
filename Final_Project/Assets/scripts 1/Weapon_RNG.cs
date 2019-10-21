using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_RNG : MonoBehaviour
{
    int rarity;
    bool rarity_switch;
    public GameObject Gun_pos;
    public GameObject Enemy_pos;
    Vector3 gun;

    // Start is called before the first frame update
    void Start()
    {
        Enemy_pos = GameObject.FindGameObjectWithTag("Enemy");
    }

    void RNG()
    {
        if (rarity_switch==true)
        {
            rarity = Random.Range(-1, 101);
            rarity_switch = false;
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        //60+ common
        //30+ Uncommon
        //10+ Rare
        //3+ Epic
        //0+ Legendary
        if (rarity>59)//Common
        {
            COMMON();
        }
        if (rarity>29 && rarity<60)//uncommon
        {
            UNCOMMON();
        }
        if (rarity > 9 && rarity < 30)//rare
        {
            RARE();
        }
        if (rarity > 2 && rarity < 10)//epic
        {
            EPIC();
        }
        if (rarity > -1 && rarity < 3)//LEGENDARY
        {
            LEGENDARY();
        }
    }
    public void COMMON()
    {
        gun = new Vector3(Enemy_pos.transform.position.x, Enemy_pos.transform.position.y + 0.4f, Enemy_pos.transform.position.z);
        //Instantiate(bulletprefab, gun, transform.rotation);
    }
    public void UNCOMMON()
    {
        gun = new Vector3(Enemy_pos.transform.position.x, Enemy_pos.transform.position.y + 0.4f, Enemy_pos.transform.position.z);
        //Instantiate(bulletprefab, gun, transform.rotation);
    }
    public void RARE()
    {
        gun = new Vector3(Enemy_pos.transform.position.x, Enemy_pos.transform.position.y + 0.4f, Enemy_pos.transform.position.z);
        //Instantiate(bulletprefab, gun, transform.rotation);
    }
    public void EPIC()
    {
        gun = new Vector3(Enemy_pos.transform.position.x, Enemy_pos.transform.position.y + 0.4f, Enemy_pos.transform.position.z);
        //Instantiate(bulletprefab, gun, transform.rotation);
    }
    public void LEGENDARY()
    {
        gun = new Vector3(Enemy_pos.transform.position.x, Enemy_pos.transform.position.y + 0.4f, Enemy_pos.transform.position.z);
        //Instantiate(bulletprefab, gun, transform.rotation);
    }
}
