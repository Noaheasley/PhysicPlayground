using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAreaBehaviour : MonoBehaviour
{
    public GameObject bullet;
    private void OnTriggerEnter(Collider other)
    {
        bullet.AddComponent<BulletBehaviour>();
    }
}
