using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WakeUpBehaviour : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        //if a object with a tag "Vehicle" collides with the object it'll set it to be nonKinematic
        if (collision.gameObject.CompareTag("Vehicle"))
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
