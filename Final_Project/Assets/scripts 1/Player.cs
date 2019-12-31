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

    UI_text weapon_pick_up;
    Weapon_RNG type;

    public Sprite Pistol_sprite, Shotgun_sprite, Sniper_sprite, Rifle_sprite;

    public string dps, range,_type;
    public bool pick_up;

    // Start is called before the first frame update
    int check;
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
            check = 1;
            if (slot_1.name=="Shotgun")
            {
                GameManager.Instance.shotgun = false;
                GameManager.Instance._Shotgun.SetActive(true);
                GameManager.Instance._Rifle.SetActive(false);
                GameManager.Instance._Sniper.SetActive(false);
                GameManager.Instance._Pistol.SetActive(false);
            }
            else if (slot_1.name=="Rifle")
            {
                GameManager.Instance.rifle = false;
                GameManager.Instance._Rifle.SetActive(true);
                GameManager.Instance._Shotgun.SetActive(false);
                GameManager.Instance._Sniper.SetActive(false);
                GameManager.Instance._Pistol.SetActive(false);
            }
            if (slot_1.name=="Sniper")
            {
                GameManager.Instance.sniper = false;
                GameManager.Instance._Sniper.SetActive(true);
                GameManager.Instance._Shotgun.SetActive(false);
                GameManager.Instance._Rifle.SetActive(false);
                GameManager.Instance._Pistol.SetActive(false);
            }
            if (slot_1.name=="Pistol")
            {
                GameManager.Instance.pistol = false;
                GameManager.Instance._Pistol.SetActive(true);
                GameManager.Instance._Rifle.SetActive(false);
                GameManager.Instance._Shotgun.SetActive(false);
                GameManager.Instance._Sniper.SetActive(false);
            }
            
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            check = 2;
            if (slot_2.name=="Shotgun")
            {
                GameManager.Instance.shotgun = false;
                GameManager.Instance._Shotgun.SetActive(true);
                GameManager.Instance._Rifle.SetActive(false);
                GameManager.Instance._Sniper.SetActive(false);
                GameManager.Instance._Pistol.SetActive(false);
            }
            else if (slot_2.name=="Rifle")
            {
                GameManager.Instance.rifle = false;
                GameManager.Instance._Rifle.SetActive(true);
                GameManager.Instance._Shotgun.SetActive(false);
                GameManager.Instance._Sniper.SetActive(false);
                GameManager.Instance._Pistol.SetActive(false);
            }
            if (slot_2.name=="Sniper")
            {
                GameManager.Instance.sniper = false;
                GameManager.Instance._Sniper.SetActive(true);
                GameManager.Instance._Shotgun.SetActive(false);
                GameManager.Instance._Rifle.SetActive(false);
                GameManager.Instance._Pistol.SetActive(false);
            }
            if (slot_2.name=="Pistol")
            {
                GameManager.Instance.pistol = false;
                GameManager.Instance._Pistol.SetActive(true);
                GameManager.Instance._Rifle.SetActive(false);
                GameManager.Instance._Shotgun.SetActive(false);
                GameManager.Instance._Sniper.SetActive(false);
            }
            
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            weapon_pick_up = GameObject.FindGameObjectWithTag("weapon_pick_up").GetComponent<UI_text>();
            if (weapon_pick_up.hasCollided)
            {
                string damage_range = weapon_pick_up.labelText.Replace("\n", "");
                string[] strArr = damage_range.Split(',');
                dps = strArr[1];
                range= strArr[0];
                _type = weapon_pick_up.type_again;
                Destroy(GameObject.FindGameObjectWithTag("weapon_pick_up"));
                pick_up = true;

                if (_type=="Pistol")
                {
                    if (check==1)
                    {
                        slot_1.name = "Pistol";
                        slot_1.sprite = Pistol_sprite;
                    }
                    else if (check==2)
                    {
                        slot_2.name = "Pistol";
                        slot_2.sprite = Pistol_sprite;
                    }
                }
                else if (_type=="Shotgun")
                {
                    if (check == 1)
                    {
                        slot_1.name = "Shotgun";
                        slot_1.sprite = Shotgun_sprite;
                    }
                    else if (check == 2)
                    {
                        slot_2.name = "Shotgun";
                        slot_2.sprite = Shotgun_sprite;
                    }
                }
                else if (_type=="Rifle")
                {
                    if (check == 1)
                    {
                        slot_1.name = "Rifle";
                        slot_1.sprite = Rifle_sprite;
                    }
                    else if (check == 2)
                    {
                        slot_2.name = "Rifle";
                        slot_2.sprite = Rifle_sprite;
                    }
                }
                else if (_type == "Sniper")
                {
                    if (check == 1)
                    {
                        slot_1.name = "Sniper";
                        slot_1.sprite = Sniper_sprite;
                    }
                    else if (check == 2)
                    {
                        slot_2.name = "Sniper";
                        slot_2.sprite = Sniper_sprite;
                    }
                }
            }
        }

      
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Checkpoint_1")
        {
            _Story_line.Checkpoint_1();
            //Debug.Log("collide");
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
