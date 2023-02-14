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
    [SerializeField]
    private TextMeshProUGUI _waveCounter;

  
    
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

    public void UpdateWaveStartDisplay(int currentWave)
    {
        _waveCounter.gameObject.SetActive(true);
        _waveCounter.text = "Wave:" + currentWave;
        StartCoroutine(BlinkGameObject(_waveCounter.gameObject, 2, .7f, false));
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

    IEnumerator SpawnEnemeyRoutine()
    {
        int enemiesSpawned = 0;
        yield return new WaitForSeconds(3.0f);

        while (_stopSpawning != true)
        {
            if(enemiesSpawned != _waveManager.enemiesToSpawn)
            {
                if(_waveManager._currentWave < 5)
                {
                    GameObject newEnemy = Instantiate(_enemyPrefabs[0], RandomPos(), Quaternion.identity);
                    newEnemy.transform.parent = _enemyContainer.transform;

                    _waveManager.enemiesLeft++;
                    enemiesSpawned++;
                }
            }

            else if(_waveManager.currentWave >= 5)
            {
                int randomEnemyID = Random.Range(0, 2);

                GameObject newEnemy = Instantiate
            }
            else
            {
                _waveManager.startOfWave = false;
                enemiesSpawned = 0;
                StopSpawning();
            }

            yield return new WaitForSeconds(3f);


        }
    }
   
}
    
    
   
    


