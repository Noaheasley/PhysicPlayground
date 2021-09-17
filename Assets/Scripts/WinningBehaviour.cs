using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinningBehaviour : MonoBehaviour
{
    public GameObject nuke;
    public Canvas scoreBoard;

    private void Update()
    {
        if(scoreBoard.GetComponent<ScoreBoardBehaviour>().Score() == 8)
        {
            nuke.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
