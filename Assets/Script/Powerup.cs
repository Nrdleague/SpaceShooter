using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float _powerupspeed = 3.0f;
    [SerializeField]
    private float _powerdown = 5.0f;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //move down at a spped of 3
        transform.Translate(Vector3.down * _powerupspeed * Time.deltaTime);
        //when we leave the screen, destroy this object
        if (transform.position.y < -4.5f)
        {
            Destroy(this.gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //communicate with the player script
            Destroy(this.gameObject);
        }
    }
}   
