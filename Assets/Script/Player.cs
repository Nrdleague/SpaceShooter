using System;
using System.Collections;
using System.Net.Http.Headers;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    
    private int _shieldHealth = 3;

    [SerializeField]
    private float _speed = 3.5f;

    
    private int _currentShieldStrength;

    public float _playerSpeed = 3.5f;

    private float _fireRate = 0.150f;

    private float _canFire = -1f;

    private int _lives = 3;

    [SerializeField]
    private int _ammoCount = 15;
    [SerializeField]
    private int _maximumAmmoCount;

    private float _speedmultiplier = 3.5f;

    private float _shakeDuration = .1f;

    private float _shakeMag = .25f;

    [SerializeField]
    private float _thrustMultiplier = 7.5f;

    private float timer = 0.5f;

  
   
   
   
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
    private GameObject _thrusters;

    [SerializeField]
    private GameObject _shield;

    [SerializeField]
    private GameObject _homingMissilePrefab;

    [SerializeField]
    private GameObject _explosion;

    [SerializeField]
    private GameObject wayPoint;



    private CameraShake _cameraShake;



    [SerializeField]
    private AudioClip _laserShot;

    private AudioSource _audioSource;
    

    private AudioClip _explosionSound;

    [SerializeField]
    private AudioClip _outOfAmmoAudio;



    private bool _isTripleShotActive = false;

    private bool _isShieldsActive = false;

    private bool _isSpeedBoostActive = false;

    private bool _isThrusterActive = false;

    private bool _hasAmmo = true;

    private bool _refillAmmo = false;

    private bool _noAmmo = false;

    private bool _refillHealth = true;

    private bool _thrusterBoostActive = true;

    private bool _refillMeter = false;

    private bool _isThunderBoltActive = false;

    private bool _isHomingMissile = false;

    private bool _canLaserFire = true;

    private bool _isAmmoActive = false;

    private ThrusterMeter _thrustMeter;
    
    private int _Score;

    private object _uiMannager;

    public UI_Manager _uiManager;
    
    private SpawnManager _spawnManager;

    private Renderer _shieldRenderer;

   


    void Start()
    {
        transform.position = new Vector3(0, -2, 0);

        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UI_Manager>();
        _shieldRenderer = _shield.GetComponent<Renderer>();
        _cameraShake = GameObject.Find("Main Camera").GetComponent<CameraShake>();
        _thrustMeter = GameObject.Find("Thruster_Image_bar").GetComponent<ThrusterMeter>();
        

        if (_spawnManager == null)
        {
            Debug.LogError("the spawn manager is null");
        }

        if (_uiManager == null)
        {
            Debug.LogError("the UI manager is null");
        }


        _maximumAmmoCount = _ammoCount;


        if (_cameraShake == null)
        {
            Debug.LogError("The camerashake on player is null");
        }

        if(_homingMissilePrefab == null)
        {
            Debug.Log("_homingMissileprefab is null");
        }
      

    }



    void Update()
    {
        CalculateMovement();

       
        if(Input.GetKey(KeyCode.Space) && Time.time > _canFire && _ammoCount != 0)
        {
            FireLaser();

           
            _ammoCount -= 1;
            _uiManager.UpdateAmmoCount(_ammoCount, _maximumAmmoCount);
           // _audioSource.PlayOneShot(_outOfAmmoAudio);
        }

        
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if(timer <= 0)
        {
            UpdatePosition();
            timer = 0.5f;
        }
        
    }

    void UpdatePosition()
    {
        wayPoint.transform.position = transform.position;
    }


    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // player now stops moving after input
        transform.Translate((transform.up * Input.GetAxisRaw("Vertical") + transform.right * Input.GetAxisRaw("Horizontal")).normalized * _speed * Time.deltaTime);

       // Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);

       // transform.Translate(direction * _speed * Time.deltaTime);

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.8f, 0));

        if (transform.position.x > 11)
        {
            transform.position = new Vector3(-11, transform.position.y, 0);
        }
        else if (transform.position.x < -11f)
        {
            transform.position = new Vector3(11, transform.position.y, 0);
        }

        //Calculating thruster movment
        if (_thrustMeter.returnFillAmount() >= 0 )
        {
            thrusterBoost();

        }

        if (_thrustMeter.returnFillAmount() == 0)
        {
            _refillMeter = true;
            thrusterBoost();
            StartCoroutine(RefillThruster());
        }
       
    }


    void thrusterBoost()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && _refillMeter == false )
        {
            _speed *= _thrustMultiplier;
            _thrustMeter.IsKeyPressed(true);
        }
        
        if (Input.GetKeyUp(KeyCode.LeftShift) && _refillMeter == false)
        {
            _speed /= _thrustMultiplier;
            _thrustMeter.IsKeyPressed(false);
            

        }
    }

   
    

    void FireLaser()
    {
       
      
            

            Vector3 offset = new Vector3(0, 1.14f, 0);

            _canFire = Time.time + _fireRate;

            if (_isTripleShotActive == true)
            {
                Instantiate(_tripleshotPrefab, transform.position, Quaternion.identity);
            }
            else if (_isHomingMissile)
            {
                Instantiate(_homingMissilePrefab, transform.position, Quaternion.identity);
            }
            else 
            {
                Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity);
                
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


        _cameraShake.startShaking();

        _lives--;
        _uiManager.UpdateLives(_lives);

        if(_lives < 1)
        {
            _spawnManager.OnPlayerDeath();
            Destroy(this.gameObject);
           
                                  
        }

        //for shield damage system
        if (_lives <= 2)
        {
            
            _rightEngine.SetActive(true);
            
        }
        else if (_lives >= 1)
        {
           
            _leftEngine.SetActive(true);
        }

        if (_lives < 1)
        {
            _spawnManager.OnPlayerDeath();
            Destroy(this.gameObject);
        }






        switch (_lives)
        {
            case 2:
                _rightEngine.SetActive(true);
                break;
            case 1:
                _leftEngine.SetActive(true);
                break;
            default:
                break;
        }
        

    }

  


   public void Health()
   {
        _lives++;
        if (_lives <= 3)
        {
            _lives = 3;
        }
        _uiManager.UpdateLives(_lives);

        //if player collects health while max on health
        //ignore health pick up


   }

    public void RefillAmmoCount()
    {
        _ammoCount = _maximumAmmoCount;
        _uiManager.UpdateAmmoCount(_ammoCount, _maximumAmmoCount);
    }


    public void HomingMissile()
    {
        StartCoroutine(HomingMissleRoutine());
    }

    IEnumerator HomingMissleRoutine()
    {
        _isHomingMissile = true;
        yield return new WaitForSeconds(5.0f);
        _isHomingMissile = false;
    }



    public void TripleShotActive()
    {
        _isTripleShotActive = true;
        StartCoroutine(TripleShotPowerDownRoutine());
    }

    
    
    public void SpeedBoostActive()
    {
        _isSpeedBoostActive = true;
        _playerSpeed *= _speedmultiplier; 
        StartCoroutine(SpeedBoostPowerDownRoutine());
    }

  

    IEnumerator TripleShotPowerDownRoutine()
    {
        {
            yield return new WaitForSeconds(5.0f);
            _isTripleShotActive = false;
        }

    }
    IEnumerator SpeedBoostPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        _isSpeedBoostActive = false;
        _playerSpeed /= _speedmultiplier;
    }

    IEnumerator RefillThruster()
    {
        _speed /= _thrustMultiplier;
        _thrustMeter.IsKeyPressed(false);
        yield return new WaitForSeconds(5.0f / _thrustMeter.returnIncreaseMultiplier());
        _refillMeter = false;
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
    
    public void HealthRefill()
    {
        if(_lives < 3)
        {
            _lives++;
            _uiManager.UpdateLives(_lives);

            switch (_lives)
            {
                case 3:
                    _rightEngine.SetActive(false);
                    _rightEngine.SetActive(false);
                    break;
                case 2:
                    _leftEngine.SetActive(false);
                    _leftEngine.SetActive(false);
                    break;
                default:
                    break;
            }


        }

        else
        {
            _lives = 3;
        }


      
       
    }


   
   
}
