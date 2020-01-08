using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoretext;
    public Text ammotext;

    public int ammocount = 30;

    public int score = 0;

    public bool pistol, shotgun, sniper, rifle, smg = false;


    public static GameObject Pistol, Shotgun, Rifle, Sniper,SMG;

    public GameObject _Pistol, _Shotgun, _Rifle, _Sniper,_SMG;

    // This is a C# property - the code below isn't using it
    // as it is accessing the private static instance directly.
    // Use this property from other classes.
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    private static GameManager instance = null;


    // Use this for initialization
    void Start()
    {
        UpdateScore();

    }

    // Update score text field
    public void UpdateScore()
    {
        scoretext.text = "Score: " + score;
        ammotext.text = "Ammo: " + ammocount;
       
    }
    public void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            ammocount = 0;
            Reload();
        }
        Ammo();
        UpdateScore();
    }

    // set the score
    public void setscore(int s)
    {
        score = s;
        UpdateScore();
    }

    // increase the score
    public void incscore(int s)
    {
        score = score + s;
        UpdateScore();
    }

    void Awake()
    {
        if (instance)
        {
            Debug.Log("already an instance so destroying new one");
            DestroyImmediate(gameObject);
            return;
        }

        instance = this;

        DontDestroyOnLoad(gameObject);

        Pistol = GameObject.FindGameObjectWithTag("Pistol");
        Shotgun = GameObject.FindGameObjectWithTag("Shotgun");
        Rifle = GameObject.FindGameObjectWithTag("Rifle");
        Sniper = GameObject.FindGameObjectWithTag("Sniper");
        SMG = GameObject.FindGameObjectWithTag("SMG");

        _Pistol = Pistol;
        _Shotgun = Shotgun;
        _Rifle = Rifle;
        _Sniper = Sniper;
        _SMG = SMG;


    }

    // fire
    public void fire()
    {
        ammocount--;
        UpdateScore();
    }

    // collect ammo
    public void collectammo()
    {
        ammocount += 10;
        if (ammocount > 100) ammocount = 100;
        UpdateScore();
    }
    public void Ammo()
    {
        if (_Pistol.activeInHierarchy)
        {
            if (pistol == false)
            {
                ammocount = 15;
                pistol = true;
            }
        }
        if (_Shotgun.activeInHierarchy)
        {
            if (shotgun == false)
            {
                ammocount = 28;
                shotgun = true;
            }
        }
        if (_Rifle.activeInHierarchy)
        {

            if (rifle == false)
            {
                ammocount = 40;
                rifle = true;
            }
        }
        if (_Sniper.activeInHierarchy)
        {
            if (sniper == false)
            {
                ammocount = 1;
                sniper = true;
            }
        }
        if (_SMG.activeInHierarchy)
        {
            if (smg == false)
            {
                ammocount = 30;
                smg = true;
            }
        }
    }
    public void Reload()
    {
        StartCoroutine(Reload_mechanic());
    }
    IEnumerator Reload_mechanic()
    {
        //Print the time of when the function is first called.
        //Debug.Log("Started Coroutine at timestamp : " + Time.time);
        yield return new WaitForSeconds(1);
        pistol = true;
        shotgun = true;
        rifle = true;
        sniper = true;
        smg = true;
        //yield on a new YieldInstruction that waits for 1 seconds.
        pistol = false;
        shotgun = false;
        rifle = false;
        sniper = false;
        smg = false;
        yield return new WaitForSeconds(1);

        //After we have waited 2 seconds print the time again.
        //Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
}
