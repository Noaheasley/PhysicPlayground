using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBehaviour : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private CharacterController _player;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hazard"))
        {
            _animator.enabled = false;
            _player.enabled = false;
        }
    }
}
