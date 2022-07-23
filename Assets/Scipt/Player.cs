using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 3.5f;
    public GameObject laserPrefab;
    public float fireRate = 0.5f;
    public float canFire = -1f;
    private SpawnManager _spawnManager;
    public int lives = 3;
    [SerializeField]
    private bool _isTripleShotActive = false;
    public GameObject Triple_Shot;
    //variable for isTripleShotActive
    

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0 , 0);
        _spawnManager = GameObject.Find ("Spawn_Manager").GetComponent<SpawnManager>(); 
    }
    

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();

        FireLaser();


        if(Input.GetKeyDown("space") && Time.time > canFire)
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
        if(Input.GetKeyDown("space") && Time.time > canFire)
       {

            canFire = Time.time + fireRate;

            if(_isTripleShotActive == true)
            {
                Instantiate(Triple_Shot, transform.position, Quaternion.identity);
            }
            else
            {

            }

            Instantiate(laserPrefab, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity );

            //Instantiate 3 lasers(triple shot prefab)

       }
       
    }
   

    public void Damage()
    {
        
        lives -= 1;

        //check if dead
        //destroy us 
        if (lives < 1)
        {
            _spawnManager.OnPlayerDeath();
            Destroy(this.gameObject);
        }

    }

}
