using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{

    private float _powerUpSpeed = 3.5f;

    [SerializeField]
    private AudioClip _clip;

    public int powerUpID;






    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.down * _powerUpSpeed * Time.deltaTime);

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
            if (player != null)
            {

                switch (powerUpID)
                {
                    case 0:
                        player.TripleShotActive();
                        break;
                    case 1:
                        player.SpeedBoostActive();
                        break;
                    case 2:
                        player.ShieldsActive();
                        if (_isShieldsActive[power])
                        {
                            _shieldBehavior.RestoreShield();
                        }
                        else
                        {
                            ShieldHealth.SetActive(true);
                        }
                        break;
                    // case 3:
                    // player.ammoRefill();
                    //   break;
                    //case 4:
                    //player.restoreHealth();
                    //  break;
                    default:
                        Debug.Log("normal");
                        break;

                }

            }
            Destroy(this.gameObject);
        }
    }

   



    


}   
