using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : MonoBehaviour
{
    private float _missileSpeed = 3f;
    [SerializeField]
    private GameObject _target;
    [SerializeField]
    private GameObject _explosionPrefab;
    [SerializeField]
    private bool _isEnemyDetected = false;

    void Update()
    {
        transform.Translate(Vector3.up * _missileSpeed * Time.deltaTime);
        Vector3 newDirection = _target.transform.position - transform.position;

        transform.Translate(Vector3.up * _missileSpeed * Time.deltaTime);
        transform.localRotation = Quaternion.LookRotation(transform.forward, newDirection);

        MissileBehavior(); 
    }

    void MissileBehavior()
    {
        Collider2D _targets = Physics2D.OverlapCircle(transform.position, 3f);
        if (_targets.CompareTag("Enemy"))
        {
            _target = _targets.gameObject;
            _isEnemyDetected = true;
        }
    }






}
