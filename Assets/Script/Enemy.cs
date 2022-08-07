using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public float speed = 4.0f;
    [SerializeField]
    private Player _player;


    
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
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

            Destroy(this.gameObject);
        }
       
        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
             
            if (_player != null)
            {
                _player.AddScore(10);

            }

            Destroy(this.gameObject);
        }
       
    }
}
