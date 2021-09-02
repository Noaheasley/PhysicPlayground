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

    public void Update()
    {
        if (Input.GetButtonDown("Fire1") && _bulletEmitter)
        {
            GameObject firedBullet = Instantiate(_bullet, transform.position, Quaternion.identity);

            firedBullet.GetComponent<Rigidbody>().AddForce(transform.forward * _shotSpeed, ForceMode.Impulse);
        }
    }
}
