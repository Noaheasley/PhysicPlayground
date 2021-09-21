using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankCannonBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject _bullet;
    [SerializeField]
    private GameObject _bulletEmitter;
    [SerializeField]
    private float _shotSpeed = 100.0f;
    [SerializeField]
    private Camera camera;
    //on mouse down a ray will be created at the point of where the mouse is on screen
    private void OnMouseDown()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        //if the ray hits the object it'll create a bullet
        if (Physics.Raycast(ray, out hit))
        {
            GameObject firedBullet = Instantiate(_bullet, _bulletEmitter.transform.position, Quaternion.identity);
            //flings the bullet from where the cannon is facing
            firedBullet.GetComponent<Rigidbody>().AddForce(_bulletEmitter.transform.forward * _shotSpeed, ForceMode.Impulse);
        }
    }
}
