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
    
    private void OnMouseDown()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            GameObject firedBullet = Instantiate(_bullet, _bulletEmitter.transform.position, Quaternion.identity);

            firedBullet.GetComponent<Rigidbody>().AddForce(_bulletEmitter.transform.forward * _shotSpeed, ForceMode.Impulse);
        }
    }
}
