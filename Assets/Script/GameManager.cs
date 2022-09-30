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
           
            SceneManager.LoadScene(1);
        }

      
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
       
    }

    public void GameOver()
    {
        _isGameOver = true;
       
    }
}
