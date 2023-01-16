using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public float _enemyspeed = 4.0f;
    
    private float _fireRate = 3.0f;
    private float _canfire = -1;
    private Player _player;
    
    [SerializeField]
    private AudioClip _explosionSound;
    private AudioSource _AudioSource;

    [SerializeField]
    private GameObject _enemylaserPrefab;
  

    private Animator _Anim;
    
    
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        
        if(_player == null)
        {
            Debug.LogError("The player is NULL");
        }
       
        _Anim = GetComponent<Animator>();

        if(_Anim == null)
        {
            Debug.LogError("The anim is null");
        }
        _AudioSource = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        EnemyMovement();
       
        if (Time.time > _canfire)
        {
            _canfire = Time.time + _fireRate;
            _fireRate = Random.Range(3f, 7f);
            GameObject _enemlaserPrefab = Instantiate(_enemylaserPrefab, transform.position, Quaternion.identity);
            EnemyLaser[] lasers = _enemylaserPrefab.GetComponentsInChildren<EnemyLaser>();
             
            for(int i = 0; i < lasers.Length; i++)
            {
                lasers[i].AssignEnemyLaser();
            }
           

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

            _Anim.SetTrigger("OnEnemyDeath");
            _AudioSource.Play();
           _enemyspeed = 0;
            Destroy(this.gameObject, 1.0f);
        }
       
        if (other.tag == "Laser")
        {

            _AudioSource.Play();
            Destroy(other.gameObject);
             
            if (_player != null)
            {
                _player.AddScore(10);

            }
            
           ///// _Anim.SetTrigger("OnEnemyDeath");
           // _enemyspeed = 0;
          //  _AudioSource.Play();
           //  Destroy(GetComponent<Collider2D>());
            //Destroy(this.gameObject, 1.0f);
//
           // else if (other.CompareTag("Missile")) { }



        }

       

    }


   
}
