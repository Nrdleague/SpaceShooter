using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ThrusterMeter : MonoBehaviour
{
    [SerializeField]
    private float _reduceRefreshMultiplier = 1.50f;

    [SerializeField]
    private float _increaseRefreshMultiplier = 0.75f;

    private int _stopThrust = 0;

    private bool _isKeyPressed = false;
    [SerializeField]
    private Image Thruster_Image_bar;

    private float waitTime = 5.0f;


    void Start()
    {
       if(Thruster_Image_bar == null)
       {
            Debug.LogError("Thruster bar is null");
       } 
    }

    void Update()
    {
        if (_isKeyPressed)
        {
            Thruster_Image_bar.fillAmount -= _reduceRefreshMultiplier / waitTime * Time.deltaTime;

        }
        else
        {
            Thruster_Image_bar.fillAmount += _increaseRefreshMultiplier / waitTime * Time.deltaTime;
        }
    }


    public void IsKeyPressed(bool answer)
    {
        _isKeyPressed = answer;
    }
    public float returnFillAmount()
    {
        return Thruster_Image_bar.fillAmount;
    }
    public float returnIncreaseMultiplier()
    {
        return _increaseRefreshMultiplier;
    }
  



}
