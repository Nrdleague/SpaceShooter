using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemyMovement : MonoBehaviour
{
    private float _enmySpeed = 5.0f;

    private GameObject wayPoint;
    private Vector3 wayPointsPos;
    

    // Start is called before the first frame update
    void Start()
    {
        wayPoint = GameObject.Find("wayPoint");
    }

    // Update is called once per frame
    void Update()
    {
        wayPointsPos = new Vector3(wayPoint.transform.position.x, transform.position.y, transform.position.z);

        transform.position = Vector3.MoveTowards(transform.position, wayPointsPos, _enmySpeed * Time.deltaTime);
    }
}
