using UnityEngine;
using System.Collections;
using Valve.VR;
using Valve.VR.Extras;
using Valve.VR.InteractionSystem;

public class BulletFireScript : MonoBehaviour
{

    public Transform bulletprefab;
    public GameObject Gun_pos;
    public BulletScript spread;
    Player_Vr _bull;
    Vector3 gun;
    public bool rifle,smg = false;
    


    //VR SETTINGS
    public SteamVR_Action_Boolean GrabGrip;
    public SteamVR_Input_Sources inputSource = SteamVR_Input_Sources.Any;//which controller
    public bool fire;
    PlayerController weapon_type;


    // Use this for initialization
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
        GrabGrip.AddOnStateUpListener(UnPress, inputSource);
        weapon_type = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        //GrabGrip.AddOnStateDownListener(Press, inputSource);

        GrabGrip.AddOnStateUpListener(UnPress, inputSource);
        weapon_type = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();


        if (fire == true && (GameManager.Instance.ammocount > 0))
        //if (fire == true)
        {
            if (weapon_type.sniper==true)
            {
                Instantiate(bulletprefab,Gun_pos.transform.position, transform.rotation);
                GameManager.Instance.fire();
            }
            else if (weapon_type.rifle == true)
            {

            }
            else if (weapon_type.smg == true)
            {

            }
            else if (weapon_type.pistol == true)
            {
                Instantiate(bulletprefab, Gun_pos.transform.position, transform.rotation);
                GameManager.Instance.fire();
            }

        }

        if (fire==true )
        {

            //Debug.Log(weapon_type.rifle);
            if (weapon_type.rifle == true)
            {
                Debug.Log("weaponfire1");
                if (rifle == false)
                {

                    Debug.Log("weaponfire2");
                    spread.shotgun_spread = false;
                    gun = new Vector3(Gun_pos.transform.position.x, Gun_pos.transform.position.y, Gun_pos.transform.position.z);
                    Instantiate(bulletprefab, gun, transform.rotation);
                    GameManager.Instance.fire();
                    StartCoroutine(Rapid_Rifle());
                }

            }
            if (weapon_type.smg == true)
            {
                if (smg == false)
                {
                    spread.shotgun_spread = false;
                    gun = new Vector3(Gun_pos.transform.position.x, Gun_pos.transform.position.y, Gun_pos.transform.position.z);
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
        smg = true;
        yield return new WaitForSeconds(0.01f);
        smg = false;
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
    }

    private void UnPress(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {

        fire = false;
    }
}
