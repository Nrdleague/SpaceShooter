using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    
    private float _rotateSpeed = 124.0f;
    [SerializeField]
    private GameObject ExplosionPrefab;
    private SpawnManager _spawnManager;
    private GameManager _gameManager;
    
    void Start()
    {
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();

        if(_gameManager == null)
        {
            Debug.Log("Asteriod::Start() Called. The game manager is NULL.");
        }

    }

    
    void Update()
    {
        
        transform.Rotate(Vector3.forward * _rotateSpeed * Time.deltaTime);

    }

    public void OnTriggerEnter2D (Collider2D Other)
    {

        Debug.Log("Hit: " + Other.transform.name + " tag: " + Other.tag);

        if (Other.tag == "Laser")
        {
            Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
            Destroy(Other.gameObject);
            _gameManager.StartSpawning();
            Destroy(this.gameObject, 0.25f);
        }

        if(Other.tag == "Player")
        {
            Player player = Other.transform.GetComponent<Player>(); 
            if(player != null)
            {
                player.Damage();
            }
            _gameManager.StartSpawning();
            Destroy(this.gameObject, 0.25f);
        }
    }
    



}






