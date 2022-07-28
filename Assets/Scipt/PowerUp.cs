using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private int speed = 3;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        //move down at a speed of 3
        //transform.Translate(Vector3 * speed * Time.deltaTime(0, 4.9, 0));
        //When we leave the screen, destroy this object
        //if (transform.position.y > -5.9f)
        //{
          //  Destroy(this.gameObject);
        //}
        //if object leaves screen at -5.9 destroy object
    }


    //OnTriggerCollider
    //Only collectable by the player (HINT : use tags)
    //On collected destroy 20, 22, 24
}
