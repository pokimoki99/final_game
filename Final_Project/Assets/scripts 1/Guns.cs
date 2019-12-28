using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guns : MonoBehaviour
{

    public bool Pistol, SMG, Shotgun, Rifle, Sniper;    //checking gun

    public float Pistoldps, SMGdps, Shotgundps, Rifledps, Sniperdps;    //checking damage

    public float Pistolrange, SMGrange, Shotgunrange, Riflerange, Sniperrange;    //checking damage


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Pistol_check();
        Shotgun_check();
        SMG_check();
        Rifle_check();
        Sniper_check();

        
    }

    public void Pistol_check()
    {
        if (GameObject.FindGameObjectWithTag("Pistol").activeSelf)
        {
            Pistol = true;
            Pistoldps = 20;
            Pistolrange = 250;
        }
        else
        {
            Pistol = false;
        }
    }
    public void Shotgun_check()
    {
        if (GameObject.FindGameObjectWithTag("Shotgun").activeSelf)
        {
            Shotgun = true;
            Shotgundps = 50;
            Shotgunrange = 150;
        }
        else
        {
            Shotgun = false;
        }
    }
    public void Rifle_check()
    {
        if (GameObject.FindGameObjectWithTag("Rifle").activeSelf)
        {
            Rifle = true;
            Rifledps = 30;
            Riflerange = 300;
        }
        else
        {
            Rifle = false;
        }
    }
    public void SMG_check()
    {
        if (GameObject.FindGameObjectWithTag("SMG").activeSelf)
        {
            SMG = true;
            SMGdps = 20;
            SMGrange = 200;
        }
        else
        {
            SMG = false;
        }
    }
    public void Sniper_check()
    {
        if (GameObject.FindGameObjectWithTag("Sniper").activeSelf)
        {
            Sniper = true;
            Sniperdps = 100;
            Sniperrange = 5000;
        }
        else
        {
            Sniper = false;
        }
    }
}
