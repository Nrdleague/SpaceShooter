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



    IEnumerator SpawnEnemyRoutine(float _waitTimeEnemy)
    {
        Debug.Log("SpawnManager::spawnEnemyRoutine() Called");

        yield return new WaitForSeconds(4.0f);



        while(_stopSpawning == false)
        while (_stopSpawning == false)

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
