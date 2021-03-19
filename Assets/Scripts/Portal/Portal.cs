using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject player;
    public Camera myCamera;
    public Transform myRenderPlane;
    public Transform myColliderPlane;

    public Portal otherPortal;
    PortalCamera portalCamera;
    PortalTeleport portalTeleport;

    public Material material;
    float myAngle;

    // Awake w³¹cza siê wczeœniej ni¿ Start
    void Awake()
    {
        portalCamera = myCamera.GetComponent<PortalCamera>();
        portalTeleport = myColliderPlane.gameObject.GetComponent<PortalTeleport>();
        // gameObject NIE gameObjectS!!!
        player = GameObject.FindGameObjectWithTag("Player");

        portalCamera.playerCamera = player.transform.GetChild(0);
        portalCamera.otherPortal = otherPortal.transform;
        portalCamera.portal = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
