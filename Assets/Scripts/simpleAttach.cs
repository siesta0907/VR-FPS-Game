using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class simpleAttach : MonoBehaviour
{

    private Interactable interactable;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnHandHoverBegin(Hand hand)
    {

    }
    private void OnHandHoverEnd(Hand hand)
    {

    }
    private void HandHoverUpdate(Hand hand)
    {
        GrabTypes grabType = hand.GetGrabStarting();
        bool isGrabEnding = hand.IsGrabEnding(gameObject);

        if(interactable.attachedToHand == null && grabType != GrabTypes.None)
        {
            hand.AttachObject(gameObject, grabType);
            hand.HoverLock(interactable);
        }
        else if (isGrabEnding)
        {
            hand.DetachObject(gameObject);
            hand.HoverUnlock(interactable);
            
        }
    }
}
