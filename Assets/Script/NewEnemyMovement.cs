using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class NewEnemyMovement : MonoBehaviour
{
    private float _enemySpeed = 3.0f;
    private int _enemyDthSpeed = 0;

    [SerializeField]
    private GameObject _explosion;
    private GameObject wayPoint;
    private Vector3 wayPointsPos;
    private Animator _orbAnim;
    private AudioSource _audioSource;

    [SerializeField]
    private GameObject _enemyorb;

    private Enemy _enemy;
    private Player _player;
    // Start is called before the first frame update
    void Start()
    {
        wayPoint = GameObject.Find("wayPoint");
        _enemy =  this.GetComponent<Enemy>();
        _player = GameObject.Find("Player").GetComponent<Player>();


        if (_enemy == null)
        {
            Debug.Log("The Enemy is NULL");
        }
    }

    // Update is called once per frame
    void Update()
    {
        wayPointsPos = new Vector3(wayPoint.transform.position.x, transform.position.y, transform.position.z);

        transform.position = Vector3.MoveTowards(transform.position, wayPointsPos, _enemySpeed * Time.deltaTime);

       
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

            _orbAnim.SetTrigger("OnAsteriodDeath");

            _audioSource.Play();
            _enemyDthSpeed = 0;
            Destroy(this.gameObject, 1.8f);
        }

        if (other.tag == "Laser")
        {

            if (_player != null)
            {
                _player.AddScore(10);
                Destroy(this.gameObject);
            }

            _enemyDthSpeed = 0;
        //    _audioSource.Play();
            //_orbAnim.SetTrigger("OnAsteriodDeath");

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


    
