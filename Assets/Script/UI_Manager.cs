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
   

    private GameManager _gameManager;
    private int _currentAmmo;

    void Start()
    {
        _ammoCountText.text = " Ammo  : " + 15;
        _scoreText.text = " Score : " + 0;
        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
       
        if (_gameManager == null)
        {
            Debug.LogError("Game Manager is null");
        }

        
    }

   

  
  



    public void UpdateScore(int PlayerScore)
    {
        _scoreText.text = "Score :" + PlayerScore.ToString();
    }

    public void UpdateAmmoCount(int PlayerAmmo)
    {
        _ammoCountText.text = " Ammo: ";
        PlayerAmmo -= _currentAmmo ;
    }
    


    public void UpdateLives(int currentLives)
    {
        if (currentLives < -1)
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
    
    
   
    


