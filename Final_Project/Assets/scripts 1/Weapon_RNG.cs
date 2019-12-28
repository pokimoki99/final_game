using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_RNG : MonoBehaviour
{
    int rarity,weapon_type;
    public bool rarity_switch = false;
    Vector3 gun;
    float damage, range;

    public EnemyHealth enemy_pos;

    // Start is called before the first frame update
    public void Start()
    {
    }

    public void RNG()
    {

        if (rarity_switch == true)
        {
            Weapon_type();
            Debug.Log(weapon_type);
            if (weapon_type == 0)
            {
                Pistol();
                rarity = Random.Range(0, 100);
                Random_system();
                rarity_switch = false;
            }

            else if (weapon_type == 1)
            {
                Shotgun();
                rarity = Random.Range(0, 100);
                Random_system();
                rarity_switch = false;
            }

            if (weapon_type == 2)
            {
                SMG();
                rarity = Random.Range(0, 100);
                Random_system();
                rarity_switch = false;
            }

            if (weapon_type == 3)
            {
                Rifle();
                rarity = Random.Range(0, 100);
                Random_system();
                rarity_switch = false;
            }

            if (weapon_type == 4)
            {
                Sniper();
                rarity = Random.Range(0, 100);
                Random_system();
                rarity_switch = false;
            }
        }

    }
    public float Damage()
    {
        return damage= Random.Range(0, 100);
    }
    public float Range()
    {
        return range= Random.Range(0, 500);
    }
    public int Weapon_type()
    {
        return weapon_type = Random.Range(0, 4);
    }
    public void Random_system()
    {
        //60+ common
        //30+ Uncommon
        //10+ Rare
        //3+ Epic
        //0+ Legendary
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
        Range();
        Damage();
        var common = range.ToString() +","+ damage.ToString();
        PlayerPrefs.SetString("Common", common);    //saving weapon stats
        Debug.Log("Common drop");
        Debug.Log(common);
    }
    public void UNCOMMON()
    {
        Range();
        Damage();
        var Uncommon = range.ToString() + "," + damage.ToString();
        PlayerPrefs.SetString("Uncommon", Uncommon);    //saving weapon stats
        Debug.Log("Uncommon drop");
        Debug.Log(Uncommon);
    }
    public void RARE()
    {
        Range();
        Damage();
        var Rare = range.ToString() + "," + damage.ToString();
        PlayerPrefs.SetString("Rare", Rare);    //saving weapon stats
        Debug.Log("Rare drop");
        Debug.Log(Rare);
    }
    public void EPIC()
    {
        Range();
        Damage();
        var Epic = range.ToString() + "," + damage.ToString();
        PlayerPrefs.SetString("Epic", Epic);    //saving weapon stats
        Debug.Log("Epic drop");
        Debug.Log(Epic);
    }
    public void LEGENDARY()
    {
        Range();
        Damage();
        var Legendary = range.ToString() + "," + damage.ToString();
        PlayerPrefs.SetString("Legendary", Legendary);//saving weapon stats
        Debug.Log("Legendary drop");
        Debug.Log(Legendary);
    }

    public void Pistol()
    {
        //gun = new Vector3(enemy_pos.enemypos.transform.position.x, enemy_pos.enemypos.transform.position.y + 0.4f, enemy_pos.enemypos.transform.position.z);
        //Instantiate(bulletprefab, gun, transform.rotation);
    }
    public void Shotgun()
    {
        //gun = new Vector3(enemy_pos.enemypos.transform.position.x, enemy_pos.enemypos.transform.position.y + 0.4f, enemy_pos.enemypos.transform.position.z);
        //Instantiate(bulletprefab, gun, transform.rotation);
    }
    public void SMG()
    {
        //gun = new Vector3(enemy_pos.enemypos.transform.position.x, enemy_pos.enemypos.transform.position.y + 0.4f, enemy_pos.enemypos.transform.position.z);
        //Instantiate(bulletprefab, gun, transform.rotation);

    }
    public void Rifle()
    {
        //gun = new Vector3(enemy_pos.enemypos.transform.position.x, enemy_pos.enemypos.transform.position.y + 0.4f, enemy_pos.enemypos.transform.position.z);
        //Instantiate(bulletprefab, gun, transform.rotation);
    }
    public void Sniper()
    {
        //gun = new Vector3(enemy_pos.enemypos.transform.position.x, enemy_pos.enemypos.transform.position.y + 0.4f, enemy_pos.enemypos.transform.position.z);
        //Instantiate(bulletprefab, gun, transform.rotation);
    }
}
