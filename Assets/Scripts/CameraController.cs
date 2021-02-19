﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Camera controller a nie player controller
public class CameraController : MonoBehaviour
{
    public float mouseSensivity = 100f; //czułość myszy

    //tutaj ma być public jednak :c
    public Transform playerBody; //referencja do naszego gracza, obrót kamery
                                  // będzie obracał naszym graczem

    private float xRotation = 0f; //obrót względem osi x kamery


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerBody = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 80f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

    }
}
