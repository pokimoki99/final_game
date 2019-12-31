using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_text : MonoBehaviour
{
    public bool hasCollided;
    public string labelText,type_again;
    EnemyHealth dead;
    int dead_marker;
    public List<string> weapon;
    Weapon_RNG type;

    private void Start()
    {
        dead = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyHealth>();
        type = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Weapon_RNG>();

    }

    public void OnGUI()
    {
        if (hasCollided == true)
        {
            type_again = type.weapon;
            GUI.Label(new Rect(Screen.width / 2, Screen.height / 2.05f, 200, 60), "Weapon : " +type.weapon);
            GUI.Label(new Rect(Screen.width/2, Screen.height/2, 200, 60), "Range : " + labelText +" DPS");
            GUI.Label(new Rect(Screen.width/2, Screen.height/1.75f, 200, 60), "Press E to pick up");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")

        {
            if (dead.death==1)
            {
                weapon.Add(PlayerPrefs.GetString("Legendary", "No Name"));
                weapon.Add(PlayerPrefs.GetString("Epic", "No Name"));
                weapon.Add(PlayerPrefs.GetString("Rare", "No Name"));
                weapon.Add(PlayerPrefs.GetString("Uncommon", "No Name"));
                weapon.Add(PlayerPrefs.GetString("Common", "No Name"));
                if (weapon[0] != "No Name")
                {
                    labelText = weapon[0];
                }
                else if (weapon[1] != "No Name")
                {
                    labelText = weapon[1];
                }
                else if (weapon[2] != "No Name")
                {
                    labelText = weapon[2];
                }
                else if (weapon[3] != "No Name")
                {
                    labelText = weapon[3];
                }
                else if (weapon[4] != "No Name")
                {
                    labelText = weapon[4];
                }
            }
            if (dead.death==2)
            {
                weapon.Add(PlayerPrefs.GetString("Legendary", "No Name"));
                weapon.Add(PlayerPrefs.GetString("Epic", "No Name"));
                weapon.Add(PlayerPrefs.GetString("Rare", "No Name"));
                weapon.Add(PlayerPrefs.GetString("Uncommon", "No Name"));
                weapon.Add(PlayerPrefs.GetString("Common", "No Name"));
                if (weapon[0] != "No Name")
                {
                    labelText = weapon[0];
                }
                else if (weapon[1] != "No Name")
                {
                    labelText = weapon[1];
                }
                else if (weapon[2] != "No Name")
                {
                    labelText = weapon[2];
                }
                else if (weapon[3] != "No Name")
                {
                    labelText = weapon[3];
                }
                else if (weapon[4] != "No Name")
                {
                    labelText = weapon[4];
                }
            }
            if (dead.death == 3)
            {
                weapon.Add(PlayerPrefs.GetString("Legendary", "No Name"));
                weapon.Add(PlayerPrefs.GetString("Epic", "No Name"));
                weapon.Add(PlayerPrefs.GetString("Rare", "No Name"));
                weapon.Add(PlayerPrefs.GetString("Uncommon", "No Name"));
                weapon.Add(PlayerPrefs.GetString("Common", "No Name"));
                if (weapon[0] != "No Name")
                {
                    labelText = weapon[0];
                }
                else if (weapon[1] != "No Name")
                {
                    labelText = weapon[1];
                }
                else if (weapon[2] != "No Name")
                {
                    labelText = weapon[2];
                }
                else if (weapon[3] != "No Name")
                {
                    labelText = weapon[3];
                } 
                else if (weapon[4] != "No Name")
                {
                    labelText = weapon[4];
                }                    

            }
            if (dead.death == 4)
            {
                weapon.Add(PlayerPrefs.GetString("Legendary", "No Name"));
                weapon.Add(PlayerPrefs.GetString("Epic", "No Name"));
                weapon.Add(PlayerPrefs.GetString("Rare", "No Name"));
                weapon.Add(PlayerPrefs.GetString("Uncommon", "No Name"));
                weapon.Add(PlayerPrefs.GetString("Common", "No Name"));
                if (weapon[0] != "No Name")
                {
                    labelText = weapon[0];
                }
                else if (weapon[1] != "No Name")
                {
                    labelText = weapon[1];
                }
                else if (weapon[2] != "No Name")
                {
                    labelText = weapon[2];
                }
                else if (weapon[3] != "No Name")
                {
                    labelText = weapon[3];
                }
                else if (weapon[4] != "No Name")
                {
                    labelText = weapon[4];
                }

            }
            hasCollided = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        hasCollided = false;

    }
}
