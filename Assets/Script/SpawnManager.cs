using JetBrains.Annotations;
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
    private bool _isPlayerAlive = false;

    private bool _spawnWaveOne;
    private bool _spawnWaveTwo;
    private bool _spawnWaveThree;

    private UI_Manager _uiManager;

    private bool _stopSpawning = false;


    public void Start()
    {
        _uiManager = GameObject.FindObjectOfType<UI_Manager>();
    }

   


    public void StartSpawning()
    {
        _spawnWaveOne = true;
        StartCoroutine(EnemySpawn());
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerUpRoutine());
        
    }
    
    public void WaveTwo()
    {
        _spawnWaveOne = false;
        _spawnWaveTwo = true;
        Debug.Log("Wave Two");
    }

    public void WaveThree()
    {
        _spawnWaveTwo = false;
        _spawnWaveThree = true;
        Debug.Log("wave three");
    }

    IEnumerator EnemySpawn()
    {
        yield return new WaitForSeconds(1f);

        while (_isPlayerAlive == true && _spawnWaveOne == true)
        {
            GameObject newEnemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);   
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(2f);
        }

        while (_isPlayerAlive == true && _spawnWaveTwo == true)
        {
            int _randomEnemy = Random.Range(0, 2);
            GameObject newEnemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(2f);
        }

        while (_isPlayerAlive && _spawnWaveThree == true)
        {
            int _randomEnemy = Random.Range(0, 2);
            GameObject newEnemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(2f);
        }
    }
       

    IEnumerator SpawnEnemyRoutine()
    {
        yield return new WaitForSeconds(4.0f);
        while(_stopSpawning == false)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(8.0f, -9.0f), 7, 0);
            GameObject newEnemy = Instantiate(_enemyPrefab, posToSpawn, Quaternion.identity);
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
