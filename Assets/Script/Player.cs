using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 3.5f;
    [SerializeField]
    public GameObject _laserPrefab;
    [SerializeField]
    public float _fireRate = 0.150f;
    [SerializeField]
    private float _canFire = -1f;
    [SerializeField]
    private SpawnManager _spawnManager;
    public int lives = 3;
    [SerializeField]
    private bool _isTripleShotActive = false;
    [SerializeField]
    private GameObject _tripleshotPrefab;
    public bool tripleShotActive = false;
    

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, -2 , 0);
        _spawnManager = GameObject.Find ("Spawn_Manager").GetComponent<SpawnManager>(); 
    }
    

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();

       


        if(Input.GetKeyDown("space") && Time.time > _canFire)
        {
            FireLaser();
        }
       
    }

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);

        transform.Translate(direction * speed * Time.deltaTime);

        

        if (transform.position.y >= 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.position.y <= -3.8f)
        {
            transform.position = new Vector3(transform.position.x, -3.8f, 0);
        }
        
        
        if(transform.position.x > 11.3f )
        {
            transform.position = new Vector3(11.3f, transform.position.y, 0);
        }
        else if (transform.position.x < -11f)
        {
            transform.position = new Vector3(11.3f, transform.position.y, 0);
        }
    }

    void FireLaser()
    {
        _canFire = Time.time + _fireRate;

        if(_isTripleShotActive == true)
        {
            Instantiate(_tripleshotPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity);
        }

      
       
    }
   

    public void Damage()
    {
        
        lives -= 1;

         
        if (lives < 1)
        {
            _spawnManager.OnPlayerDeath();
            Destroy(this.gameObject);
        }

    }

    public void TripleShotActive()
    {
        //tripleshotactive becomes true
        if(tripleShotActive == false)
        {
            StartCoroutine(_powerdown);
        }
        //start the power down coroutine for triple shot
    }

    IEnumerator CooldownRoutine()
    {
        while (_stopSpawning == false)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-8.0f, -8.0f), 7, 0);
            GameObject newEnemy = Instantiate(_enemyPrefab, posToSpawn, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(6.0f);
        }

    }
    //IEnumerator TripleShotPowerDownRoutine
    //Wait 5 seconds
    //set the triple shot to false

}
