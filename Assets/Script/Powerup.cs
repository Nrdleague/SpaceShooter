using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    
    private float _powerupspeed = 3.5f;

    [SerializeField]
    private AudioClip _clip;

    public int powerupID;
    



  

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

            AudioSource.PlayClipAtPoint(_clip, transform.position);

            Player player = other.transform.GetComponent<Player>();
            if(player != null)
            {
            
                switch(powerupID)
                {
                    case 0:
                        player.TripleShotActive();
                        break;
                    case 1:
                        player.SpeedBoostActive();
                        break;
                    case 2:
                        player.ShieldsActive();
                        break;
                    default:
                        Debug.Log("normal");
                        break;

                }
            
            }
            Destroy(this.gameObject);
        }
    }

    


}   
