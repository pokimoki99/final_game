using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_Health : MonoBehaviour
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

    Player _dps;
    public float Shotgun_dps = 20;
    public float Pistol_dps = 30;
    public float Rifle_dps = 5;
    public float Sniper_dps = 90;

    string type;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        slider.value = CalculateHealth();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        _dps = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

    }

    // Update is called once per frame
    void Update()
    {
        slider.value = CalculateHealth();
        if (health < maxHealth)
        {
            healthBarUI.SetActive(true);
        }
        if (health <= 0)
        {
            enemypos.transform.position = gameObject.transform.position;
            weapon.rarity_switch = true;
            weapon.RNG(-300000);
            Destroy(gameObject);
            death++;
        }
        if (health > maxHealth)
        {
            health = maxHealth;
        }

        if (_dps.pick_up)
        {
            type = _dps._type;
            if (type == "Shotgun")
            {
                Shotgun_dps = float.Parse(_dps.dps);
                _dps.pick_up = false;
            }
            else if (type == "Rifle")
            {
                Rifle_dps = float.Parse(_dps.dps);
                _dps.pick_up = false;
            }
            else if (type == "Sniper")
            {
                Sniper_dps = float.Parse(_dps.dps);
                _dps.pick_up = false;
            }
            else if (type == "Pistol")
            {
                Pistol_dps = float.Parse(_dps.dps);
                _dps.pick_up = false;
            }

        }



    }
    float CalculateHealth()
    {
        return health / maxHealth;
    }

    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "Bullet")
        {
            if (gm._Shotgun.activeInHierarchy)
            {
                health = health - Shotgun_dps;
            }
            if (gm._Sniper.activeInHierarchy)
            {
                health = health - Sniper_dps;
            }
            if (gm._Rifle.activeInHierarchy)
            {
                health = health - Rifle_dps;
            }
            if (gm._Pistol.activeInHierarchy)
            {
                health = health - Pistol_dps;
            }


        }
    }
}
