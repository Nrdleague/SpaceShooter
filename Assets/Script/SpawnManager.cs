using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField ]
    private GameObject _enemyContainer;
    [SerializeField]
    private GameObject _tripleShotPowerUp;
    [SerializeField]
    private GameObject _speedPowerup;
    [SerializeField]
    private GameObject _shieldPowerUp;
    [SerializeField]
    private GameObject [] powerUps;
    
    

    private bool _stopSpawning = false;
  

    public void StartSpawning()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerUpRoutine());
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
        while(_stopSpawning == false)
        {
            
            Vector3 posToSpawn = new Vector3(Random.Range(-8.0f, 8.0f), 7, 0);
            int randompowerup = Random.Range(0, 4);
            Instantiate(powerUps[randompowerup], posToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(3, 7.0f));

        }

    }

  



    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }

}
