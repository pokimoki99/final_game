using UnityEngine;
using System.Collections;
using Valve.VR;
using Valve.VR.Extras;
using Valve.VR.InteractionSystem;

public class ShotgunFire : MonoBehaviour
{

    public Transform bulletprefab;

    public GameObject Shotgun_pos;
    public GameObject Shotgun_pos_1;
    public GameObject Shotgun_pos_2;
    public GameObject Shotgun_pos_3;
    public GameObject Shotgun_pos_4;
    public GameObject Shotgun_pos_5;

    Player_Vr _bull;
    Vector3 gun;

    //VR SETTINGS
    public SteamVR_Action_Boolean GrabGrip;
    public SteamVR_Input_Sources inputSource = SteamVR_Input_Sources.Any;//which controller
    bool fire;
    SimpleAttach weapon_type;


    // Use this for initialization
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;


        GrabGrip.AddOnStateUpListener(UnPress, inputSource);
        weapon_type = GetComponent<SimpleAttach>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fire == true && (GameManager.Instance.ammocount > 0))
        {
            if (weapon_type.shotgun == true)
            {

                gun = new Vector3(Shotgun_pos.transform.position.x, Shotgun_pos.transform.position.y, Shotgun_pos.transform.position.z);
                Instantiate(bulletprefab, Shotgun_pos.transform.position, transform.rotation);
                GameManager.Instance.fire();


                gun = new Vector3(Shotgun_pos_1.transform.position.x, Shotgun_pos_1.transform.position.y, Shotgun_pos_1.transform.position.z);
                Instantiate(bulletprefab, Shotgun_pos_1.transform.position, transform.rotation);
                GameManager.Instance.fire();


                gun = new Vector3(Shotgun_pos_2.transform.position.x, Shotgun_pos_2.transform.position.y, Shotgun_pos_2.transform.position.z);
                Instantiate(bulletprefab, Shotgun_pos_2.transform.position, transform.rotation);
                GameManager.Instance.fire();


                gun = new Vector3(Shotgun_pos_3.transform.position.x, Shotgun_pos_3.transform.position.y, Shotgun_pos_3.transform.position.z);
                Instantiate(bulletprefab, Shotgun_pos_3.transform.position, transform.rotation);
                GameManager.Instance.fire();


                gun = new Vector3(Shotgun_pos_4.transform.position.x, Shotgun_pos_4.transform.position.y, Shotgun_pos_4.transform.position.z);
                Instantiate(bulletprefab, Shotgun_pos_4.transform.position, transform.rotation);
                GameManager.Instance.fire();


                gun = new Vector3(Shotgun_pos_5.transform.position.x, Shotgun_pos_5.transform.position.y, Shotgun_pos_5.transform.position.z);
                Instantiate(bulletprefab, Shotgun_pos_5.transform.position, transform.rotation);
                GameManager.Instance.fire();


            }

        }
    }
    private void OnEnable()
    {
        GrabGrip.AddOnStateDownListener(Press, inputSource);
    }
    private void OnDisable()
    {
        GrabGrip.AddOnStateUpListener(UnPress, inputSource);
    }
    private void Press(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        fire = true;
        //Instantiate(bulletprefab, firepoint.transform.position, gameObject.transform.rotation);
    }

    private void UnPress(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {

    }
}
