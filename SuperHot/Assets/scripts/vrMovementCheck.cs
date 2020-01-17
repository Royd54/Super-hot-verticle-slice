using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class vrMovementCheck : MonoBehaviour
{
    private TimeManager tm;

    float targetScale;
    float lerpSpeed = 2;
    [SerializeField] private GameObject timeManager;
    [SerializeField] private float speed;
    [SerializeField] private float firstSpeed;
    [SerializeField] private Rigidbody rb;
    [SerializeField] Camera vrCam;
    [SerializeField] Transform firstRot;
    [SerializeField] Transform secondRot;
    // Start is called before the first frame update
    void Start()
    {
        tm = TimeManager.GetInstance();
        rb = GetComponent<Rigidbody>();
        firstSpeed = speed;
        //firstRot = vrCam.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        if (Input.anyKey)
        {
            targetScale = 0.3f;
            lerpSpeed = 3;
        }
        else
        {
            targetScale = 0.025f;
            lerpSpeed = 2;
        }
        tm.myTimeScale = Mathf.Lerp(tm.myTimeScale, targetScale, Time.deltaTime * lerpSpeed);
    }
}
