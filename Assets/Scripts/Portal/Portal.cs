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

        // Ustalanie zmiennych do skryptu portalCamera (¿eby nie musieæ rêcznie)
        portalCamera.playerCamera = player.transform.GetChild(0);
        portalCamera.otherPortal = otherPortal.transform;
        portalCamera.portal = this.transform;

        // Ustalanie zmiennych do skryptu portalTeleport (¿eby nie musieæ rêcznie)
        portalTeleport.player = player.transform;
        portalTeleport.receiver = otherPortal.transform;

        // z obiektu który trzyma skrypt render plane, znajdŸ komponent renderer
        // z renderer weŸ materia³ i ustal go jako nowy materia³
        
        myRenderPlane.gameObject.GetComponent<Renderer>().material = Instantiate(material);
        // Je¿eli kamera ma ju¿ jak¹œ teksturê (w jakiœ magiczny sposób)
        if (myCamera.targetTexture != null)
        {
            // To j¹ usuñ
            myCamera.targetTexture.Release();
        }
        // Tworzymy now¹ teksturê z rozdzielczoœci¹ dopasowan¹ do naszego ekranu
        myCamera.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);

        // Zmienna myAngle = obrót na osi y w zakresie od 0 do 360
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
            Debug.LogWarning("Portale nie s¹ odpowiednio obrócone :" + gameObject.name);
            Debug.Log("Angle: " + (otherPortal.myAngle - myAngle));
        }
    }

}
