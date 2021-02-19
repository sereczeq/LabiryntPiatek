using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 12f;
    public float gravity = -10;
    Vector3 downVelocity; //służy do obliczania brędkości w dół
    CharacterController characterController;

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

        characterController.Move(move.normalized * speed * Time.deltaTime);

        // jest to rozwiązanie na szybko
        //TODO: zmienić to na kolejnych lekcjach
        downVelocity.y += gravity * Time.deltaTime;
        characterController.Move(downVelocity * Time.deltaTime);
    }
}
