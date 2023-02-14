using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
   private SpawnManager _spawnManager;

   private UI_Manager _uiManager;

   public int _currentWave = 1;

   public int _enemiesToSpawn = 5;

   public int _enemiesLeft = 0;

   public bool _startOfWave;


    void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UI_Manager>();
        
        if(_uiManager == null)
        {
            Debug.LogError("Game canvas is NULL"); 

        }

        _spawnManager = GetComponent<SpawnManager>();
    }


    void Update()
    {
      if(_enemiesLeft <= 0 && _startOfWave != true)
      {
            _enemiesLeft = 0;
            EndWave();
      }
    }

    public void StartWave()
    {
        _startOfWave = true;
        StartCoroutine(StartWaveRoutine());
    }

    IEnumerator StartWaveRoutine()
    {
        _uiManager.UpdateWaveStartDisplay(_currentWave);
        yield return new WaitForSeconds(3f);
        if (_enemiesLeft != _enemiesToSpawn)
        {
            _spawnManager.StartSpawning();
        }
    }

    public void EndWave()
    {
        StartCoroutine(EndWaveRoutine());
    }

    IEnumerator EndWaveRoutine()
    {
        _startOfWave = true;
        _currentWave++;
        _enemiesToSpawn += 5;
        yield return new WaitForSeconds(2.5f);
        StartWave();
    }

}


