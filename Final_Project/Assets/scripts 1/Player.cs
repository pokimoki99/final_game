using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Story _Story_line;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Checkpoint_1")
        {
            _Story_line.Checkpoint_1();
            Debug.Log("collide");
        }
        //Destory(other.gameOject);
    }

}
