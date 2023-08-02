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
<<<<<<< HEAD
    private GameManager _gameManager;
    
    void Start()
    {
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();

        if(_gameManager == null)
        {
            Debug.Log("Asteriod::Start() Called. The game manager is NULL.");
        }

=======
    private UI_Manager _uiManager;
    void Start()
    {
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UI_Manager>();

        if(_gameManager == null)
        {
            Debug.Log("Asteriod::Start() Called. The Game Manager is NULL.");
        }
        
>>>>>>> de4ac4656b12d3f28f0d2e41ac12c8cc8f36ea84
    }

    
    void Update()
    {
        
        transform.Rotate(Vector3.forward * _rotateSpeed * Time.deltaTime);

    }

    public void OnTriggerEnter2D (Collider2D Other)
    {

<<<<<<< HEAD
        Debug.Log("Hit: " + Other.transform.name + " tag: " + Other.tag);
=======
        Debug.Log("Hit : " + Other.transform.name + "tag: " + Other.tag);
>>>>>>> de4ac4656b12d3f28f0d2e41ac12c8cc8f36ea84

        if (Other.tag == "Laser")
        {
            Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
            Destroy(Other.gameObject);
<<<<<<< HEAD
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
=======
            
            _spawnManager.StartSpawning();
            Destroy(this.gameObject, 0.25f);
        }



>>>>>>> de4ac4656b12d3f28f0d2e41ac12c8cc8f36ea84
    }

   


    



}






