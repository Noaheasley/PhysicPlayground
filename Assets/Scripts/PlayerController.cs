using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController _controller;
    private Vector3 _desiredVelocity;
    private Vector3 _airVelocity;
    private bool _isJumpDesired;
    private bool _isGrounded;

    //public Camera playerCamera;
    [SerializeField]
    public Animator _animator;
    [SerializeField]
    private Camera playerCamera;

    public float speed = 5.0f;
    public float airControl = 1.0f;
    public float jumpStrength = 10.0f;
    public float gravityModifier = 1.0f;
    public bool faceWithCamera = true;
    

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

        float inputForward= Input.GetAxis("Vertical");
        float inputRight = Input.GetAxis("Horizontal");

        //get camera normal
        Vector3 cameraForward = playerCamera.transform.forward;
        cameraForward.y = 0.0f;
        cameraForward.Normalize();

        //Get camera right
        Vector3 cameraRight = playerCamera.transform.right;

        //Find the desired velocity
        _desiredVelocity = (_desiredVelocity.x * cameraRight + _desiredVelocity.z * cameraForward);

        //get jump input
        _isJumpDesired = Input.GetButtonDown("Jump");

        //set movement magnitude
        _desiredVelocity.Normalize();
        _desiredVelocity *= speed;

        //Check for ground
        _isGrounded = _controller.isGrounded;

        //change player facing
        if (faceWithCamera)
        {
            //transform.forward = cameraForward;
            _animator.SetFloat("Speed", inputForward);
            _animator.SetFloat("Direction", inputRight);
        }
        else
        {
            if (_desiredVelocity != Vector3.zero)
            { 
                transform.forward = _desiredVelocity.normalized;
            }
            _animator.SetFloat("Speed", _desiredVelocity.magnitude / speed);
        }
        _animator.SetBool("Jump", !_isGrounded);
        _animator.SetFloat("VerticalSpeed", _desiredVelocity.y);
        //Apply Jump strenght
        if (_isJumpDesired && _isGrounded)
        {
            _airVelocity.y = jumpStrength;
            _isJumpDesired = false;
        }

        //stop on ground
        if (_isGrounded && _airVelocity.y < 0.0f)
        {
            _airVelocity.y = -1.0f;
        }

        //apply gravity
        _airVelocity += Physics.gravity * gravityModifier * Time.deltaTime;

        //add air velocity
        _desiredVelocity += _airVelocity;

        //move
        _controller.Move(_desiredVelocity * Time.deltaTime);

        
    }
}
