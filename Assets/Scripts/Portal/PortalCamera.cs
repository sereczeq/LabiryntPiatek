using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    public Transform playerCamera;
    public Transform portal;
    public Transform otherPortal;
    public float myAngle;

    // Update is called once per frame
    void Update()
    {
        Vector3 portalToPlayer = playerCamera.position - otherPortal.position;
        transform.position = portal.position + portalToPlayer;

        //mo¿na nazwaæ diff ¿eby by³o krócej, ja wolê d³ugie nazwy ;)
        float angularDifferenceBetweenPortalRotations =
            Quaternion.Angle(portal.rotation, otherPortal.rotation);

        //SHIFT + obok entera "\|"
        if(myAngle == 90 || myAngle == 270)
        {
            angularDifferenceBetweenPortalRotations -= 90;
        }

        Quaternion portalRotationDifference =
            Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.up);

        Vector3 newCameraDirection = portalRotationDifference * playerCamera.forward;

        // X i Z s¹ zamienione!
        if(myAngle == 90 || myAngle == 270)
        {
            newCameraDirection =
                new Vector3(newCameraDirection.z * -1, newCameraDirection.y, newCameraDirection.x);
        }
        else
        {
            newCameraDirection =
                new Vector3(newCameraDirection.x * -1, newCameraDirection.y, newCameraDirection.z * -1);
        }
        transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
    }
}
