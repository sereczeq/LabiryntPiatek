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

    // Awake w��cza si� wcze�niej ni� Start
    void Awake()
    {
        portalCamera = myCamera.GetComponent<PortalCamera>();
        portalTeleport = myColliderPlane.gameObject.GetComponent<PortalTeleport>();
        // gameObject NIE gameObjectS!!!
        player = GameObject.FindGameObjectWithTag("Player");

        // Ustalanie zmiennych do skryptu portalCamera (�eby nie musie� r�cznie)
        portalCamera.playerCamera = player.transform.GetChild(0);
        portalCamera.otherPortal = otherPortal.transform;
        portalCamera.portal = this.transform;

        // Ustalanie zmiennych do skryptu portalTeleport (�eby nie musie� r�cznie)
        portalTeleport.player = player.transform;
        portalTeleport.receiver = otherPortal.transform;

        // z obiektu kt�ry trzyma skrypt render plane, znajd� komponent renderer
        // z renderer we� materia� i ustal go jako nowy materia�
        
        myRenderPlane.gameObject.GetComponent<Renderer>().material = Instantiate(material);
        // Je�eli kamera ma ju� jak�� tekstur� (w jaki� magiczny spos�b)
        if (myCamera.targetTexture != null)
        {
            // To j� usu�
            myCamera.targetTexture.Release();
        }
        // Tworzymy now� tekstur� z rozdzielczo�ci� dopasowan� do naszego ekranu
        myCamera.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);

        // Zmienna myAngle = obr�t na osi y w zakresie od 0 do 360
        myAngle = transform.localEulerAngles.y % 360;
        portalCamera.myAngle = myAngle; 
    }

    private void Start()
    {
        myRenderPlane.gameObject.GetComponent<Renderer>().material.mainTexture =
            otherPortal.myCamera.targetTexture;

        CheckAngle();
    }

    private void CheckAngle()
    {
        if (Mathf.Abs(transform.rotation.y - otherPortal.transform.rotation.y) != 180)
        {
            Debug.LogWarning("Portale nie s� odpowiednio obr�cone :" + gameObject.name);
            Debug.Log("Angle: " + (otherPortal.myAngle - myAngle));
        }
    }

}
