using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Rigidbody rb;
    GameObject player;
    public float speed;
    Vector3 distance;



    float heightBound = -1;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }


    void Update()
    {

        if(transform.position.y<heightBound)
        {

            Destroy(gameObject);


        }
        distance = player.transform.position - transform.position;
        rb.AddForce(distance.normalized * speed );

       
    }
}
