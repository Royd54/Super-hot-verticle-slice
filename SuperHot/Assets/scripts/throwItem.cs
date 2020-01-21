﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class throwItem : MonoBehaviour
{
    public SteamVR_Action_Boolean fireAction;
    private Interactable interactable;
    Rigidbody rigid;

    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private bool dropped;
    [SerializeField] private bool item = true;

    private float timeBetweenShots = 0.5f;
    private float shootCooldown;

    // Start is called before the first frame update
    void Start()
    {
        if(this.gameObject.tag == "nextLevel")
        {
            item = false;
        }
        rigid = GetComponent<Rigidbody>();
        interactable = GetComponent<Interactable>();
        shootCooldown = timeBetweenShots;
    }

    // Update is called once per frame
    void Update()
    {
        if (interactable.attachedToHand != null && item == false)
        {
            interactable.gameObject.GetComponent<nextLevelObj>().setInteracted();
        }
        else
        {
            if (interactable.attachedToHand != null)
            {
                dropped = true;
            }
            else if (interactable.attachedToHand == null && dropped == true)
            {
                gameObject.GetComponent<NewBehaviourScript>().enabled = true;
                gameObject.GetComponent<throwItem>().enabled = false;
            }
        }

    }
}