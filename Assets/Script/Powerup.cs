using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float _powerupspeed = 3.0f;
    [SerializeField]
    



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(Vector3.down * _powerupspeed * Time.deltaTime);
       
        if (transform.position.y < -4.5f)
        {
            Destroy(this.gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
           
            Player player = other.transform.GetComponent<Player>();
            if(player != null)
            {
                player.TripleShotActive();
            }
            Destroy(this.gameObject);
        }
    }
}   
