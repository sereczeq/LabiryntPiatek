using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public void Picked()
    {
        Debug.Log("Podnios³em");
        Destroy(this.gameObject);
    }
}
