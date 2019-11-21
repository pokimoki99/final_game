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

    Vector3 gun;
    //public bool shotgun = false;
    //public bool assault_rifle = false;
    // Use this for initialization
    public BulletScript spread;
    // Use this for initialization
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && (GameManager.Instance.ammocount > 0))
        {
            if (spread.shotgun_spread == true)
            {
                //assault_rifle = false;
                gun = new Vector3(Shotgun_pos.transform.position.x, Shotgun_pos.transform.position.y, Shotgun_pos.transform.position.z);
                Instantiate(bulletprefab, gun, transform.rotation);
                GameManager.Instance.fire();

                gun = new Vector3(Shotgun_pos_1.transform.position.x, Shotgun_pos_1.transform.position.y, Shotgun_pos_1.transform.position.z);
                Instantiate(bulletprefab, gun, transform.rotation);
                GameManager.Instance.fire();

                gun = new Vector3(Shotgun_pos_2.transform.position.x, Shotgun_pos_2.transform.position.y, Shotgun_pos_2.transform.position.z);
                Instantiate(bulletprefab, gun, transform.rotation);
                GameManager.Instance.fire();

                gun = new Vector3(Shotgun_pos_3.transform.position.x, Shotgun_pos_3.transform.position.y, Shotgun_pos_3.transform.position.z);
                Instantiate(bulletprefab, gun, transform.rotation);
                GameManager.Instance.fire();

                gun = new Vector3(Shotgun_pos_4.transform.position.x, Shotgun_pos_4.transform.position.y, Shotgun_pos_4.transform.position.z);
                Instantiate(bulletprefab, gun, transform.rotation);
                GameManager.Instance.fire();

                gun = new Vector3(Shotgun_pos_5.transform.position.x, Shotgun_pos_5.transform.position.y, Shotgun_pos_5.transform.position.z);
                Instantiate(bulletprefab, gun, transform.rotation);
                GameManager.Instance.fire();
            }

            else
            {
                gun = new Vector3(Gun_pos.transform.position.x, Gun_pos.transform.position.y, Gun_pos.transform.position.z);
                Instantiate(bulletprefab, gun, transform.rotation);
                GameManager.Instance.fire();
            }

        }
        if (Input.GetMouseButton(0) && (GameManager.Instance.ammocount > 0))
        {
            if (spread.Assault_rifle_spread == true)
            {
                //shotgun = false;
                gun = new Vector3(Gun_pos.transform.position.x, Gun_pos.transform.position.y, Gun_pos.transform.position.z);
                Instantiate(bulletprefab, gun, transform.rotation);
                GameManager.Instance.fire();
            }

        }
    }
}
