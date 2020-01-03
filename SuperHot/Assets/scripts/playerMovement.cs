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

    [SerializeField] private GameObject rayStart;
    [SerializeField] private GameObject pickupText;

    [SerializeField] private GameObject throwPistol;
    [SerializeField] private GameObject throwCube;

    [SerializeField] private Camera cam;
    private float pickupRange = 5f;
    private int pickuplayerMask;
    [SerializeField] private int type;

    // Start is called before the first frame update
    void Start()
    {
        tm = TimeManager.GetInstance();
        rb = GetComponent<Rigidbody>();
        firstSpeed = speed;
        pickuplayerMask = LayerMask.GetMask("Item");
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
        if (object1.activeInHierarchy == false && object2.activeInHierarchy == false && object3.activeInHierarchy == false)
        {
            ItemPickup();
        }
        else
        {
            pickupText.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            ThrowItem();
        }
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
        RaycastHit hit;
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        if(Physics.Raycast(ray, out hit, pickupRange, pickuplayerMask))
        {
            Debug.Log(hit.collider.tag);
            if(hit.collider.tag == "Item")
            {
                pickupText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.F))
                {
                    //pickupText.SetActive(false);
                    type = hit.collider.gameObject.GetComponent<ObjectPickup>().getObjectTipe();
                    if (type == 1)
                    {
                        hit.collider.gameObject.GetComponent<ObjectPickupAnimation>().focusPlayer();
                        StartCoroutine(gunPickupCooldown(1));
                        Destroy(hit.collider.gameObject, 0.5f);
                    }
                    if (type == 2)
                    {
                        hit.collider.gameObject.GetComponent<ObjectPickupAnimation>().focusPlayer();
                        StartCoroutine(gunPickupCooldown(2));
                        Destroy(hit.collider.gameObject, 0.5f);
                    }
                    if (type == 3)
                    {
                        hit.collider.gameObject.GetComponent<ObjectPickupAnimation>().focusPlayer();
                        StartCoroutine(gunPickupCooldown(3));
                        Destroy(hit.collider.gameObject, 0.5f);
                    }
                }
            }
            else
            {
                pickupText.SetActive(false);
            }
        }
    }

    public void ThrowItem()
    {
        if (object1.activeInHierarchy == true)
        {
            Instantiate(throwPistol, GameObject.Find("WeaponHolder").GetComponent<Transform>().position, this.transform.rotation);
            object1.SetActive(false);
            pickupText.SetActive(false);
        }
        if (object2.activeInHierarchy == true)
        {
            Instantiate(throwCube, GameObject.Find("WeaponHolder").GetComponent<Transform>().position, this.transform.rotation);
            object2.SetActive(false);
            pickupText.SetActive(false);
        }
    }

    IEnumerator gunPickupCooldown(int type2)
    {
        pickupText.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        if (type2 == 1)
        {
            object1.SetActive(true);
            object2.SetActive(false);
            object3.SetActive(false);
        }
        if (type2 == 2)
        {
            object1.SetActive(false);
            object2.SetActive(true);
            object3.SetActive(false);
        }
        if (type2 == 3)
        {
            object1.SetActive(false);
            object2.SetActive(false);
            object3.SetActive(true);
        }
    }

}
