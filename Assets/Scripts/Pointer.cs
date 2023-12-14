using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Valve.VR.Extras;
using UnityEngine.UI;

public class Pointer : MonoBehaviour
{
    public SteamVR_LaserPointer laserPointer;

    private void Start()
    {
        laserPointer.PointerClick += PointerClick;
    }

    public void PointerClick(object sender, PointerEventArgs eventArgs)
    {
        if (eventArgs.target.CompareTag("UI"))
        {
            if (eventArgs.target.gameObject.GetComponent<UIManager>().UIName == "Start")
            {
                GameManager.instance.StartGame();
            }
            if (eventArgs.target.gameObject.GetComponent<UIManager>().UIName == "NextStage")
            {
                GameManager.instance.GoNextStage();
            }
            if (eventArgs.target.gameObject.GetComponent<UIManager>().UIName == "Restart")
            {
                GameManager.instance.RestartStage();
            }
        }
    }
    
}
