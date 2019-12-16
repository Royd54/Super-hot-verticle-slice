using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(bullet, spawnPoint.transform.position, this.transform.rotation);
           // GameObject bulletPrefab = Instantiate(bullet);
            //bulletPrefab.transform.position = spawnPoint.transform.position + spawnPoint.transform.forward;
           // bulletPrefab.transform.forward = spawnPoint.transform.forward;
        }
    }
}
