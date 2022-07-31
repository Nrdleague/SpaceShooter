using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

public float speed = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if(transform.position.y < -6.0f)
        {
            float randomX = Random.Range(-8f, 8f);
<<<<<<< HEAD
            transform.position = new Vector3(randomX, 8, 0);
=======
            transform.position = new Vector3(randomX, 8,0);
>>>>>>> 436b786683c946b8522c6930c51908d52679045c
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
            Destroy(this.gameObject);
        }
       
    }
}
