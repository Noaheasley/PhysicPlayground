using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    //loads the main game
    public void ChangeScene()
    {
        SceneManager.LoadScene("PhysicsScene");
    }
}
