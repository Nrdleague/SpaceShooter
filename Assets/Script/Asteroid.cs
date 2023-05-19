using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    
    private float _rotateSpeed = 124.0f;
    [SerializeField]
    private GameObject _explosionPrefab;
    private SpawnManager _spawnManager;
    private Animator _asteriodAnim;
    
    void Start()
    {
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        if(_asteriodAnim == null)
        {
            Debug.Log("The anim is NULL");
        }
    }

    
    void Update()
    {
        // rotate on zed axis
        transform.Rotate(Vector3.forward * _rotateSpeed * Time.deltaTime);

    }

    public void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Laser")
        {
            
            Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            _spawnManager.StartSpawning();
            Destroy(this.gameObject, 0.25f);
        }

    }
    



}






