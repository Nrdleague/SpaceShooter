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
    private GameObject [] powerUps;
   
    [SerializeField]
    public int _spawnWeight;

    private GameObject _selectedPowerUp;

    private bool _stopSpawning = false;
    

    public void StartSpawning()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerUpRoutine());
        StartCoroutine(SpawnRarePowerUpRoutine());
    }
    
    private void PickPowerUpToSpawn()
    {
        int totalWeight = 0;
        for(int i =0; i < powerUps.Length; i++)
        {
            totalWeight += powerUps[i].GetComponent<Powerup>()._spawnWeight;
        }

        int randomNumber = UnityEngine.Random.Range(0, totalWeight);

        foreach(GameObject powerup in powerUps)
        {
            int powerupWeight = powerup.GetComponent<Powerup>()._spawnWeight;
            if(randomNumber < powerupWeight)
            {
                _selectedPowerUp = powerup;
                break;
            }
            randomNumber -= powerupWeight;
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
        while(_stopSpawning == false)
        {
            
            Vector3 posToSpawn = new Vector3(Random.Range(-8.0f, 8.0f), 7, 0);
            int randompowerup = Random.Range(0, 5);
            Instantiate(powerUps[randompowerup], posToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(3, 7.0f));

        }

    }

  
    IEnumerator SpawnRarePowerUpRoutine()
    {
        while (_stopSpawning == false)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-8.0f, 8.0f), 7, 0);
            int randomRarepowerup = Random.Range(0, 1);
            Instantiate(powerUps[randomRarepowerup], posToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(3, 7.0f));
        }
    }


    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }

}
