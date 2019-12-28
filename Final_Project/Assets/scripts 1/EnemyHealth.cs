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

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        slider.value = CalculateHealth();
        enemypos.transform.position = gameObject.transform.position;

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
            Destroy(gameObject);
            weapon.RNG();
        }
        if (health>maxHealth)
        {
            health = maxHealth;
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

            Debug.Log("collision");
            health = health - 10.0f;

        }
    }
}
