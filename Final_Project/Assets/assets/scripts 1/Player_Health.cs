using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Health : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public float healthRegenAmount;

    public GameObject healthBarUI;
    public Slider slider;

    public int death;

    GameManager gm;

    Player_Vr _dps;

    string type;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        slider.value = CalculateHealth();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        _dps = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Vr>();

    }

    // Update is called once per frame
    void Update()
    {
        slider.value = CalculateHealth();
        if (health < maxHealth)
        {
            healthBarUI.SetActive(true);
            health += healthRegenAmount * Time.deltaTime;

        }
        if (health <= 0)
        {
            //Destroy(gameObject);
            death++;
        }
        if (health > maxHealth)
        {
            health = maxHealth;
        }

        //if (_dps.pick_up)
        //{
        //    type = _dps._type;
        //    if (type == "Health")
        //    {
        //        //health=health+10;
        //    }

        //}



    }
    float CalculateHealth()
    {
        return health / maxHealth;
    }

    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "Enemy_Bullet")
        {
            health = health - 20;
        }
    }
}
