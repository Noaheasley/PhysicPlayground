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
        if(scoreBoard.GetComponent<ScoreBoardBehaviour>().Score() == 8)
        {
            for (int i = 0; i < 8; i++)
            {
                _ammountOf = i;
                nuke[_ammountOf].GetComponent<Rigidbody>().isKinematic = false;
                if(i >= 8)
                {
                    return;
                }
            }
            player.GetComponent<PlayerController>().enabled = false;
            player.GetComponent<PlayerController>()._animator.enabled = false;
            endingCamera.enabled = true;
            playerCamera.enabled = false;
            _isGameOver = true;
        }
    }
}
