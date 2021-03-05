using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float gravity = -10;
    CharacterController characterController;

    //sprawdzanie ziemi
    private Vector3 downVelocity;   //służy do obliczania brędkości w dół
    public Transform groundCheck;   //miejsce na obiekt do sprawdzania
    public LayerMask groundMask;    //grupa obiektów, które będą warstwą uznawaną za podłogę
    bool isGrounded;
    public float rayLength = 0.4f;  //Długość promienia

    //zmiana prędkości
    public float speed;
    public float defaultSpeed = 12f;
    public float fastSpeed = 20f;
    public float slowSpeed = 5f;


    // Start is called before the first frame update
    void Start()
    {
        speed = defaultSpeed;   //domyślne ustalenie prędkości
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Gravity();
        Raycast();
    }

    private void Raycast()
    {
        RaycastHit hit; //zmienna w której zapisywana jest referencja do uderzonego obiektu
        if (Physics.Raycast(groundCheck.position, Vector3.down, out hit, rayLength, groundMask))
        {
            string terrain = hit.collider.gameObject.tag;

            switch(terrain)
            {
                case "FastGround":
                    speed = fastSpeed;
                    break;
                case "SlowGround":
                    speed = slowSpeed;
                    break;
                default:
                    speed = defaultSpeed;
                    break;
            }
        }
    }

    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if (move.magnitude > 1) move = move.normalized;

        characterController.Move(move * speed * Time.deltaTime);
    }

    private void Gravity()
    {
        downVelocity.y += gravity * Time.deltaTime;
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.2f, groundMask);
        if (isGrounded && downVelocity.y < 0)
        {
            downVelocity.y = -2;
        }

        characterController.Move(downVelocity * Time.deltaTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Pickup"))
        {
            other.gameObject.GetComponent<Pickup>().Picked();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(groundCheck.position, 0.2f);
    }


}
