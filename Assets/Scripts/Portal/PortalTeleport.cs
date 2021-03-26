using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleport : MonoBehaviour
{
    public Transform player;
    public Transform receiver;
    private bool playerIsOverlapping = false;
    private void FixedUpdate()
    {
        //je¿eli gracz nie jest w portalu to nic nie rób
        if (!playerIsOverlapping) return;

        Vector3 portalToPlayer = player.position - transform.position;
        float dotProduct = Vector3.Dot(transform.up, portalToPlayer);

        if(dotProduct < 0f)
        {
            float rotationDifference = -Quaternion.Angle(transform.rotation, receiver.rotation);
            rotationDifference += 180;
            //player.Rotate(transform.up, rotationDifference);
            player.Rotate(Vector3.up, rotationDifference);

            Vector3 positionOffset = Quaternion.Euler(0f, rotationDifference, 0f) * portalToPlayer;
            player.position = receiver.position + positionOffset;

            playerIsOverlapping = false;

            Debug.Log("Teleportuje");
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerIsOverlapping = true;
            //dodatkowo mo¿na dodaæ
            Debug.Log("Gracz w portalu");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsOverlapping = false;
            //dodatkowo mo¿na dodaæ
            Debug.Log("Gracz NIE w portalu");
        }
    }

    //przerwa do 19:33
}
