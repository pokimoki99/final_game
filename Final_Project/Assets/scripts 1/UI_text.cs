using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_text : MonoBehaviour
{
    bool hasCollided;
    string labelText;
    EnemyHealth dead;
    int dead_marker;
    public List<string> weapon;

    private void Start()
    {
        dead = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyHealth>();

    }

    public void OnGUI()
    {
        if (hasCollided == true)
        {
            GUI.Label(new Rect(Screen.width/2, Screen.height/2, 200, 60), "Range : " + labelText +" DPS");
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
