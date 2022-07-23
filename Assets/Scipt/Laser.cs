using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    //speed variable of 8
    public float speed = 8.5f;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //translate laser up
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        //if laser position is greater than 8 on the y destroy laser 
        if (transform.position.y > 8 )
        {
            Destroy(this.gameObject);
        }
        

    }
   
}
