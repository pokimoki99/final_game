using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backpack_removal : MonoBehaviour
{
    Collider collider_check;
    BackPack removal;
    Vector3 simple;
    // Start is called before the first frame update
    void Start()
    {
        collider_check = GetComponent<Collider>();
        removal = GetComponentInParent<BackPack>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (collider_check.bounds.Contains(simple) == true)
        //{
        //    if (this.gameObject.name == "Slot1")
        //    {
        //        removal.slot1_on = false;
        //        //Debug.Log("is empty");
        //    }
        //    if (this.gameObject.name == "Slot2")
        //    {
        //        removal.slot2_on = false;

        //        //Debug.Log("is empty2");
        //    }
        //}
    }

    private void OnTriggerStay(Collider other)
    {
        if (collider_check.bounds.Contains(other.transform.position) == false)
        {
            if (this.gameObject.name == "Slot1")
            {
                removal.slot1_on = false;
                //Debug.Log("is empty");
            }
            if (this.gameObject.name == "Slot2")
            {
                removal.slot2_on = false;

                //Debug.Log("is empty2");
            }
        }
    }
}
