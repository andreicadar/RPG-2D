using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonoBehaviour {

    public float moveSpeed;

    private Rigidbody2D myRigidBody;

    private bool moving;

    public float timeBetweenMove;
    public float timeBetweenMoveCounter;
    public float timeToMove;
    private float timeToMoveCounter;

    private Vector3 moveDirection;

    public float waitToReload;
    private bool reloading;
    private GameObject thePlayer;
    public float SlowTime;
    public float SlowTimeCounter;
    public bool isSlowed;
    public int slowPercent;
    private float intMoveSpeed;

    public Collider2D walkArea;
    private Vector2 min;
    private Vector2 max;

    void Start ()
    {
        
        if (gameObject.name == "slime_green(Clone)")
        {
            walkArea = GameObject.Find("GreenSlimeWalkArea").GetComponent<Collider2D>() ;

        }
        else
            if (gameObject.name == "slime_red(Clone)")
        {
            walkArea = GameObject.Find("RedSlimeWalkArea").GetComponent<Collider2D>();

        }
        if (gameObject.name == "slime_purple(Clone)")
                                 
        {
            walkArea = GameObject.Find("PurpleSlimeWalkArea").GetComponent<Collider2D>();
                                        

        }
        if(gameObject.name == "SandGolem(Clone)")
        {
            walkArea = GameObject.Find("MovementArea").GetComponent<Collider2D>();
        }
        min = walkArea.bounds.min;
        max = walkArea.bounds.max;
        myRigidBody = GetComponent<Rigidbody2D>();

        timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
        timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeToMove * 1.25f);
        intMoveSpeed = moveSpeed;

      

    }
	
	
	void Update ()
    {
        if(isSlowed)
        {
            if (SlowTimeCounter == SlowTime)
                moveSpeed = (intMoveSpeed * 100 - slowPercent*intMoveSpeed) / 100;
            SlowTimeCounter -= Time.deltaTime;
            if(SlowTimeCounter<=0)
            {
                isSlowed = false;
                SlowTimeCounter = SlowTime;
                moveSpeed = intMoveSpeed;
            }
        }
        if (moving)
        {
            timeToMoveCounter -= Time.deltaTime;
           // Debug.Log(timeToMoveCounter);
            myRigidBody.velocity = moveDirection;
            if(timeToMoveCounter<0f)
            {
                moving = false;
                timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);

            }
        }
        else
        {
            timeBetweenMoveCounter -= Time.deltaTime;
            
            myRigidBody.velocity = Vector2.zero;

            if(timeBetweenMoveCounter<0f)
            {
                moving = true;
                timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeToMove * 1.25f);
                if(gameObject.transform.position.x>max.x)
                {
                    moveDirection = new Vector3(-1* moveSpeed, 0, 0f);

                }
                else
                    if(gameObject.transform.position.x<min.x)
                {
                    moveDirection = new Vector3(1 * moveSpeed, 0, 0f);
                }
                else
                     if (gameObject.transform.position.y > max.y)
                {
                    moveDirection = new Vector3(0,-1 * moveSpeed, 0f);
                }
                else
                     if (gameObject.transform.position.y < min.y)
                {
                    moveDirection = new Vector3(0, 1 * moveSpeed, 0f);
                }
                else

                    moveDirection = new Vector3(Random.Range(-1f, 1f)*moveSpeed, Random.Range(-1f, 1f)*moveSpeed, 0f);
                
            }
        }

        if(reloading)
        {
            waitToReload -= Time.deltaTime;
            if(waitToReload<0)
            {
                Application.LoadLevel(Application.loadedLevel);
                thePlayer.SetActive(true);
            }
        }
	}
  public void slow(int percent)
    {

        isSlowed = true;
        
        
    }
}
