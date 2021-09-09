using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{
    public Rigidbody rigidbody;
    public Camera camera;
    private void OnMouseDown()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            rigidbody.isKinematic = false;
        }
    }
}
