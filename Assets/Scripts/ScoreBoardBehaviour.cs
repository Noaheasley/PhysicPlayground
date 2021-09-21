using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoardBehaviour : MonoBehaviour
{
    public Text CoinCounter;
    private int _score = 0;
    //gets score
    public int Score()
    {
        return _score;
    }
    // Start is called before the first frame update
    void Update()
    {
        //changes text to show how many coins were collected
        CoinCounter.text = "Coins collected: " + _score + "/8";
    }
    //increases score
    public void IncreaseScore()
    {
        _score += 1;
    }
}
