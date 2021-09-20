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
        transform.Rotate(0.0f, rotationSpeed, 0.0f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            scoreBoard.GetComponent<ScoreBoardBehaviour>().IncreaseScore();
            Destroy(gameObject);
        }
        else
            return;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            scoreBoard.GetComponent<ScoreBoardBehaviour>().IncreaseScore();
            Destroy(gameObject);
        }
        else
            return;
    }
}
