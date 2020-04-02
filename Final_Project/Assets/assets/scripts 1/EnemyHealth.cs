using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;

    public GameObject healthBarUI;
    public Slider slider;
    public GameObject enemypos;

    //weapon drop
    public Weapon_RNG weapon;

    public int death;

    GameManager gm;

    PlayerController weapon_type;
    public float Shotgun_dps = 20;
    public float Pistol_dps = 30;
    public float Rifle_dps = 5;
    public float Smg_dps = 5;
    public float Sniper_dps = 90;

    string type;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        slider.value = CalculateHealth();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        weapon_type = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        slider.value = CalculateHealth();
        if (health<maxHealth)
        {
            healthBarUI.SetActive(true);
        }
        if (health<=0)
        {
            enemypos.transform.position = gameObject.transform.position;
            weapon.rarity_switch = true;
            weapon.RNG(10);
            Destroy(gameObject);
            death++;
        }
        if (health>maxHealth)
        {
            health = maxHealth;
        }

        //if (_dps.pick_up)
        //{
        //    type = _dps._type;
        //    //if (type == "Shotgun")
        //    //{
        //    //    Shotgun_dps = float.Parse(_dps.dps);
        //    //    _dps.pick_up = false;
        //    //}
        //    //else if (type == "Rifle")
        //    //{
        //    //    Rifle_dps = float.Parse(_dps.dps);
        //    //    _dps.pick_up = false;
        //    //}
        //    //else if (type == "Sniper")
        //    //{
        //    //    Sniper_dps = float.Parse(_dps.dps);
        //    //    _dps.pick_up = false;
        //    //}
        //    //else if (type == "Pistol")
        //    //{
        //    //    Pistol_dps = float.Parse(_dps.dps);
        //    //    _dps.pick_up = false;
        //    //}
        //    //else if (type == "SMG")
        //    //{
        //    //    Smg_dps = float.Parse(_dps.dps);
        //    //    _dps.pick_up = false;
        //    //}

        //}



    }
    float CalculateHealth()
    {
        return health / maxHealth;
    }

    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "Bullet")
        {
            if (weapon_type.shotgun == true)
            {
                health = health - Shotgun_dps;
            }
            if (weapon_type.sniper == true)
            {
                health = health - Sniper_dps;
            }
            if (weapon_type.rifle == true)
            {
                health = health - Rifle_dps;
            }
            if (weapon_type.pistol == true)
            {
                health = health - Pistol_dps;
            }
            if (weapon_type.smg == true)
            {
                health = health - Smg_dps;
            }


        }
    }
}
