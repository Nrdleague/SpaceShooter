using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private bool _isGameOver;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) &&  _isGameOver == true)
        {
            //current game scene
            SceneManager.LoadScene(1);
        }

        //if escape key is pressed
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        //quit the game
    }

    public void GameOver()
    {
        _isGameOver = true;
       
    }
}
