using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float radius = 5.0f;
    public float power = 10.0f;

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach(Collider hit in colliders)
        {
            Rigidbody rigidbody = hit.GetComponent<Rigidbody>();

            if (rigidbody != null)
            {
                if(rigidbody.gameObject.CompareTag("Player"))
                {
                    rigidbody.GetComponent<DeathBehaviour>()._animator.enabled = false;
                    rigidbody.GetComponent<DeathBehaviour>()._body.enabled = false;
                }
                rigidbody.isKinematic = false;
                rigidbody.AddExplosionForce(power, explosionPos, radius);
                Destroy(gameObject);
            }
        }
    }
}
