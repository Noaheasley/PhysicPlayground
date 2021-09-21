using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    //radius of the explosion
    public float radius = 10.0f;
    //force of the explosion
    public float power = 500.0f;

    private void OnCollisionEnter(Collision collision)
    {
        //the explsion position
        Vector3 explosionPos = transform.position;
        //the array of colliders inside the aoe
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        //for each collider hit it'll get the rigidbody of the hit object
        foreach(Collider hit in colliders)
        {
            Rigidbody rigidbody = hit.GetComponent<Rigidbody>();
            //checks if the rigidbody is null
            if (rigidbody != null)
            {
                //checks if it's a player to cause the player to ragdoll
                if(rigidbody.gameObject.CompareTag("Player"))
                {
                    //makes the player ragdoll
                    rigidbody.GetComponent<DeathBehaviour>()._animator.enabled = false;
                    rigidbody.GetComponent<DeathBehaviour>()._body.enabled = false;
                }
                //sets the rigidbody to be not kinematic
                rigidbody.isKinematic = false;
                //adds the explosion force onto the rigidbody
                rigidbody.AddExplosionForce(power, explosionPos, radius);
                //destroys the bullet
                Destroy(gameObject);
            }
        }
    }
}
