using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private bool _isGameOver;

<<<<<<< HEAD
    private UI_Manager _uiManagerScript;
    private SpawnManager _spawnManager;

    public int _waveID = 0;
    private float _waveTime = 5.0f;
    private float _holdTime = 2.0f;

    void Start()
    {
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        _uiManagerScript = GameObject.Find("Canvas").GetComponent<UI_Manager>();

        if(_spawnManager == null)
        {
            Debug.LogError("GameManager::Start() Called. The Spawn Manager is NULL");

        }

        if(_uiManagerScript == null)
        {
            Debug.LogError("GameManager::Start() Called. The UI Manager is NULL");
=======
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
>>>>>>> de4ac4656b12d3f28f0d2e41ac12c8cc8f36ea84
        }

    }

<<<<<<< HEAD

    public void StartSpawning()
    {
        _waveID++;
        _waveTime += 10;


        if(_waveID > 5)
        {
            Debug.Log("You Win");
            return;
        }

        _uiManagerScript.WaveDisplayOn();
        _uiManagerScript.WaveIDUPdate(_waveID);
        StartCoroutine(WaveCountDown(_waveTime));
        _spawnManager.StartSpawning(_waveID);


    }

    private IEnumerator WaveCountDown(float _time)
    {
        while(_time > 0)
        {
            _time -= Time.deltaTime;
            _uiManagerScript.WaveTimeUpdate(_time);
            yield return new WaitForEndOfFrame();
        }

        _spawnManager.StopSpawning();
        yield return _holdTime;
        StartSpawning();
    }



=======
>>>>>>> de4ac4656b12d3f28f0d2e41ac12c8cc8f36ea84
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
