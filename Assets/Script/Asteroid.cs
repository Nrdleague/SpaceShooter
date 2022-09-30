using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    
    private float _rotateSpeed = 124.0f;
    [SerializeField]
    private GameObject ExplosionPrefab;
    private SpawnManager _spawnManager;
    
    void Start()
    {
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
    }

    
    void Update()
    {
        
        transform.Rotate(Vector3.forward * _rotateSpeed * Time.deltaTime);

    }

    public void OnTriggerEnter2D (Collider2D Other)
    {
        if (Other.tag == "Laser")
        {
            Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
            Destroy(Other.gameObject);
            _spawnManager.StartSpawning();
            Destroy(this.gameObject, 0.25f);
        }

    }
    



}






