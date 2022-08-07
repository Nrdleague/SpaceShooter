using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    // handle to text
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Image _livesImage;
    [SerializeField]
    private Sprite[] _liveSprites;
    [SerializeField]
    private Text _GameOverText;
    [SerializeField]
    private Text _RestartText;

    private GameManager _gameManager;

    // Start is called before the first frame update
    void Start()
    {

        _scoreText.text = " Score : " + 0;
        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();

        if(_gameManager == null)
        {
            Debug.LogError("Game Manager is null");
        }

    }

    // Update is called once per frame
    public void UpdateScore(int PlayerScore)
    {
        _scoreText.text = "Score :" + PlayerScore.ToString();
    }

    public void UpdateLives(int CurrentLives)
    {
       
        _livesImage.sprite = _liveSprites[CurrentLives];

        if(CurrentLives == 0)
        {
            GameOverSequence();
        }
    }

    void GameOverSequence()
    {

        _gameManager.GameOver();
        _GameOverText.gameObject.SetActive(true);
        _RestartText.gameObject.SetActive(true);
        StartCoroutine(GameOverFlickerRoutine());
        
    }

    IEnumerator GameOverFlickerRoutine()
    {
        while (true)
        {
            _GameOverText.text = "GAME OVER";
            yield return new WaitForSeconds(0.5f);
            _GameOverText.text = "";
            yield return new WaitForSeconds(0.5f);
        }
    }
   
}
    
    
   
    


