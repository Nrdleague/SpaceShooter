using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private bool _isGameOver;

    private UI_Manager _uiManager;
    private SpawnManager _spawnManager;

  
    void Start()
    {
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UI_Manager>();


        if(_spawnManager == null)
        {
            Debug.Log("The spawn manager is NULL.");

        }

        if(_uiManager == null)
        {
            Debug.Log("The UI Manager is NULL.");
        }

    }

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
