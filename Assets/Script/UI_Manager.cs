using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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
    private Text _outOfAmmoText;
    [SerializeField]
    private Text _ammoText;
    

  
    
    private GameManager _gameManager;
    private Player _player;

    void Start()
    {
        
        _gameOverText.gameObject.SetActive(false);  
        _scoreText.text = " Score : " + 0;
        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
        _player = GameObject.Find("Player").GetComponent<Player>();
        
        if (_gameManager == null)
        {
            Debug.LogError("Game Manager is null");
        }

        
    }

   
    public void UpdateAmmoCount(int ammoCount, int maximumAmmo)
    {
        _ammoText.text = ammoCount + " / " + maximumAmmo;

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
    
    
   
    


