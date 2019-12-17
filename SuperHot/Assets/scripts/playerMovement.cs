using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    TimeManager tm;

    float targetScale;
    float lerpSpeed = 2;

    [SerializeField] private float speed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float raycastDistance;
    [SerializeField] private float firstSpeed;
    [SerializeField] private Rigidbody rb;

    [SerializeField] private GameObject object1;
    [SerializeField] private GameObject object2;
    [SerializeField] private GameObject object3;
    [SerializeField] private GameObject RayStart;

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
            targetScale = 0.4f;
            lerpSpeed = 3;
        }
        else
        {
            targetScale = 0;
            lerpSpeed = 4;
        }
        tm.myTimeScale = Mathf.Lerp(tm.myTimeScale, targetScale, Time.deltaTime * lerpSpeed);

        ItemPickup();
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

    public void ItemPickup()
    {
        Vector3 fwd = RayStart.transform.TransformDirection (Vector3.forward);
        RaycastHit hit;
        Ray ray;
        if(Physics.Raycast(transform.position,fwd, out hit))
        {
            Debug.DrawRay(RayStart.transform.position, Vector3.forward, Color.blue,1000);
            Debug.Log(hit.collider.name);
            if(hit.collider.tag == "Item" && Input.GetKeyDown(KeyCode.F))
            {
               var type = hit.collider.gameObject.GetComponent<ObjectPickup>().getObjectTipe();
                if (type == 1)
                {
                    object1.SetActive(true);
                    object2.SetActive(false);
                    object3.SetActive(false);
                }
                if (type == 2)
                {
                    object1.SetActive(false);
                    object2.SetActive(true);
                    object3.SetActive(false);
                }
                if (type == 3)
                {
                    object1.SetActive(false);
                    object2.SetActive(false);
                    object3.SetActive(true);
                }
            }
        }
    }
}
