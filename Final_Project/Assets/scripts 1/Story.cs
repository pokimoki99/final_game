using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story : MonoBehaviour
{

    public Text Story_text;
    string text;
    int txt;
    int wait;
    // Start is called before the first frame update
    void Start()
    {
        wait = 1;
        txt = 0;
        StartCoroutine("Begin");
    }
    private IEnumerator Begin()
    {
        while (true)
        {
            wait = 1;
            yield return new WaitForSecondsRealtime(0.1f);
            text = "Asuna: Where am I?";
            yield return new WaitForSecondsRealtime(3);
            text = "Asuna: What is going on?"; 
            yield return new WaitForSecondsRealtime(2);
            text = "Asuna: Where is Kazuto ?";
            yield return new WaitForSecondsRealtime(2);
            text = "Asuna : Have the Gods played another prank on us again" + Environment.NewLine + "can you not just leave us alone?";
            yield return new WaitForSecondsRealtime(3);
            text = "Asuna: I need to get out of here and return to Aincrad… " + Environment.NewLine + "easier said than done, where am I?";
            yield return new WaitForSecondsRealtime(2);
            text = "Asuna: Lets figure out my surroundings" + Environment.NewLine + " to see if I can find some clues as to where I am.";
            yield return new WaitForSecondsRealtime(2);
            wait = 0;
            Debug.Log(wait);
            yield return new WaitForSecondsRealtime(0.1f);
            break;
        }
    }

    private IEnumerator Travel()
    {
       
            while (true)
            { 
                yield return new WaitForSecondsRealtime(3);
                wait = 0;
                yield return new WaitForSecondsRealtime(0.1f);
                break;
            }

    }
    // Update is called once per frame
    void Update()
    {
        Story_text.text = text;
        if (wait==0)
        {
            //Debug.Log(wait);
            Traveltxt();
        }
        
    }

    public void Checkpoint_1()
    {
        wait = 1;
        text = "Asuna: OK, I have been attacked by monsters (normal thing that happens daily in my life)," + Environment.NewLine +
            " but the scenary is beautiful… still need to figure out where the exit is.";

        Debug.Log("check1");
        StartCoroutine("Travel");
        Update();
    }
    public void Checkpoint_2()
    {
        wait = 1;
        text = "Asuna: There are two ways to go, I wonder which leads to the exit?";
        StartCoroutine("Travel");
        Debug.Log("check2");
        Update();
    }
    public void Checkpoint_2A()
    {
        wait = 1;
        text = "Asuna: oh, would you look at that, no exit and most likely a trap";
        StartCoroutine("Travel");
        Debug.Log("check2A");
        Update();
    }
    public void Checkpoint_2B()
    {
        wait = 1;
        text = "Hopefully this is the right way, and hopefully no monsters";
        StartCoroutine("Travel");
        Debug.Log("check2B");
        Update();
    }
    public void Checkpoint_3()
    {
        wait = 1;
        text = ": I had to say that didn’t I? (the exit is right after the monster, must get through)" + Environment.NewLine +
            " Its you and Me, Lets see how tough you are!";
        StartCoroutine("Travel");
        Debug.Log("check3");
        Update();

    }
    public void rng()
    {
        txt = (UnityEngine.Random.Range(0, 10));
    }
    public void Traveltxt()
    {
        rng();
        if (txt==0)
        {
            wait = 1;
            text = "Asuna: after this I will continue with my architecture in Olympus";
            StartCoroutine("Travel");
        }
        if (txt==1)
        {
            wait = 1;
            text = "Asuna: I hate spiders! ";
            StartCoroutine("Travel");
        }
        if (txt==2)
        {
            wait = 1;
            text = "Asuna: kazuto where are you?";
            StartCoroutine("Travel");
        }
        if (txt==3)
        {
            wait = 1;
            text = "Asuna: where am I?";
            StartCoroutine("Travel");
        }
        if (txt==4)
        {
            wait = 1;
            text = "Asuna: I seriously hate Hera!";
            StartCoroutine("Travel");
        }
        if (txt==5)
        {
            wait = 1;
            text = "Asuna: I wonder how my family is doing?";
            StartCoroutine("Travel");
        }
        if (txt==6)
        {
            wait = 1;
            text = "Asuna: I wonder how rare are the gold-orange coloured weapons";
            StartCoroutine("Travel");
        }
        if (txt==7)
        {
            wait = 1;
            text = "Asuna: legendary weapons are the best in the world of aincrad";
            StartCoroutine("Travel");
        }
        if (txt==8)
        {
            wait = 1;
            text = "Asuna: my preferred weapon is an smg";
            StartCoroutine("Travel");
        }
        if (txt==9)
        {
            wait = 1;
            text = "Asuna: note to self, bring more ammo";
            StartCoroutine("Travel");
        }
        if (txt==10)
        {
            wait = 1;
            text = "Asuna: explosives always solve problems";
            StartCoroutine("Travel");
        }


    }
}
