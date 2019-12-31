using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_RNG : MonoBehaviour
{
    int rarity,weapon_type;
    public bool rarity_switch = false;
    Vector3 gun;
    float damage, range;

    public GameObject pistol, shotgun, smg, rifle, sniper;

    public EnemyHealth enemy_pos;

    public string weapon;

    // Start is called before the first frame update
    public void Start()
    {

    }

    private void Awake()
    {
        PlayerPrefs.DeleteKey("Legendary");
        PlayerPrefs.DeleteKey("Epic");
        PlayerPrefs.DeleteKey("Rare");
        PlayerPrefs.DeleteKey("Uncommon");
        PlayerPrefs.DeleteKey("Common");
    }

    public void RNG()
    {

        if (rarity_switch == true)
        {
            Weapon_type();
            if (weapon_type == 0)
            {
                Pistol();
                weapon = "Pistol";
                rarity = Random.Range(0, 1000000);
                Random_system();
                rarity_switch = false;
                Debug.Log("pistol");
            }

            else if (weapon_type == 1)
            {
                Shotgun();
                weapon = "Shotgun";
                rarity = Random.Range(0, 1000000);
                Random_system();
                rarity_switch = false;
                Debug.Log("shotgun");
            }

            if (weapon_type == 2)
            {
                SMG();
                weapon = "SMG";
                rarity = Random.Range(0, 1000000);
                Random_system();
                rarity_switch = false;
                Debug.Log("smg");
            }

            if (weapon_type == 3)
            {
                Rifle();
                weapon = "Rifle";
                rarity = Random.Range(0, 1000000);
                Random_system();
                rarity_switch = false;
                Debug.Log("rifle");
            }

            if (weapon_type == 4)
            {
                Sniper();
                weapon = "Sniper";
                rarity = Random.Range(0, 1000000);
                Random_system();
                rarity_switch = false;
                Debug.Log("sniper");
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
        //Debug.Log(rarity);
        if (rarity >= 300000)//Common   (55%)
        {
            COMMON();
        }
        if (rarity >= 100000 && rarity < 300000)//uncommon   (30%)
        {
            UNCOMMON();
        }
        if (rarity >= 50000 && rarity < 100000)//rare    (10%)
        {
            RARE();
        }
        if (rarity >= 2 && rarity < 50000)//epic  (5%)
        {
            EPIC();
        }
        if (rarity > 0 && rarity < 2)//LEGENDARY (0.0001%)
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
        var common = range.ToString() +",\n"+ damage.ToString();
        PlayerPrefs.SetString("Common", common);    //saving weapon stats
        Debug.Log("Common drop");
        Debug.Log(common);
    }
    public void UNCOMMON()
    {
        Range();
        Damage();
        var Uncommon = range.ToString() + ",\n" + damage.ToString();
        PlayerPrefs.SetString("Uncommon", Uncommon);    //saving weapon stats
        Debug.Log("Uncommon drop");
        Debug.Log(Uncommon);
    }
    public void RARE()
    {
        Range();
        Damage();
        var Rare = range.ToString() + ",\n" + damage.ToString();
        PlayerPrefs.SetString("Rare", Rare);    //saving weapon stats
        Debug.Log("Rare drop");
        Debug.Log(Rare);
    }
    public void EPIC()
    {
        Range();
        Damage();
        var Epic = range.ToString() + ",\n" + damage.ToString();
        PlayerPrefs.SetString("Epic", Epic);    //saving weapon stats
        Debug.Log("Epic drop");
        Debug.Log(Epic);
    }
    public void LEGENDARY()
    {
        Range();
        Damage();
        var Legendary = range.ToString() + ",\n" + damage.ToString();
        PlayerPrefs.SetString("Legendary", Legendary);//saving weapon stats
        Debug.Log("Legendary drop");
        Debug.Log(Legendary);
    }

    public void Pistol()
    {
        gun = new Vector3(enemy_pos.enemypos.transform.position.x, enemy_pos.enemypos.transform.position.y + 0.4f, enemy_pos.enemypos.transform.position.z);
        Instantiate(pistol, gun, transform.rotation);
    }
    public void Shotgun()
    {
        gun = new Vector3(enemy_pos.enemypos.transform.position.x, enemy_pos.enemypos.transform.position.y + 0.4f, enemy_pos.enemypos.transform.position.z);
        Instantiate(shotgun, gun, transform.rotation);
    }
    public void SMG()
    {
        gun = new Vector3(enemy_pos.enemypos.transform.position.x, enemy_pos.enemypos.transform.position.y + 0.4f, enemy_pos.enemypos.transform.position.z);
        Instantiate(smg, gun, transform.rotation);

    }
    public void Rifle()
    {
        gun = new Vector3(enemy_pos.enemypos.transform.position.x, enemy_pos.enemypos.transform.position.y + 0.4f, enemy_pos.enemypos.transform.position.z);
        Instantiate(rifle, gun, transform.rotation);
    }
    public void Sniper()
    {
        gun = new Vector3(enemy_pos.enemypos.transform.position.x, enemy_pos.enemypos.transform.position.y + 0.4f, enemy_pos.enemypos.transform.position.z);
        Instantiate(sniper, gun, transform.rotation);
    }
}
