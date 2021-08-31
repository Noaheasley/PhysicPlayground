using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController _controller;
    private Vector3 _desiredVelocity;
    private Vector3 _airVelocity;
    private bool _isJumpDesired;

    public float speed = 5.0f;
    public float jumpStrength = 10.0f;
    public float gravityModifier = 1.0f;
    

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        //get movement input
        _desiredVelocity.x = Input.GetAxis("Horizontal");
        _desiredVelocity.y = 0.0f;
        _desiredVelocity.z = Input.GetAxis("Vertical");

        //get jump input
        _isJumpDesired = Input.GetButtonDown("Jump");

        //set movement magnitude
        _desiredVelocity.Normalize();
        _desiredVelocity *= speed;

        //Apply JUmp strenght
        if(_isJumpDesired)
        {
            _airVelocity.y = jumpStrength;
            _isJumpDesired = false;
        }

        ////apply gravity
        _airVelocity += Physics.gravity * gravityModifier * Time.deltaTime;

        _desiredVelocity += _airVelocity;

        //move
        _controller.Move(_desiredVelocity * Time.deltaTime);
    }
}
