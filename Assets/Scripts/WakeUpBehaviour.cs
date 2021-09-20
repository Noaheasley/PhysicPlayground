using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WakeUpBehaviour : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Vehicle"))
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
