using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class SimpleAttach : MonoBehaviour
{
    private Interactable interactable;

    protected bool attached = false;

    public BackPack store;

    public PlayerController weapon_type;

    [EnumFlags]
    [Tooltip("The flags used to attach this object to the hand.")]
    public Hand.AttachmentFlags attachmentFlags = Hand.AttachmentFlags.ParentToHand | Hand.AttachmentFlags.DetachFromOtherHand | Hand.AttachmentFlags.TurnOnKinematic;

    public SteamVR_Input_Sources inputSource = SteamVR_Input_Sources.Any;//which controller
    public SteamVR_Action_Boolean GrabPinch;
    public Hand Left_hand;
    public Hand Right_hand;

    public bool shield, sword, pistol, shotgun, rifle, smg, sniper;

    [Tooltip("The local point which acts as a positional and rotational offset to use while held")]
    public Transform attachmentOffset;

    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<Interactable>();
        store = GameObject.FindGameObjectWithTag("backpack").GetComponent<BackPack>();

        weapon_type = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void OnHandHoverBegin(Hand hand)
    {
        hand.ShowGrabHint();
    }
    private void OnHandHoverEnd(Hand hand)
    {
        hand.HideGrabHint();
    }
    private void HandHoverUpdate(Hand hand)
    {

        GrabTypes startingGrabType = hand.GetGrabStarting();

        if (startingGrabType != GrabTypes.None)
        {
            hand.AttachObject(gameObject, startingGrabType, attachmentFlags, attachmentOffset);
            hand.HideGrabHint();

            if (this.gameObject.tag=="Shield")
            {
                weapon_type.shield = true;
            }

            if (this.gameObject.tag=="Sword")
            {
                weapon_type.sword = true;
            }
            if (this.gameObject.tag == "Pistol")
            {
                weapon_type.pistol = true;
            }
            if (this.gameObject.tag == "Shotgun")
            {
                weapon_type.shotgun = true;
            }
            if (this.gameObject.tag == "SMG")
            {
                weapon_type.smg = true;
            }
            if (this.gameObject.tag == "Rifle")
            {
                //Debug.Log("weapon is rifle");
                weapon_type.rifle = true;
            }
            if (this.gameObject.tag == "Sniper")
            {
                weapon_type.sniper = true;
            }

        }

        
    }

    private void Update()
    {
        GrabPinch.AddOnStateUpListener(Press, inputSource);

    }
    private void Press(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        store.storing = true;
            Left_hand.DetachObject(this.gameObject);
            Right_hand.DetachObject(this.gameObject);
        weapon_type.pistol = false;
        weapon_type.shotgun = false;
        weapon_type.rifle = false;
        weapon_type.shotgun = false;
        weapon_type.sniper = false;
        weapon_type.smg = false;
    }

}
