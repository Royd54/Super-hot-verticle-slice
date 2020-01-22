using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletBehaviouVR : MonoBehaviour
{


    public float force;
    float actualForce;
    Rigidbody rigid;
    private float speed = 1000f;
    [SerializeField] private GameObject enemyHitParticle;
    public bool item = false;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (!item)
        {
            transform.position += transform.forward * Time.timeScale;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Map")
        {
            print("hit " + other.name + "!");
            Instantiate(enemyHitParticle, this.transform.position, Quaternion.identity);
            other.gameObject.SendMessageUpwards("ApplyDamage", SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Map")
        {
            print("hit " + other.gameObject.name + "!");
            other.gameObject.SendMessageUpwards("ApplyDamage", SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject);
        }
    }
}

