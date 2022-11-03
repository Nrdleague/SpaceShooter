using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{


    public float _speed = 3.5f;

    private float _fireRate = 0.150f;

    private float _canFire = -1f;

    private int _lives = 3;

    private float _speedmultiplier = 2.0f;

    private float _thrusterSpeed = 2.0f;

    [SerializeField]
    private int _shieldHealth = 3;

    [SerializeField]
    private int _currentShieldStrength;

    public int _ammoAmount = 15;

    public int _currentAmmo;

    private float _shakeDuration = .1f;

    private float _shakeMag = .25f;

    public float _playerSpeed;

    private float _thrusterRemaining = 100;

    private float _speedBoostAmount; 




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
    private GameObject thrusters;
    [SerializeField]
    private GameObject _shield;

    private CameraShake _cameraShake;




    
    private AudioClip _laserShot;

    private AudioSource _audioSource;

    
    private AudioClip _explosionSound;

    
    private AudioClip _outOfAmmoSound;



    private bool _isTripleShotActive = false;

    private bool _isShieldsActive = false;

    private bool _isSpeedBoostActive = false;

    private bool _isThrusterActive = false;

    private bool _hasAmmo = true;

    private bool _refillAmmo = false;

    private bool _noAmmo = false;

    private bool _refillHealth = true;

    private bool _thrusterBoostActive = true;


    [SerializeField]
    private Image _thrusterBarImage;







    
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
        


        if (_spawnManager == null)
        {
            Debug.LogError("the spawn manager is null");
        }

        if (_uiManager == null)
        {
            Debug.LogError("the UI manager is null");
        }


        _currentAmmo = _ammoAmount;


        if (_cameraShake == null)
        {
            Debug.LogError("The camerashake on player is null");
        }



    }



    void Update()
    {
        CalculateMovement();

        Thrusters();



        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            if (_hasAmmo == true)
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

        transform.Translate(direction * _speed * Time.deltaTime);

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.8f, 0));

        if (transform.position.x > 11)
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
            _thrusterBoostActive = true;
            _isThrusterActive = true;
            _speed *= _thrusterSpeed;
            


        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _isThrusterActive = false;
            _speed /= _thrusterSpeed;
            _thrusterBoostActive = false;

        }



    }

    private void ThrusterDrain()
    {
        if (_isThrusterActive == true && _thrusterRemaining >= 0)
        {
            _thrusterRemaining -= Time.deltaTime * 50;
        }

        ChangeThruster(_thrusterRemaining);
    }

    private void ThrusterRecharge()
    {
        if (_isThrusterActive == false && _thrusterRemaining <= 100)
        {
            _thrusterRemaining += Time.deltaTime * 20;
        }
    }

    private void BoosterExhausted()
    {
        if (_thrusterRemaining < 5)
        {
            _isThrusterActive = false;
            _thrusterBoostActive = false;
        }
    }


    private void ChangeThruster(float value)
    {
        _thrusterBarImage.fillAmount = value / 100;
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

        StartCoroutine(_cameraShake.ShakeCamera(_shakeDuration, _shakeMag));

        _lives -= 1;

        _uiManager.UpdateLives(_lives);
         
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
        _speed *= _speedmultiplier; 
        StartCoroutine(SpeedBoostPowerDownRoutine());
    }

    IEnumerator SpeedBoostPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        _isSpeedBoostActive = false;
        _speed /= _speedmultiplier;
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

    public void RefillAmmo()
    {
        _currentAmmo = _ammoAmount;
        _hasAmmo = true;
        

    }

    public void HealthRefill()
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

   
}
