using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float _powerupspeed = 5.5f;

    
    private AudioSource _audiosource;

    public int powerupID;
    private AudioClip _powerupSound;



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

                        _audiosource = GetComponent<AudioSource>();
                        _audiosource.PlayOneShot(_powerupSound);
                }
            
            }
            Destroy(this.gameObject);
        }
    }

    


}   
