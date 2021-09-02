using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float maxDistance = 30.0f;
    public float sensitivity = 5.0f;
    public float cameraReturnSpeed = .25f;
    public bool invertY = false;

    private float currentDistance = 10.0f;

    private void Start()
    {
        currentDistance = maxDistance;
    }

    private void Update()
    {
        //Rotate the camera 
        if(Input.GetMouseButton(1))
        {
            Vector3 angles = transform.eulerAngles;
            Vector2 rotation;
            rotation.x = Input.GetAxis("Mouse Y") * (invertY ? -1.0f : 1.0f);
            rotation.y = Input.GetAxis("Mouse X");
            //look up and down by rotating around X-axis
            angles.x = Mathf.Clamp(angles.x + rotation.x * sensitivity * Time.deltaTime, 0.0f, 70.0f);
            //Look left and right by rotating around the Y-axis
            angles.y += rotation.y * sensitivity * Time.deltaTime;
            //Set the angles
            transform.eulerAngles = angles;
        }

        //Move the camera
        RaycastHit hit;
        if(Physics.Raycast(target.position, -transform.forward, out hit, maxDistance))
        {
            currentDistance = hit.distance;
        }
        else
        {
            currentDistance = Mathf.MoveTowards(currentDistance, maxDistance, cameraReturnSpeed * Time.deltaTime);
        }

        transform.position = target.position + (currentDistance * -transform.forward);
    }
}
