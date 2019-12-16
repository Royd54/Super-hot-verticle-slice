using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    TimeManager tm;

    float targetScale;
    float lerpSpeed = 2;

    public float speed;
    public float runSpeed;
    public float jumpForce;
    public float raycastDistance;
    private float firstSpeed;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        tm = TimeManager.GetInstance();
        rb = GetComponent<Rigidbody>();
        firstSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        if (mouseX != 0 && mouseY != 0)
        {
            targetScale = 0.2f;
            lerpSpeed = 3;
        }

        if (Input.anyKey)
        {
            targetScale = 0.2f;
            lerpSpeed = 3;
        }
        else
        {
            targetScale = 0;
            lerpSpeed = 4;
        }
        tm.myTimeScale = Mathf.Lerp(tm.myTimeScale, targetScale, Time.deltaTime * lerpSpeed);

    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = runSpeed;
        }
        else
        {
            speed = firstSpeed;
        }

        float hAxis = Input.GetAxisRaw("Horizontal");
        float vAxis = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(hAxis, 0, vAxis) * speed * Time.fixedDeltaTime;

        Vector3 newPosition = rb.position + rb.transform.TransformDirection(movement);

        rb.MovePosition(newPosition);
    }
}
