using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerMovement : MonoBehaviour {

    public float moveSpeed;
    private Rigidbody2D myRigidBody;

    public bool isWalking;
    public float walkTime;
    public float waitTime;
    private float walkCounter;
    private float waitCounter;

    private Vector2 minWalkPoint;
    private Vector2 maxWalkPoint;

    private int WalkDirection;

    public Collider2D walkZone;
    private bool hasWalkZone;

    public bool canMove;
    private DialogoueManager theDm;

	void Start ()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        waitCounter = waitTime;
        walkCounter = walkTime;
        theDm = FindObjectOfType<DialogoueManager>();
        minWalkPoint = walkZone.bounds.min;
        maxWalkPoint = walkZone.bounds.max;

        ChooseDirection();

        if(walkZone!= null)
        {
            minWalkPoint = walkZone.bounds.min;
            maxWalkPoint = walkZone.bounds.max;
            hasWalkZone = true;
        }
        canMove = true;
      
	}
	
	
	void Update ()
    {
        if(!theDm.dialogActive)
        {
            canMove = true;
        }

        if(!canMove)
        {
            myRigidBody.velocity = Vector2.zero;
            return;
        }

		if(isWalking)
        {
            walkCounter -= Time.deltaTime;
            if(walkCounter<0)
            {
                isWalking = false;
                waitCounter = waitTime;
            }
            switch(WalkDirection)
            {
                case 0:
                    myRigidBody.velocity = new Vector2(0f,moveSpeed);
                    if(hasWalkZone==true && transform.position.y>maxWalkPoint.y)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    break;

                case 1:
                    myRigidBody.velocity = new Vector2(moveSpeed,0f);
                    if (hasWalkZone==true && transform.position.x > maxWalkPoint.x)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    break;

                case 2:
                    myRigidBody.velocity = new Vector2(0f, -moveSpeed);
                    if (hasWalkZone==true && transform.position.y < minWalkPoint.y)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    break;

                case 3:
                    myRigidBody.velocity = new Vector2(-moveSpeed, 0f);
                    if (hasWalkZone==true && transform.position.x < minWalkPoint.x)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                   
                    break;
            }
        }
        else
        {
            waitCounter -= Time.deltaTime;
            myRigidBody.velocity = Vector2.zero;
            if(waitCounter<0)
            {
                ChooseDirection();
            }
        }
	}

    public void ChooseDirection()
    {
        WalkDirection = Random.Range(0, 4);
        isWalking = true;
        walkCounter = walkTime;
    }
}
