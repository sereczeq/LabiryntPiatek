using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 12f;
    public float gravity = -10;
    CharacterController characterController;

    //sprawdzanie ziemi
    private Vector3 downVelocity; //służy do obliczania brędkości w dół
    public Transform groundCheck; //miejsce na obiekt do sprawdzania
    public LayerMask groundMask; //grupa obiektów, które będą warstwą uznawaną za podłogę
    bool isGrounded;



    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if (move.magnitude > 1) move = move.normalized;

        characterController.Move(move * speed * Time.deltaTime);

        // jest to rozwiązanie na szybko
        //TODO: zmienić to na kolejnych lekcjach
        downVelocity.y += gravity * Time.deltaTime;
        characterController.Move(downVelocity * Time.deltaTime);
    }
}
