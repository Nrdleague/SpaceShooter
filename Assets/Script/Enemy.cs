using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public float _enemyspeed = 4.0f;
    private int _speed;
    private float _fireRate = 3.0f;
    private float _canfire = -1;
    private Player _player;
    
   
    private AudioSource _audioSource;

  

    [SerializeField]
    private GameObject _enemylaserPrefab;
    [SerializeField]
    private GameObject _explosion;
    

    private Animator _enemyAnim;
    private EnemyMovement _enemyMove;
    private NewEnemyMovement _newEnemyMove;
    
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        _newEnemyMove = this.GetComponent<NewEnemyMovement>();
        _audioSource = GetComponent<AudioSource>();

        if (_player == null)
        {
            Debug.LogError("The player is NULL");
        }
       
        _enemyAnim = GetComponent<Animator>();

        if(_enemyAnim == null)
        {
            Debug.LogError("The anim is null");
        }

      
       
    }

    
    void Update()
    {
        EnemyMovement();
       
        if (Time.time > _canfire)
        {
            _canfire = Time.time + _fireRate;
            _fireRate = Random.Range(3f, 7f);
            GameObject _enemlaserPrefab = Instantiate(_enemylaserPrefab, transform.position, Quaternion.identity);
           
           

        }


        Enemy[] allEnemies = GameObject.FindObjectsOfType<Enemy>();
    }

    void EnemyMovement()
    {
        transform.Translate(Vector3.down * _enemyspeed * Time.deltaTime);

        if (transform.position.y < -5f)
        {
            float randomX = Random.Range(8.0f, -8.0f);
            transform.position = new Vector3(randomX, 8, 0);
        }


    }



    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player Player = other.transform.GetComponent<Player>();

            if (Player != null)
            {
                Player.Damage();
            }

            _enemyAnim.SetTrigger("OnEnemyDeath");

            _audioSource.Play();
            _enemyspeed = 0;
            Destroy(this.gameObject, 1.8f);
        }

        if (other.tag == "Laser")
        {

            if (_player != null)
            {
                _player.AddScore(10);
                Destroy(this.gameObject);
            }

            _enemyspeed = 0;
            _audioSource.Play();
            _enemyAnim.SetTrigger("OnEnemyDeath");

            Destroy(this.gameObject, 1.8f);
        }

        if (other.tag == "Missile")
        {
            _audioSource.Play();

            if (_player != null)
            {
                _player.AddScore(10);
            }

            Destroy(this.gameObject);
        }


    } 
    


   
}
 