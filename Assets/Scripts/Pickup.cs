using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public void Picked()
    {
        Debug.Log("Podnios�em");
        Destroy(this.gameObject);
    }
}
