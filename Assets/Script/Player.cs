using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    
    public float speed = 3.5f;
    [SerializeField]
    private float _fireRate = 0.150f;
    private object _uiMannager;
    private float _canFire = -1f;
    private int _lives = 3;
    private float _speedmultiplier = 2.0f;
    [SerializeField]
    private float _thrusterSpeed = 2.0f;
    [SerializeField]
    private int _shieldHealth = 3;
    [SerializeField]
    private int _currentShieldStrength;
    
    
    public int _ammoAmount = 15;
    public int _currentAmmo;

   

    [SerializeField]
    private GameObject _tripleshotPrefab;
    [SerializeField]
    private GameObject _laserPrefab; 
    [SerializeField]
    private GameObject _shieldVisualizer;
    [SerializeField]
    private GameObject _rightEngine;
    [SerializeField]
    private GameObject _leftEngine;
    [SerializeField]
    private GameObject _thruster;
    [SerializeField]
    private GameObject _shield;
    
   
    

    [SerializeField]
    private AudioClip _laserShot;
    private AudioSource _audioSource;
    [SerializeField]
    private AudioClip _explosionSound;
    [SerializeField]
    private AudioClip _outOfAmmoSound;

   
    
    private bool _isTripleShotActive = false;
   
    private bool _isShieldsActive = false;
    
    private bool _isSpeedBoostActive = false;

    private bool _isThrusterActive = false;

    private bool _hasAmmo = true;

    

    

    


    [SerializeField]
    private int _Score;



    private UI_Manager _uiManager;
    [SerializeField]
    private SpawnManager _spawnManager;

    private Renderer _shieldRenderer;
   
  



    void Start()
    {
        transform.position = new Vector3(0, -2 , 0);
        _spawnManager = GameObject.Find ("Spawn_Manager").GetComponent<SpawnManager>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UI_Manager>();
       
        _shieldRenderer = _shield.GetComponent<Renderer>();
        if (_shieldRenderer != null)
            Debug.LogError("The renderer is NULL");

        if (_spawnManager == null)
        {
            Debug.LogError("the spawn manager is null");
        }

        if (_uiManager == null)
        {
            Debug.LogError("the UI manager is null");
        }

       

        _currentAmmo = _ammoAmount;
       
    }
    

   
    void Update()
    {
        CalculateMovement();

        Thrusters();

       

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            if(_hasAmmo == true)
            {
                FireLaser();
            }
            

            
           
        }

       

    }


    

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);

        transform.Translate(direction * speed * Time.deltaTime);

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.8f, 0));

        if (transform.position.x > 11 )
        {
            transform.position = new Vector3(-11, transform.position.y, 0);
        }
        else if (transform.position.x < -11f)
        {
            transform.position = new Vector3(11, transform.position.y, 0);
        }
    }




    void Thrusters()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _isThrusterActive = true;
            speed *= _thrusterSpeed;

        }

        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            _isThrusterActive = false;

            speed /= _thrusterSpeed;
        }
       
       
    }





    void FireLaser()
    {
       


        _canFire = Time.time + _fireRate;

        if (_isTripleShotActive == true)
        {
            Instantiate(_tripleshotPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity);
        }

        _currentAmmo--;

        if (_currentAmmo <= 0)
        {
            _hasAmmo = false;
        }



    }

    



    public void SoundEffects()
    {
        _audioSource = GetComponent<AudioSource>();

        if (_audioSource == null)
        {
            Debug.LogError("The audio source on the player is NULL");
        }

        _audioSource.PlayOneShot(_laserShot);

        _audioSource = GetComponent<AudioSource>();

        if (_audioSource == null)
        {
            Debug.LogError("The audio source on the player is NULL");
        }

        _audioSource.PlayOneShot(_explosionSound);

    }


    private void ShieldDisplayStrength()
    {
        switch (_currentShieldStrength)
        {
            case 1:
                _shieldRenderer.material.color = new Color(1, 1, 1, .25f );
                break;
            case 2:
                _shieldRenderer.material.color = new Color(1, 1, 1, .50f);
                break;
            case 3:
                _shieldRenderer.material.color = new Color(1, 1, 1);
                break;
              

        }


    }







    public void Damage()
    {
       

        if (_isShieldsActive)
        {
            if(_currentShieldStrength > 0)
            {

                _currentShieldStrength--;

                return;
            }
            else
            {
                _isShieldsActive = false;
                _shield.SetActive(false);
                ShieldDisplayStrength();
                return;
            }

            
        }

       

        if (_lives <= 2)
        {
            
            _rightEngine.SetActive(true);
            
        }
      
        else if (_lives >= 1)
        {
           
            _leftEngine.SetActive(true);
        }
       

        _lives -= 1;

        _uiManager.UpdateLives(_lives);
         
        if (_lives < 1)
        {
            _spawnManager.OnPlayerDeath();
            Destroy(this.gameObject);
        }

       
        

    }

   

    IEnumerator ThrusterCoolDownRoutine()
    {
        {
            yield return new WaitForSeconds(2.0f);
            StartCoroutine(ThrusterCoolDownRoutine());
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
        if(_currentShieldStrength == _shieldHealth)
        {
            return;
        }
        else
        {
            _isShieldsActive = true;
            _shieldVisualizer.SetActive(true);
            _currentShieldStrength++;
            ShieldDisplayStrength();

        }
          
        
        
    }


    public void AddScore(int points)
    {
        _Score += points;
        _uiManager.UpdateScore(_Score); 
    }

   

  
}
