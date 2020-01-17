using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bouncingBalls : MonoBehaviour
{
    public float force;
    float actualForce;
    Rigidbody rigid;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //rigid.AddForce(Physics.gravity * TimeManager.GetInstance().myTimeScale);

        Vector3 velocity = Physics.gravity * TimeManager.GetInstance().myTimeScale;

        rigid.velocity = velocity;
    }
}
