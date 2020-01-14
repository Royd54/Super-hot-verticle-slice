﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private GameObject player;

    private float timeBetweenShots = 0.5f;
    private float shootCooldown;

    [SerializeField] private GameObject crosshair;
    [SerializeField] private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        shootCooldown = 0;
    }

    // Update is called once per frame
    void Update()
    {
        anim.speed = TimeManager.GetInstance().myTimeScale * 2;
        if (shootCooldown > 0)
        {
            anim.SetBool("Shot", false);
            shootCooldown -= Time.deltaTime * TimeManager.GetInstance().myTimeScale;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && shootCooldown < Time.deltaTime)
        {
            Instantiate(bullet, spawnPoint.transform.position, this.transform.rotation);
            anim.SetBool("Shot", true);
            shootCooldown = timeBetweenShots;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && shootCooldown < Time.deltaTime)
        {

        }

    }

}
