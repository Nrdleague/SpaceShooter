using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float _powerupspeed = 8.5f;

    // 0 = tripleshot
    // 1 = spped
    // 2 = shields 
    public int powerupID;



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
                        Debug.Log("Collected speed boost");
                        break;
                    default:
                    case 2:
                        Debug.Log("Deafault Value");
                        break;
                }
            
            }
            Destroy(this.gameObject);
        }
    }

    


}   
