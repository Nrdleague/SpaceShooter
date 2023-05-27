using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class UI_Manager : MonoBehaviour
{
    //UI Text
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Text _gameOverText;
    [SerializeField]
    private Text _restartText;
    [SerializeField]
    private Text _ammoCountText;
    [SerializeField]
    private Text _waveText;
    [SerializeField]
    private Text _waveUI;

    // Sprites and Images
    [SerializeField]
    private Image _livesImage;
    [SerializeField]
    private Sprite[] _liveSprites;

    // UI Text
    [SerializeField]
    private Text _outOfAmmoText;
    [SerializeField]
    private Text _ammoText;
<<<<<<< HEAD
    public Text _waveIDDisplay;
    public Text _waveTimeDisplay;
=======
    [SerializeField]
    private Text _waveCounter;
>>>>>>> 1189efeca4d5951c7939ba42e780a1fdaf62b713

    public GameObject _waveDisplay;

    public bool _waveEnded = false;
  
    
    private GameManager _gameManager;
    private Player _player;
    private SpawnManager _spawnManager; 

    void Start()
    {
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        _gameOverText.gameObject.SetActive(false);  
        _scoreText.text = " Score : " + 0;
        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
        _player = GameObject.Find("Player").GetComponent<Player>();
        
        if (_gameManager == null)
        {
            Debug.LogError("Game Manager is null");
        }

       
    }

<<<<<<< HEAD
    public void WaveDisplayOn()
    {
        _waveDisplay.SetActive(true);
    }
    public void WaveDisplayOff()
    {
        _waveDisplay.SetActive(false);
    }
    public void WaveIDUPdate(int waveID)
    {
        _waveIDDisplay.text = "Wave : " + waveID.ToString();
    }
    public void WaveTimeUpdate(float _seconds)
    {
        float _waveTime = Mathf.RoundToInt(_seconds);
        _waveTimeDisplay.text = _waveTime.ToString();

        if(_waveTime > 0)
        {
            _waveEnded = false;
        }
        else
        {
            _waveEnded = true;
            StartCoroutine(WaveDisplayFlickerRoutine());
        }
    }



    private IEnumerator WaveDisplayFlickerRoutine()
    {
        while (_waveEnded)
        {
            yield return new WaitForSeconds(0.5f);
            _waveDisplay.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            _waveDisplay.SetActive(true);

        }
    }


=======
>>>>>>> 1189efeca4d5951c7939ba42e780a1fdaf62b713

   

    public void UpdateAmmoCount(int ammoCount, int maximumAmmo)
    {
        _ammoText.text = " Ammo :  " + ammoCount + " / " + maximumAmmo;

        if(ammoCount == 0)
        {
            _ammoText.color = Color.white;
        }
        else
        {
            _ammoText.color = Color.green;
        }
    }

    public void UpdateScore(int playerScore)
    {
        _scoreText.text = " Score : " + playerScore.ToString();
    }

  

    public void UpdateLives(int currentLives)
    {
        //display Image Sprite
        //give it a new one based on the currentLives index
        _livesImage.sprite = _liveSprites[currentLives];

        if(currentLives == 0)
        {
            GameOverSequence();
        }

    }

    


    void GameOverSequence()
    {

        _gameManager.GameOver();
        _gameOverText.gameObject.SetActive(true);
        _restartText.gameObject.SetActive(true);
        StartCoroutine(GameOverFlickerRoutine());
        
    }

    //IEnumerators 

    IEnumerator GameOverFlickerRoutine()
    {
        while(true)
        {
            _gameOverText.text = "GAME OVER";
            yield return new WaitForSeconds(0.5f);
            _gameOverText.text = "";
            yield return new WaitForSeconds(0.5f);
        }
    }

    


   
}
    
    
   
    


