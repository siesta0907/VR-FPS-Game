using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class FIreBullet : MonoBehaviour
{
    // Start is called before the first frame update
    public SteamVR_Action_Boolean fireAction;
    public GameObject bullet;
    public Transform spawnPoint;
    public float fireSpeed = 20;

    public AudioClip gunFireSound;
    private Interactable interactable;
    private AudioSource audioSource;

    void Start()
    {
        interactable = GetComponent<Interactable>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (interactable.attachedToHand != null)
        {
            SteamVR_Input_Sources sources = interactable.attachedToHand.handType;
            if (fireAction[sources].stateDown)
            {
                FireBullet();
                audioSource.PlayOneShot(gunFireSound);
            }
        }
        
    }

    public void FireBullet()
    {
        GameObject spawnedBullet = Instantiate(bullet);
        spawnedBullet.transform.position = spawnPoint.position;
        spawnedBullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * fireSpeed;
        Destroy(spawnedBullet, 5);
    }

}
