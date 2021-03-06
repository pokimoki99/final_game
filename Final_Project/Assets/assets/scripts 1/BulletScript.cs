﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BulletScript : MonoBehaviour
{

    GameManager gm;
    GameObject explosion;
    PlayerController _pick;
    

    public GameObject bullet;
    public GameObject explosionprefab;

    public float Shotgun_force = 500.0f;
    public float Pistol_force = 500.0f;
    public float Rifle_force = 500.0f;
    public float Sniper_force = 500.0f;
    public float SMG_force = 500.0f;


    public bool pistol_spread = false;
    public bool shotgun_spread = false;
    public bool Assault_rifle_spread = false;
    public bool sniper_spread = false;
    public bool smg_spread = false;

    //public healthbar _hp;

    //public GameObject Pistol, Shotgun, Rifle, Sniper, Smg;

    Vector3 rand;
    public float range;

    string type;

    public void Awake()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        _pick = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }


    // Use this for initialization
    void Start()
    {
       
        Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), GetComponent<Collider>());

        //Pistol = GameObject.FindGameObjectWithTag("Pistol");
        //Shotgun = GameObject.FindGameObjectWithTag("Shotgun");
        //Rifle = GameObject.FindGameObjectWithTag("Rifle");
        //Sniper = GameObject.FindGameObjectWithTag("Sniper");
        //Smg = GameObject.FindGameObjectWithTag("SMG");

        //if (_pick.pick_up)
        //{
        //    type = _pick._type;
        //    if (type=="Shotgun")
        //    {
        //        Shotgun_force = float.Parse(_pick.range);
        //        _pick.pick_up = false;
        //    }
        //    else if (type=="Rifle")
        //    {
        //        Rifle_force = float.Parse(_pick.range);
        //        _pick.pick_up = false;
        //    }
        //    else if (type=="Sniper")
        //    {
        //        Sniper_force = float.Parse(_pick.range);
        //        _pick.pick_up = false;
        //    }
        //    else if (type=="Pistol")
        //    {
        //        Pistol_force = float.Parse(_pick.range);
        //        _pick.pick_up = false;
        //    }
        //    else if (type=="SMG")
        //    {
        //        SMG_force = float.Parse(_pick.range);
        //        _pick.pick_up = false;
        //    }

        //}

        //if (shotgun_spread == true)
        if (gm._Shotgun.activeInHierarchy|| _pick.shotgun == true)
        {
            GetComponent<Rigidbody>().AddForce(transform.forward * (Shotgun_force - 250.0f));
            //Debug.Log("work?");
            //gm._Pistol.SetActive(false);
            //gm._Sniper.SetActive(false);
            //gm._Rifle.SetActive(false);
            //gm._SMG.SetActive(false);

        }
        if (gm._Sniper.activeInHierarchy|| _pick.sniper == true)
        //else if (sniper_spread == true)
        {
            GetComponent<Rigidbody>().AddForce(transform.forward * (Sniper_force * 3));
            //gm._Pistol.SetActive(false);
            //gm._Shotgun.SetActive(false);
            //gm._Rifle.SetActive(false);
            //gm._SMG.SetActive(false);
        }
        //else if (Assault_rifle_spread == true)
        if (gm._Rifle.activeInHierarchy || _pick.rifle == true)
        {
            //Debug.Log("rifle?");
            GetComponent<Rigidbody>().AddForce(transform.forward * (Rifle_force + 200.0f));
            //gm._Pistol.SetActive(false);
            //gm._Sniper.SetActive(false);
            //gm._Shotgun.SetActive(false);
            //gm._SMG.SetActive(false);
        }
        if (gm._SMG.activeInHierarchy||_pick.smg == true)
        {
            //Debug.Log("rifle?");
            GetComponent<Rigidbody>().AddForce(transform.forward * (SMG_force + 200.0f));
            //gm._Pistol.SetActive(false);
            //gm._Sniper.SetActive(false);
            //gm._Shotgun.SetActive(false);
            //gm._Rifle.SetActive(false);
        }
        //else if (pistol_spread == true)
        if (gm._Pistol.activeInHierarchy || _pick.pistol == true)
        {
            //Debug.Log("pistol?");
            GetComponent<Rigidbody>().AddForce(transform.forward * Pistol_force);
            //gm._Shotgun.SetActive(false);
            //gm._Sniper.SetActive(false);
            //gm._Rifle.SetActive(false);
            //gm._SMG.SetActive(false);
        }
        else
        {

        }

        if (_pick.sword==true)
        {

        }
        if (_pick.shield == true)
        {

        }


    }

    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "Terrain")
        {
            Destroy(gameObject);

        }
        if (col.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);

        }
        if (col.gameObject.tag == "Boss")
        {
            Destroy(gameObject);

        }
        if (col.gameObject.tag == "Player")
        {
            gm.incscore(1);
            Destroy(gameObject);
        }
    }

    void main()
    {
        if (gameObject.transform.position.y <= 0)
        {
            Destroy(gameObject);
        }

    }

}
