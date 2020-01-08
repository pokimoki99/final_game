using UnityEngine;
using System.Collections;

public class BulletFireScript : MonoBehaviour
{

    public Transform bulletprefab;


    public GameObject Gun_pos;

    public GameObject Shotgun_pos;
    public GameObject Shotgun_pos_1;
    public GameObject Shotgun_pos_2;
    public GameObject Shotgun_pos_3;
    public GameObject Shotgun_pos_4;
    public GameObject Shotgun_pos_5;


    public GameObject Assault_pos;


    public BulletScript spread;
    Player _bull;
    Vector3 gun;
    public bool rifle = false;

    public GameObject Pistol, Shotgun, Rifle, Sniper, SMG;


    // Use this for initialization
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Pistol = GameObject.FindGameObjectWithTag("Pistol");
        Shotgun = GameObject.FindGameObjectWithTag("Shotgun");
        Rifle = GameObject.FindGameObjectWithTag("Rifle");
        Sniper = GameObject.FindGameObjectWithTag("Sniper");
        SMG = GameObject.FindGameObjectWithTag("SMG");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && (GameManager.Instance.ammocount > 0))
        {
            if (Shotgun.activeInHierarchy)
            {
                spread.Assault_rifle_spread = false;
                spread.shotgun_spread = true;


                gun = new Vector3(Shotgun_pos.transform.position.x + 0.5f, Shotgun_pos.transform.position.y + 0.4f, Shotgun_pos.transform.position.z + 0.5f);
                Instantiate(bulletprefab, Shotgun_pos.transform.position, transform.rotation);
                GameManager.Instance.fire();


                gun = new Vector3(Shotgun_pos_1.transform.position.x + 0.45f, Shotgun_pos_1.transform.position.y + 0.4f, Shotgun_pos_1.transform.position.z + 0.5f);
                Instantiate(bulletprefab, Shotgun_pos_1.transform.position, transform.rotation);
                GameManager.Instance.fire();


                gun = new Vector3(Shotgun_pos_2.transform.position.x + 0.55f, Shotgun_pos_2.transform.position.y + 0.4f, Shotgun_pos_2.transform.position.z + 0.5f);
                Instantiate(bulletprefab, Shotgun_pos_2.transform.position, transform.rotation);
                GameManager.Instance.fire();


                gun = new Vector3(Shotgun_pos_3.transform.position.x + 0.5f, Shotgun_pos_3.transform.position.y + 0.45f, Shotgun_pos_3.transform.position.z + 0.5f);
                Instantiate(bulletprefab, Shotgun_pos_3.transform.position, transform.rotation);
                GameManager.Instance.fire();


                gun = new Vector3(Shotgun_pos_4.transform.position.x + 0.5f, Shotgun_pos_4.transform.position.y + 0.35f, Shotgun_pos_4.transform.position.z + 0.5f);
                Instantiate(bulletprefab, Shotgun_pos_4.transform.position, transform.rotation);
                GameManager.Instance.fire();


                gun = new Vector3(Shotgun_pos_5.transform.position.x + 0.55f, Shotgun_pos_5.transform.position.y + 0.45f, Shotgun_pos_5.transform.position.z + 0.5f);
                Instantiate(bulletprefab, Shotgun_pos_5.transform.position, transform.rotation);
                GameManager.Instance.fire();



            }
            else if (Sniper.activeInHierarchy)
            {
                Instantiate(bulletprefab,Gun_pos.transform.position, transform.rotation);
                GameManager.Instance.fire();
            }
            else if (Rifle.activeInHierarchy)
            {

            }
            else if (SMG.activeInHierarchy)
            {

            }
            else if (Pistol.activeInHierarchy)
            {
                Instantiate(bulletprefab, Gun_pos.transform.position, transform.rotation);
                GameManager.Instance.fire();
            }

        }
        if (Input.GetMouseButton(0) && (GameManager.Instance.ammocount > 0))
        {
            if (Rifle.activeInHierarchy)
            {
                if (rifle == false)
                {
                    spread.shotgun_spread = false;
                    gun = new Vector3(Assault_pos.transform.position.x, Assault_pos.transform.position.y, Assault_pos.transform.position.z);
                    Instantiate(bulletprefab, gun, transform.rotation);
                    GameManager.Instance.fire();
                    StartCoroutine(Rapid_Rifle());
                }

            }
            if (SMG.activeInHierarchy)
            {
                if (rifle == false)
                {
                    spread.shotgun_spread = false;
                    gun = new Vector3(Assault_pos.transform.position.x, Assault_pos.transform.position.y, Assault_pos.transform.position.z);
                    Instantiate(bulletprefab, gun, transform.rotation);
                    GameManager.Instance.fire();
                    StartCoroutine(Rapid_SMG());
                }

            }

        }
    }
    IEnumerator Rapid_Rifle()
    {
        rifle = true;
        yield return new WaitForSeconds(0.1f);
        rifle = false;
    } 
    IEnumerator Rapid_SMG()
    {
        rifle = true;
        yield return new WaitForSeconds(0.01f);
        rifle = false;
    }
}
