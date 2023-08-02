using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class SpawnManager : MonoBehaviour
{
   
    [SerializeField]
    private int _waveCount = 1;
    private int _totalWaves = 4;
    private float _spawnRate;
    private float _enemySpawnTime = 5.0f;
    //Wave system code
    private int _spawnedNumberOfEnemies;
    private int _numberOfEnemiesToSpawn = 5;

    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField ]
    private GameObject _enemyContainer;
    [SerializeField]
    private GameObject [] powerUps;
<<<<<<< HEAD

  


    private bool _stopSpawning = false;
=======
    private bool _isPlayerAlive = false;

    private Coroutine _spawnEnemy;

    private UI_Manager _uiManager;
    private GameManager _gameManager;

    private bool _stopSpawning = false;


    void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UI_Manager>();
        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();

        if(_gameManager == null)
        {
            Debug.Log("The game manager is NULL");
        }

       

    }

   




    public void StopSpawning()
    {
        _stopSpawning = true;
        ClearEnemies();
    }

    public void ClearEnemies()
    {
        _stopSpawning = true;
        Enemy[] _activeEnemies = _enemyContainer.GetComponentsInChildren<Enemy>();

        foreach(Enemy _enemy in _activeEnemies)
        {
            _enemy.ClearField();
        }
    }

   
>>>>>>> de4ac4656b12d3f28f0d2e41ac12c8cc8f36ea84

    void Start()
    {
<<<<<<< HEAD
        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();

        if(_gameManager == null)
        {
            Debug.LogError("SpawnManager::Start() Called. The Game Manager is NULL.");
        }

        Debug.Log("SpawnManagerS::Start() Called. _stopSpawning=" + _stopSpawning.ToString());
    }


    public void StartSpawning(int _waveID)
    {
        _stopSpawning = false;
        GetWaveInfo(_waveID);
        //StartCoroutine(spawnEnemyRoutine(_waitTimeEnemy));
        StartCoroutine(SpawnEnemyRoutine(_waitTimeEnemy));
=======
       // StartCoroutine(SpawnEnemyRoutine());
>>>>>>> de4ac4656b12d3f28f0d2e41ac12c8cc8f36ea84
        StartCoroutine(SpawnPowerUpRoutine());
        //SpawnWaves coroutine spawns enemy's in 
        StartCoroutine(SpawnWaves());
    }
<<<<<<< HEAD
=======

  

>>>>>>> de4ac4656b12d3f28f0d2e41ac12c8cc8f36ea84



    IEnumerator SpawnEnemyRoutine(float _waitTimeEnemy)
    {
<<<<<<< HEAD
        Debug.Log("SpawnManager::spawnEnemyRoutine() Called");

        yield return new WaitForSeconds(4.0f);



        while(_stopSpawning == false)
        while (_stopSpawning == false)

=======
        _spawnedNumberOfEnemies = 0;
        yield return new WaitForSeconds(4.0f);
        while (_stopSpawning == false && _spawnedNumberOfEnemies < _numberOfEnemiesToSpawn)
>>>>>>> de4ac4656b12d3f28f0d2e41ac12c8cc8f36ea84
        {
            //spawnumber is counter

            Vector3 posToSpawn = new Vector3(Random.Range(8.0f, -9.0f), 7, 0);
            GameObject newEnemy = Instantiate(_enemyPrefab, posToSpawn, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
<<<<<<< HEAD
            _enemiesSpawned++;
            newEnemy.transform.parent = _enemyContainer.transform;
=======
            _spawnedNumberOfEnemies += 1;

            
>>>>>>> de4ac4656b12d3f28f0d2e41ac12c8cc8f36ea84
            yield return new WaitForSeconds(6.0f);
            

            //Wave System
           

        }

<<<<<<< HEAD
=======
        
        _waveCount += 1;
        StartCoroutine(SpawnWaves());
       
        if(_waveCount == 4)
        {
            Debug.Log("Stop waves, and begin final boss");
            yield break;

        }

>>>>>>> de4ac4656b12d3f28f0d2e41ac12c8cc8f36ea84
    }

    

    IEnumerator SpawnPowerUpRoutine()
    {
        yield return new WaitForSeconds(3.0f);

        while(_stopSpawning == false)
        {
            Vector3 spawnArea = new Vector3(UnityEngine.Random.Range(-9, 9), 7, 0);
            Vector3 posToSpawn = new Vector3(Random.Range(-8.0f, 8.0f), 7, 0);
            int randompowerup = Random.Range(0, 6);
            Instantiate(powerUps[randompowerup], posToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(3, 7.0f));
            

        }

    }


    IEnumerator SpawnWaves()
    {
       yield return new WaitForSeconds(2.0f);
       _uiManager.UpdateWaveNumber(_waveCount, _totalWaves);
        _uiManager.WaveTextSequence();
        yield return new WaitForSeconds(2.0f);
        StartCoroutine(SpawnEnemyRoutine());
    }
    
  
  


    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }

}
