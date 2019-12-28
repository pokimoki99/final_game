using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Story _Story_line;

    public int score = 0;
    public BulletScript spread;
    public GameObject pistol;
    public GameObject shotgun;
    public GameObject rifle;
    public GameObject sniper;
    public GameObject bullet;

    static GameObject _pistol;

    // Start is called before the first frame update
    void Start()
    {
        pistol.GetComponentInChildren<Renderer>().enabled = false;
        shotgun.GetComponentInChildren<Renderer>().enabled = false;
        rifle.GetComponentInChildren<Renderer>().enabled = false;
        sniper.GetComponentInChildren<Renderer>().enabled = false;

        _pistol = pistol;

        spread.pistol_spread = false;
        spread.shotgun_spread = false;
        spread.Assault_rifle_spread = false;
        spread.sniper_spread = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.K))
        {
            score = 1;
            GameManager.Instance.setscore(1);
        }
        if (Input.GetKey(KeyCode.L))
        {
            score = 0;
            GameManager.Instance.setscore(0);
        }
        if (Input.GetKey(KeyCode.J))
        {
            score = 2;
            GameManager.Instance.setscore(2);
        }
        if (Input.GetKey(KeyCode.H))
        {
            score = 3;
            GameManager.Instance.setscore(3);
        }
        if (score == 0)
        {
            pistol.GetComponentInChildren<Renderer>().enabled = true;
            //GameManager.Instance.Ammo()
            spread.pistol_spread = true;
            spread.shotgun_spread = false;
            spread.Assault_rifle_spread = false;
            spread.sniper_spread = false;

        }
        if (score == 1)
        {
            spread.pistol_spread = false;
            spread.shotgun_spread = true;
            spread.Assault_rifle_spread = false;
            spread.sniper_spread = false;

        }
        if (score == 2)
        {
            spread.Assault_rifle_spread = true;
            spread.shotgun_spread = false;
            spread.pistol_spread = false;
            spread.sniper_spread = false;
        }
        if (score == 3)
        {
            spread.sniper_spread = true;
            spread.Assault_rifle_spread = false;
            spread.shotgun_spread = false;
            spread.pistol_spread = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Checkpoint_1")
        {
            _Story_line.Checkpoint_1();
            Debug.Log("collide");
        }
        //Destory(other.gameOject);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Checkpoint_1")
        {
            Destroy(other.gameObject);
            Enemy_spawner._enemy_spawn.spawn();
            Enemy_spawner._enemy_spawn.spawn();
            Enemy_spawner._enemy_spawn.spawn();
        }

    }

}
