using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    
    private float _rotateSpeed = 124.0f;
    [SerializeField]
    private GameObject ExplosionPrefab;

    private GameManager _gameManager;
    private SpawnManager _spawnManager;
    private UI_Manager _uiManager;
    void Start()
    {
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UI_Manager>();

        if(_gameManager == null)
        {
            Debug.Log("Asteriod::Start() Called. The Game Manager is NULL.");
        }
        
    }

    
    void Update()
    {
        
        transform.Rotate(Vector3.forward * _rotateSpeed * Time.deltaTime);

    }

    public void OnTriggerEnter2D (Collider2D Other)
    {

        Debug.Log("Hit : " + Other.transform.name + "tag: " + Other.tag);

        if (Other.tag == "Laser")
        {
            Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
            Destroy(Other.gameObject);
            
            _spawnManager.StartSpawning();
            Destroy(this.gameObject, 0.25f);
        }



    }

   


    



}






