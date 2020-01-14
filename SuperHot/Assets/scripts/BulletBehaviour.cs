using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour {

    public float force;
    float actualForce;
    Rigidbody rigid;
    private float speed = 1000f;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        transform.position += transform.forward * TimeManager.GetInstance().myTimeScale;
    }


    private void OnTriggerEnter(Collider other)
    {
        print("hit " + other.name + "!");
        other.gameObject.SendMessageUpwards("ApplyDamage", SendMessageOptions.DontRequireReceiver);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        print("hit " + other.gameObject.name + "!");
        other.gameObject.SendMessageUpwards("ApplyDamage", SendMessageOptions.DontRequireReceiver);
        Destroy(gameObject);
    }
}
