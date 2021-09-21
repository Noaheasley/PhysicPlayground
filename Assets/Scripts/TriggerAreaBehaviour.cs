using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAreaBehaviour : MonoBehaviour
{
    public GameObject bullet;
    //gives a object the bullet behaviour once it enters the trigger area
    private void OnTriggerEnter(Collider other)
    {
        bullet.AddComponent<BulletBehaviour>();
    }
}
