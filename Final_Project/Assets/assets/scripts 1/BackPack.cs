using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackPack : MonoBehaviour
{

    public bool slot1_on, slot2_on;
    public GameObject slot1, slot2;
    public bool storing;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
    private void OnTriggerStay(Collider other)
    {
        if (storing)
        {
            other.GetComponentInParent<Rigidbody>().useGravity = false;
            if (slot1_on == false)
            {
                //Debug.Log("check");
                //Debug.Log(slot1_on);
                if (other.tag == "Rifle")
                {
                    other.transform.position = slot1.transform.position;
                    slot1_on = true;
                    storing = false;
                    //other.GetComponentInParent<Rigidbody>().useGravity = false;
                }
                if (other.tag == "SMG")
                {
                    other.transform.position = slot1.transform.position;
                    slot1_on = true;
                    storing = false;
                    other.GetComponent<Rigidbody>().isKinematic = true;

                }
                if (other.tag == "Pistol")
                {
                    other.transform.position = slot1.transform.position;
                    slot1_on = true;
                    storing = false;
                    other.GetComponent<Rigidbody>().isKinematic = true;
                }
                if (other.tag == "Shotgun")
                {
                    other.transform.position = slot1.transform.position;
                    slot1_on = true;
                    storing = false;
                    other.GetComponent<Rigidbody>().isKinematic = true;
                }
                if (other.tag == "Sniper")
                {
                    other.transform.position = slot1.transform.position;
                    slot1_on = true;
                    storing = false;
                    other.GetComponent<Rigidbody>().isKinematic = true;
                }
            }

            else if (!slot2_on)
            {
                if (other.tag == "Rifle")
                {
                    other.transform.position = slot2.transform.position;
                    slot2_on = true;
                    storing = false;
                    other.GetComponent<Rigidbody>().isKinematic = true;
                }
                if (other.tag == "SMG")
                {
                    other.transform.position = slot2.transform.position;
                    slot2_on = true;
                    storing = false;
                    other.GetComponent<Rigidbody>().isKinematic = true;
                }
                if (other.tag == "Pistol")
                {
                    other.transform.position = slot2.transform.position;
                    slot2_on = true;
                    storing = false;
                    other.GetComponent<Rigidbody>().isKinematic = true;
                }
                if (other.tag == "Shotgun")
                {
                    other.transform.position = slot2.transform.position;
                    slot2_on = true;
                    storing = false;
                    other.GetComponent<Rigidbody>().isKinematic = true;
                }
                if (other.tag == "Sniper")
                {
                    other.transform.position = slot2.transform.position;
                    slot2_on = true;
                    storing = false;
                    other.GetComponent<Rigidbody>().isKinematic = true;
                }
            }

        }

    }
}
