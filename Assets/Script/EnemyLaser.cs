using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class EnemyLaser : MonoBehaviour
{

    private float _enmylaserSpeed = 5.5f;
    private bool _isEnemylaser = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EnemyLaserMovement();
    }

    void EnemyLaserMovement()
    {
        transform.Translate(Vector3.down * _enmylaserSpeed * Time.deltaTime);

        if (transform.position.y < -8f)
        {
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }

            Destroy(this.gameObject);
        }
    }


    public void AssignEnemyLaser()
    {
        _isEnemylaser = true;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" )
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.Damage();
            }

            Destroy(this.gameObject);
        }
    }
}
