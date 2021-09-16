using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectingBehaviour : MonoBehaviour
{
    public GameObject item;
    public float rotationSpeed = 1;
    public GameObject visableItem;


    private void Update()
    {
        transform.Rotate(0, rotationSpeed, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            visableItem.GetComponent<MeshRenderer>().enabled = true;
            item.GetComponent<ProjectileLauncher>().enabled = true;
            Destroy(gameObject);
        }
        else 
        {
            return;
        }
    }
}
