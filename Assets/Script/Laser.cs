using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    //speed variable of 8
    public float speed = 8.5f;
    
   
    
    // Update is called once per frame
    void Update()
    {

        MoveUp();
    }
   
    void MoveUp()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        if (transform.position.y > 8f)
        {

            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            Destroy(this.gameObject);
        }
    }

}
