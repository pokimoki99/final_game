using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_RNG : MonoBehaviour
{
    int rarity;
    public bool rarity_switch = false;
    Vector3 gun;

    public EnemyHealth enemy_pos;

    // Start is called before the first frame update
    public void Start()
    {
    }

    public void RNG()
    {
        if (rarity_switch == true)
        {
            rarity = Random.Range(0, 100);
            //rarity = Random.Range(0, 1000000);
            Random_system();
            rarity_switch = false;
        }

    }
    public void Random_system()
    {
        //60+ common
        //30+ Uncommon
        //10+ Rare
        //3+ Epic
        //0+ Legendary
        RNG();
        Debug.Log(rarity);
        if (rarity > 59)//Common
        {
            COMMON();
        }
        if (rarity > 29 && rarity < 60)//uncommon
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
    // Update is called once per frame
    public void Update()
    {

    }
    public void COMMON()
    {
        gun = new Vector3(enemy_pos.enemypos.transform.position.x, enemy_pos.enemypos.transform.position.y + 0.4f, enemy_pos.enemypos.transform.position.z);
        //Instantiate(bulletprefab, gun, transform.rotation);
        Debug.Log("Common drop");
    }
    public void UNCOMMON()
    {
        gun = new Vector3(enemy_pos.enemypos.transform.position.x, enemy_pos.enemypos.transform.position.y + 0.4f, enemy_pos.enemypos.transform.position.z);
        //Instantiate(bulletprefab, gun, transform.rotation);
        Debug.Log("Uncommon drop");
    }
    public void RARE()
    {
        gun = new Vector3(enemy_pos.enemypos.transform.position.x, enemy_pos.enemypos.transform.position.y + 0.4f, enemy_pos.enemypos.transform.position.z);
        //Instantiate(bulletprefab, gun, transform.rotation);
        Debug.Log("Rare drop");
    }
    public void EPIC()
    {
        gun = new Vector3(enemy_pos.enemypos.transform.position.x, enemy_pos.enemypos.transform.position.y + 0.4f, enemy_pos.enemypos.transform.position.z);
        //Instantiate(bulletprefab, gun, transform.rotation);
        Debug.Log("Epic drop");
    }
    public void LEGENDARY()
    {
        gun = new Vector3(enemy_pos.enemypos.transform.position.x, enemy_pos.enemypos.transform.position.y + 0.4f, enemy_pos.enemypos.transform.position.z);
        //Instantiate(bulletprefab, gun, transform.rotation);
        Debug.Log("Legendary drop");
    }
}
