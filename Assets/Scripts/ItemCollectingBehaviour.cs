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
        //rotate the item in the y axis
        transform.Rotate(0, rotationSpeed, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        //checks if the player interacts with the item if not it'll return
        if (other.CompareTag("Player"))
        {
            //sets the item on the player to be visible and enables the player to use that item
            visableItem.GetComponent<MeshRenderer>().enabled = true;
            item.GetComponent<ProjectileLauncher>().enabled = true;
            //destroys the object
            Destroy(gameObject);
        }
        else 
        {
            return;
        }
    }
}
