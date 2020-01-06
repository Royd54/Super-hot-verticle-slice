using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class VRGun : MonoBehaviour
{
    public SteamVR_Action_Boolean fireAction;
    private Interactable interactable;

    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<Interactable>();
    }

    // Update is called once per frame
    void Update()
    {
        if(interactable.attachedToHand != null)
        {
            SteamVR_Input_Sources source = interactable.attachedToHand.handType;
            if (fireAction[source].stateDown)
            {
                Instantiate(bullet, spawnPoint.transform.position, this.transform.rotation);
                // GameObject bulletPrefab = Instantiate(bullet);
                //bulletPrefab.transform.position = spawnPoint.transform.position + spawnPoint.transform.forward;
                // bulletPrefab.transform.forward = spawnPoint.transform.forward;
            }
        }
    }
}
