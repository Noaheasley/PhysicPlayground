using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObjectBehaviours : MonoBehaviour
{
    public Camera camera;
    public float speed = 100;

    private void OnMouseDown()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
            
        //if the target was hit by the ray add force to the object at the direction of the camera facing
        if (Physics.Raycast(ray, out hit))
        {
            gameObject.GetComponent<Rigidbody>().AddForce(camera.transform.forward * speed);
                
        }
        
    }
}
