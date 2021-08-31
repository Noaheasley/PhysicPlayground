using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankCannonBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject _bullet;
    [SerializeField]
    private float _shotSpeed;

    public void Fire(Vector3 force)
    {
        GameObject firedBullet = Instantiate(_bullet, transform.position, transform.rotation);
       
        BulletBehaviour bulletScript = firedBullet.GetComponent<BulletBehaviour>();

        if (bulletScript)
            bulletScript.Rigidbody.AddForce(force, ForceMode.Impulse);
    }
}
