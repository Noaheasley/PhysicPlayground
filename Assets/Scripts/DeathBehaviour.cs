using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBehaviour : MonoBehaviour
{
    [SerializeField]
    public Animator _animator;
    [SerializeField]
    public BoxCollider _body;
    private void OnCollisionEnter(Collision collision)
    {
        //if a hazard object collides with the player it'll cause them to ragdoll
        if (collision.gameObject.CompareTag("Hazard"))
        {
            _animator.enabled = false;
            _body.enabled = false;
        }
    }
}
