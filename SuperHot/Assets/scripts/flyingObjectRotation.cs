using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyingObjectRotation : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float AngularSpeed;
    [SerializeField] private bool setter;
    protected Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        speed = rb.velocity.magnitude;
        AngularSpeed = rb.angularVelocity.magnitude;
        if (setter == true)
        {
            rb.AddTorque(transform.forward * TimeManager.GetInstance().myTimeScale * 20);
            rb.AddTorque(transform.right * TimeManager.GetInstance().myTimeScale * 100);
            setter = false;
        }

    }
}
