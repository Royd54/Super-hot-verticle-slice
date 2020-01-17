using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    Rigidbody rigid;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        rigid.useGravity = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //gameObject.transform.LookAt(gameObject.transform);
        transform.position += transform.localPosition * TimeManager.GetInstance().myTimeScale / 25;
        rigid.angularVelocity = rigid.angularVelocity * TimeManager.GetInstance().myTimeScale;
        rigid.velocity = rigid.velocity * TimeManager.GetInstance().myTimeScale;
    }
}
