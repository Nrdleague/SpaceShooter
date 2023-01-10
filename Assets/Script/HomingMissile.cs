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

    private bool _isEnemyDetected = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * _missileSpeed * Time.deltaTime);
        Vector3 newDirection = _target.transform.position - transform.position;

        transform.Translate(Vector3.up * _missileSpeed * Time.deltaTime);
        transform.localRotation = Quaternion.LookRotation(transform.forward, newDirection);
    }

    private void FindEnemy()
    {
        Collider2D _targets = Physics2D.OverlapCircle(transform.position, 3f);
        if (_targets.CompareTag("Enemy"))
        {
            _target = _targets.gameObject;
            _isEnemyDetected = true;   
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Instantiate(_explosionPrefab, transform.position, transform.rotation);

            Destroy(gameObject);
        }
    }
}
