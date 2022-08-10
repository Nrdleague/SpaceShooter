using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public float speed = 4.0f;
    
    private Player _player;

    
    private Animator _Anim;
    //handle to animator component
    
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        //null check to player
        if(_player == null)
        {
            Debug.LogError("The player is NULL");
        }
        //assign the component to anim
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
            //trigger the anim
            speed = 0;
            Destroy(this.gameObject, 1.0f);
        }
       
        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
             
            if (_player != null)
            {
                _player.AddScore(10);

            }
            // trigger anim
            _Anim.SetTrigger("OnEnemyDeath");
            speed = 0;
            Destroy(this.gameObject, 1.0f);
        }
       
    }
}
