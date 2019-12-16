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
        rigid.AddForce(Vector3.forward * speed);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //rigid.AddForce(Physics.gravity * TimeManager.GetInstance().myTimeScale);
        rigid.velocity = (Vector3.forward * speed * TimeManager.GetInstance().myTimeScale);
        Vector3 velocity = rigid.velocity * TimeManager.GetInstance().myTimeScale;

        rigid.velocity = velocity;

        //transform.position = Vector3.MoveTowards(transform.position, GameObject.Find("wayponint").transform.position, TimeManager.GetInstance().myTimeScale);
    }
    private void OnTriggerEnter(Collider other)
    {
        print("hit " + other.name + "!");
        Destroy(gameObject);
    }
}
