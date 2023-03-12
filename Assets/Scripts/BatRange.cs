using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatRange : MonoBehaviour
{

    public BatAttackSystem bas;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "Player")
        {

            /* if (atacks == false)
             {*/
            // initpos = transform.position;
            //  transform.position = Vector3.MoveTowards(transform.position, collision.gameObject.transform.position, 999f);
            /*}
            atacks = true;*/
            bas.Move(collision.gameObject.transform.position);
            
        }
       

    }
}
