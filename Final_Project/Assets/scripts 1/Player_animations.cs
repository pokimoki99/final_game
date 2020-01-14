using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_animations : MonoBehaviour
{
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.SetFloat("Speed", 1.1f);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            anim.SetBool("Left_Strafe", true);
            anim.SetBool("IsStrafying", true);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            anim.SetFloat("Speed", 1.1f);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            anim.SetBool("Right_Strafe", true);
            anim.SetBool("IsStrafying", true);
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            anim.SetFloat("Speed",0f);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            anim.SetFloat("Speed", 0);
            anim.SetBool("Left_Strafe", false);
            anim.SetBool("IsStrafying", false);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            anim.SetFloat("Speed", 0);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            anim.SetFloat("Speed", 0);
            anim.SetBool("Right_Strafe", false);
            anim.SetBool("IsStrafying", false);
        }

    }
}
