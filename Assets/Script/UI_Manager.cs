using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI_Manager : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Text _gameOverText;
    [SerializeField]
    private Text _restartText;
    [SerializeField]
    private Text _ammoCountText;

    [SerializeField]
    private Image _livesImage;
    [SerializeField]
    private Sprite[] _liveSprites;
   
    [SerializeField]
    private Slider _fuelGauge;
    


    
    private GameManager _gameManager;
    private Player _player;

    void Start()
    {

        
        _scoreText.text = " Score : " + 0;
        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
        _player = GameObject.Find("Player").GetComponent<Player>();
       
        if (_gameManager == null)
        {
            Debug.LogError("Game Manager is null");
        }

        
    }

   
    private void Update()
    {
        _ammoCountText.text = " Ammo : " + _player._currentAmmo;

        if (_player._currentAmmo <= 0)
        {
            _ammoCountText.color = Color.red;
        }
        else
        {
            _ammoCountText.color = Color.green;
        }
    }
  
  


    public void UpdateScore(int playerScore)
    {
        _scoreText.text = " Score : " + playerScore.ToString();
    }

    public void UpdateThrusterFuelGauge(float fuel)
    {
        _fuelGauge.value = fuel;
    }

   

    

    public void UpdateLives(int currentLives)
    {
        if (currentLives < -1)
        {
            _livesImage.sprite = _liveSprites[currentLives];
        }
        if(currentLives > -1) 
        {
            _livesImage.sprite = _liveSprites[currentLives];
        }


        if (currentLives == 0)
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

    IEnumerator GameOverFlickerRoutine()
    {
        while (true)
        {
            _gameOverText.text = "GAME OVER";
            yield return new WaitForSeconds(0.5f);
            _gameOverText.text = "";
            yield return new WaitForSeconds(0.5f);
        }
    }
   
}
    
    
   
    


