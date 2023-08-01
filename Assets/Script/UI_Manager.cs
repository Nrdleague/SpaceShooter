using System.Collections;
using TMPro;
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

    //Wave System
    [SerializeField]
    private Text _waveText;
    

    private int _currentEnemyDestroyed = 0;
    private int _waveCount = 1;
   

    

  
    private Player _player;
    private SpawnManager _spawnManager;
    private GameManager _gameManager;

    void Start()
    {

        _gameOverText.gameObject.SetActive(false);
        _waveText.gameObject.SetActive(false);  
        _scoreText.text = " Score : " + 0;


        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
        _player = GameObject.Find("Player").GetComponent<Player>();
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
    }

    void Update()
    {
        
    }

    public void UpdateAmmoCount(int ammoCount, int maximumAmmo)
    {
        _ammoText.text = " Ammo :  " + ammoCount + " / " + maximumAmmo;

        if (ammoCount == 0)
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
        Debug.Log("UpdateLives is NULL");
        _livesImage.sprite = _liveSprites[currentLives];

        if (currentLives == 0)
        {
            GameOverSequence();
        }

    }

    /// WAVE Course

    public void UpdateWaveNumber(int currentWave, int totalWaves)
    {
        _waveText.text = " WAVE " + currentWave +  "/ " + totalWaves.ToString();
       
        
    }

    public void WaveTextSequence()
    {
        _waveText.gameObject.SetActive(true);
        StartCoroutine(WaveText());
       
    }

    IEnumerator WaveText()
    {


        _waveText.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        _waveText.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        _waveText.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        _waveText.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        _waveText.gameObject.SetActive(false);
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
    
    
   
    


