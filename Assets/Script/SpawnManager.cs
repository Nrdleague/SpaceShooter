using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField ]
    private GameObject _enemyContainer;
    [SerializeField]
    private GameObject [] powerUps;

    float _waitTimeEnemy = 5.0f;
    float _waitTimeWaves = 7.0f;
    int _maxEnemies = 1;
    int _enemiesSpawned = 0;
    private GameManager _gameManager;

    int _xPositionLimit;
    int _yPositionLimit;
    float _randomZangle;



    private bool _stopSpawning = false;

    void Start()
    {
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
        StartCoroutine(SpawnPowerUpRoutine());
        
    }
    
   
    public void StopSpawning()
    {
        _stopSpawning = true;
        ClearEnemies();
    }

    private void ClearEnemies()
    {
        Debug.Log("SpawnManager::ClearEnemies() called");
        Enemy[] _activeEnemies = _enemyContainer.GetComponentsInChildren<Enemy>();

        foreach(Enemy _enemy in _activeEnemies)
        {
            _enemy.ClearField();
        }
    }

    private void GetWaveInfo(int _waveID)
    {
        Debug.Log("SpawnManager::GetWaveInfo()  Called");
        WaitForSeconds _respawnTime = new WaitForSeconds(10);

        switch (_waveID)
        {
            case 1:
                _maxEnemies = 4;
                _waitTimeEnemy = 3.5f;
                break;
            case 2:
                _maxEnemies = 6;
                _waitTimeEnemy = 3.0f;
                break;
            case 3:
                _maxEnemies = 9;
                _waitTimeEnemy = 2.5f;
                break;
            case 4:
                _maxEnemies = 14;
                _waitTimeEnemy = 2.0f;
                break;
            case 5:
                _maxEnemies = 18;
                _waitTimeEnemy = 1.0f;
                break; 
        }


    }

    //IEnumerator spawnEnemyRoutine(float _waitTimeEnemy)
    //{
    //    Debug.Log("SpawnManager::spawnEnemyRoutine() Called");

    //    while (!_stopSpawning)
     //   {
      //     for (int i = 0; i < _maxEnemies; i++)
     //       {
          //      yield return new WaitForSeconds(_waitTimeEnemy);

          //      if (!_stopSpawning)
          //      {
                    //Instantiate Enemy Prefab
          //          float _randomX = Random.Range(-_xPositionLimit, _xPositionLimit);
           //         _randomZangle = Random.Range(-45f, 45f);
           //         Vector3 spawnPosition = new Vector3(_randomX, _yPositionLimit, 0);
           //         GameObject newEnemy = Instantiate(_enemyPrefab, spawnPosition, Quaternion.Euler(0, 0, _randomZangle));
              //      _enemiesSpawned++;
              //      newEnemy.transform.parent = _enemyContainer.transform;

           //     }
           // }

       //     yield return new WaitForSeconds(_waitTimeWaves);
       // }

    //}



    IEnumerator SpawnEnemyRoutine(float _waitTimeEnemy)
    {
        Debug.Log("SpawnManager::spawnEnemyRoutine() Called");

        yield return new WaitForSeconds(4.0f);


        while(_stopSpawning == false)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(8.0f, -9.0f), 7, 0);
            GameObject newEnemy = Instantiate(_enemyPrefab, posToSpawn, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            _enemiesSpawned++;
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(6.0f);
        }
        
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

  
  


    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }

}
