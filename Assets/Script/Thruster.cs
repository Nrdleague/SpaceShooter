using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Thruster : MonoBehaviour
{
    private float _sprintSpeed;

    private float _normalSpeed;

    [SerializeField]
    private GameObject _thrusterMeterBar;

    public float _currentBoost, _boostLeft, _maxBoost;

    public bool _sprinting = false;

    public float _boostDrainRate = 0.20f;

    public int _speed;

    private void Start()
    {
        _maxBoost = 100;
        _currentBoost = 100;
        _sprintSpeed = _speed * 1.5f;


        _boostLeft = _currentBoost / _maxBoost;
    }
}
