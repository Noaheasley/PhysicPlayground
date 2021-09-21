using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinningBehaviour : MonoBehaviour
{
    public GameObject player;
    public Camera playerCamera;
    public Camera endingCamera;
    public GameObject[] nuke;
    public Canvas scoreBoard;
    private int _ammountOf = 0;
    private bool _isGameOver;

    public bool GameOver
    {
        get
        {
            return _isGameOver;
        }
    }

    private void Update()
    {
        //checks the scoreboard to see if the player has collected all the coins
        if(scoreBoard.GetComponent<ScoreBoardBehaviour>().Score() == 8)
        {
            //for loop to release all the explosives
            for (int i = 0; i < 8; i++)
            {
                //sets ammount of to be i
                _ammountOf = i;
                //sets the nuke's kinematic to be off
                nuke[_ammountOf].GetComponent<Rigidbody>().isKinematic = false;
                //once it reaches the max it'll break from the loop
                if(i >= 8)
                {
                    return;
                }
            }
            //disables player movement and causes them to ragdoll
            player.GetComponent<PlayerController>().enabled = false;
            player.GetComponent<PlayerController>()._animator.enabled = false;
            //changes camera angle
            endingCamera.enabled = true;
            playerCamera.enabled = false;
            //sets _isGameOver to true
            _isGameOver = true;
        }
    }
}
