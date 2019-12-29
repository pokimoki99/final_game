using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public Image slot_1,slot_2;

    // Start is called before the first frame update
    void Start()
    {
        //pistol.GetComponentInChildren<Renderer>().enabled = false;
        //shotgun.GetComponentInChildren<Renderer>().enabled = false;
        //rifle.GetComponentInChildren<Renderer>().enabled = false;
        //sniper.GetComponentInChildren<Renderer>().enabled = false;

        _pistol = pistol;

        spread.pistol_spread = false;
        spread.shotgun_spread = false;
        spread.Assault_rifle_spread = false;
        spread.sniper_spread = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            if (slot_1.name=="Shotgun")
            {
                GameManager.Instance._Shotgun.SetActive(true);
                GameManager.Instance._Rifle.SetActive(false);
                GameManager.Instance._Sniper.SetActive(false);
                GameManager.Instance._Pistol.SetActive(false);
            }
            else if (slot_1.name=="Rifle")
            {
                GameManager.Instance._Rifle.SetActive(true);
                GameManager.Instance._Shotgun.SetActive(false);
                GameManager.Instance._Sniper.SetActive(false);
                GameManager.Instance._Pistol.SetActive(false);
            }
            if (slot_1.name=="Sniper")
            {
                GameManager.Instance._Sniper.SetActive(true);
                GameManager.Instance._Shotgun.SetActive(false);
                GameManager.Instance._Rifle.SetActive(false);
                GameManager.Instance._Pistol.SetActive(false);
            }
            if (slot_1.name=="Pistol")
            {
                GameManager.Instance._Pistol.SetActive(true);
                GameManager.Instance._Rifle.SetActive(false);
                GameManager.Instance._Shotgun.SetActive(false);
                GameManager.Instance._Sniper.SetActive(false);
            }
            
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            if (slot_2.name=="Shotgun")
            {
                GameManager.Instance._Shotgun.SetActive(true);
                GameManager.Instance._Rifle.SetActive(false);
                GameManager.Instance._Sniper.SetActive(false);
                GameManager.Instance._Pistol.SetActive(false);
            }
            else if (slot_2.name=="Rifle")
            {
                GameManager.Instance._Rifle.SetActive(true);
                GameManager.Instance._Shotgun.SetActive(false);
                GameManager.Instance._Sniper.SetActive(false);
                GameManager.Instance._Pistol.SetActive(false);
            }
            if (slot_2.name=="Sniper")
            {
                GameManager.Instance._Sniper.SetActive(true);
                GameManager.Instance._Shotgun.SetActive(false);
                GameManager.Instance._Rifle.SetActive(false);
                GameManager.Instance._Pistol.SetActive(false);
            }
            if (slot_2.name=="Pistol")
            {
                GameManager.Instance._Pistol.SetActive(true);
                GameManager.Instance._Rifle.SetActive(false);
                GameManager.Instance._Shotgun.SetActive(false);
                GameManager.Instance._Sniper.SetActive(false);
            }
            
        }
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
