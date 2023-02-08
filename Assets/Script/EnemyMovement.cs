using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

 
    [SerializeField]
    private float _moveSpeed = 1f;

    Rigidbody2D myRigidBody;
    BoxCollider2D myBoxCollider;


    // Start is called before the first frame update
    void Start()
    {
       
        myRigidBody = GetComponent<Rigidbody2D>();
        myBoxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsOnTheRight())
        {
            // move right 
            myRigidBody.velocity = new Vector2(_moveSpeed, 0f);
        }
        else
        {
            myRigidBody.velocity = new Vector2(-_moveSpeed, 0f);
        }

        

    }

    private bool IsOnTheRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }
   
  
}
