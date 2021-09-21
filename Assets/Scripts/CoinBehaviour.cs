using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinBehaviour : MonoBehaviour
{
    public float rotationSpeed;
    public Canvas scoreBoard;
    // Update is called once per frame
    void Update()
    {
        //rotates the coin on the y axis
        transform.Rotate(0.0f, rotationSpeed, 0.0f);
    }
    private void OnTriggerEnter(Collider other)
    {
        //if the player triggers the coin it'll be collected
        if (other.CompareTag("Player"))
        {
            //increases the score in the scoreboard
            scoreBoard.GetComponent<ScoreBoardBehaviour>().IncreaseScore();
            //destroys the physical coin
            Destroy(gameObject);
        }
        else
            return;
    }
    private void OnCollisionEnter(Collision collision)
    {
        //on collision by a player the score will increase
        if (collision.gameObject.CompareTag("Player"))
        {
            scoreBoard.GetComponent<ScoreBoardBehaviour>().IncreaseScore();
            Destroy(gameObject);
        }
        else
            return;
    }
}
