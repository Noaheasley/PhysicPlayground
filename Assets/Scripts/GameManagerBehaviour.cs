using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject _pauseScreen;
    [SerializeField]
    private GameObject _winScreen;
    
    private bool _isPaused;
    private bool _isGameOver;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            _isPaused = true;
            _pauseScreen.SetActive(_isPaused);
        }
        if(GetComponent<WinningBehaviour>().GameOver == true)
        {
            _isGameOver = true;
            _winScreen.SetActive(_isGameOver);
        }
    }
    //sets the pause screen to be false
    public void Resume()
    {
        _isPaused = false;
        _pauseScreen.SetActive(_isPaused);
    }
    //reloads the scene
    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
    //shuts down the app
    public void QuitGame()
    {
        Application.Quit();
    }
}
