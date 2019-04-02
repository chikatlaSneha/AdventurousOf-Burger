using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class positionCollider : MonoBehaviour
{
    public int index;
    public Platformpooler pool;
    public float a;
    public float b;
    //public float P1 = 100;
    //P1 = 100
    //P2 = 200
    //P3 = 300
    //P4 = 400
    //P5 = 500


    void Start()
    {

    }

    private void Update()
    {
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.transform.position.x > transform.position.x)
        {
           // Debug.Log(collision.gameObject.transform.position.x > transform.position.x);
            //a = collision.gameObject.transform.position.x;
            pool.Interact(index);
            //  Debug.Log("Burger is exiting from Left with a value of :" + b);
            // Debug.Log("Burger is coming from left with a value of :" + a);
        }
        if (collision.gameObject.transform.position.x < transform.position.x)
        {
          //  Debug.Log(collision.gameObject.transform.position.x > transform.position.x);
            //b = collision.gameObject.transform.position.x;
            pool.Interact(index);
           // Debug.Log("Index is :" + index);
           // Debug.Log("Burger is exiting from Right with a value of :" + a);
           // Debug.Log("Burger is coming from Right with a value of :" + b);
        }
    }
}