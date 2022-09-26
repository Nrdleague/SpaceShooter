using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class EnemyLaser : MonoBehaviour
{

    private float _enmyLaserSpeed = 4.5f;
    private bool _isEnemylaser = false;
   
   

   
    void Update()
    {
        EnemyLaserMovement();
    }

    void EnemyLaserMovement()
    {
        transform.Translate(Vector3.down * _enmyLaserSpeed * Time.deltaTime);

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
