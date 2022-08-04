using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    
    public float speed = 3.5f;
    [SerializeField]
    private float _fireRate = 0.150f;
    private float _canFire = -1f;
    private int lives = 3;
    private float _speedmultiplier = 2.0f;

    [SerializeField]
    private SpawnManager _spawnManager;

    

    [SerializeField]
    private GameObject _tripleshotPrefab;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _shieldVisualizer;

    [SerializeField]
    private bool _isTripleShotActive = false;
    private bool _isShieldsActive = false;
    private bool _isSpeedBoostActive = false;


    [SerializeField]
    private int _Score;








    

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

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.8f, 0));
        

       
        
        
        if(transform.position.x > 11 )
        {
            transform.position = new Vector3(-11, transform.position.y, 0);
        }
        else if (transform.position.x < -11f)
        {
            transform.position = new Vector3(11, transform.position.y, 0);
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
        if (_isShieldsActive == true)
        {
            _isShieldsActive = false;
            
            _shieldVisualizer.SetActive(false);
            return;
        }
      
        
        
        lives -= 1;

         
        if (lives < 1)
        {
            _spawnManager.OnPlayerDeath();
            Destroy(this.gameObject);
        }

    }

    public void TripleShotActive()
    {
        _isTripleShotActive = true;
        StartCoroutine(TripleShotPowerDownRoutine());
    }

    IEnumerator TripleShotPowerDownRoutine()
    {
        {
            yield return new WaitForSeconds(5.0f);
            _isTripleShotActive = false;
        }

    }

    public void SpeedBoostActive()
    {
        _isSpeedBoostActive = true;
        speed *= _speedmultiplier; 
        StartCoroutine(SpeedBoostPowerDownRoutine());
    }

    IEnumerator SpeedBoostPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        _isSpeedBoostActive = false;
        speed /= _speedmultiplier;
    }
    
    public void ShieldsActive()
    {
        _isShieldsActive = true;

        _shieldVisualizer.SetActive(true);
      
    }

    public void ScoreCount()
    {

    }

    //method to add 10 to the score!
   //Communicate with the UI to update the score!
}
