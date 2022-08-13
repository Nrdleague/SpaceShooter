using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public float speed = 4.0f;
    
    private Player _player;

    [SerializeField]
    private AudioClip _explosionSound;
   
    private AudioSource _AudioSource;
    

    private Animator _Anim;
    
    
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        _AudioSource = GetComponent<AudioSource>();
        if(_player == null)
        {
            Debug.LogError("The player is NULL");
        }
       
        _Anim = GetComponent<Animator>();

        if(_Anim == null)
        {
            Debug.LogError("The anim is null");
        }
    }

    
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if(transform.position.y < -6.0f)
        {
            float randomX = Random.Range(-8.0f, 8.0f);
            transform.position = new Vector3(randomX, 8,0);
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
            speed = 0;
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
            
            _Anim.SetTrigger("OnEnemyDeath");
            speed = 0;
            _AudioSource.Play();
            Destroy(this.gameObject, 1.0f);


           



        }
       
    }
}
