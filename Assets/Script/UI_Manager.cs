using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    // handle to text
    [SerializeField]
    private Text _scoreText;


    // Start is called before the first frame update
    void Start()
    {
        _scoreText.text = "Score : " + 50;
        //assign text component to the handle
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
