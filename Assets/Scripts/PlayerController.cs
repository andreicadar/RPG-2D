using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    
    public float moveSpeed;
    private float currentMoveSpeed;

    public Animator anim;
    private Rigidbody2D myRigidBody;

    public bool playerMoving;
    public Vector2 lastMove;
    private Vector2 moveInput;

    private static bool playerExists=false;

    public bool atacking;
    public float atackTime;
    private float atackTimeCounter;

    public string startPoint;

    public bool canMove = true;

    private SFXManager sfxMan;
    public bool canAtack;
    public float slowTime;
    public float defaultMoveSpeed;
    public int percentOfSpeed;
    public QuickInventory qv;
    public GameObject shop;
    public GameObject ds;
    public TextMesh name;
    private Rigidbody2D rigi;
    public PlayerHealthManager ph;
    public PlayerStats ps;

    public string lastlvl;
   // public string Point;

    


    void Start ()
    {
        gameObject.transform.position = new Vector3(4.39f, -8f, 0f);
        rigi = GetComponent<Rigidbody2D>();

        Scene scene = SceneManager.GetActiveScene();

        if (PlayerPrefs.HasKey("name"))
        {
            name.text = PlayerPrefs.GetString("name");

        }
        else
        {
            PlayerPrefs.SetString("name", "Mircea");
            {
                name.text = "Mircea";

            }
        }
      //  Debug.Log(PlayerPrefs.GetString("name"));

        if (PlayerPrefs.HasKey("lastlvl"))
        {
            lastlvl = PlayerPrefs.GetString("lastlvl");
        }
        else
        {
            PlayerPrefs.SetString("lastlvl", "Village");
            {
                lastlvl = "Village";

            }
        }
       
        

        /*if(scene.name!= (PlayerPrefs.GetString("lastlvl")))
        Application.LoadLevel(PlayerPrefs.GetString("lastlvl"));*/

        defaultMoveSpeed = moveSpeed;
        sfxMan = FindObjectOfType<SFXManager>();

        anim = GetComponent<Animator>();
        
        myRigidBody = GetComponent<Rigidbody2D>();
        
        if(!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        canMove = true;
        lastMove = new Vector2(0, -1f);
        if (name.text == "bani")
            ps.money += 1000;
        //Debug.Log(name.text);
    }

    void Update()
    {
        if (PlayerPrefs.GetString("name") != name.text)
        {
            name.text = PlayerPrefs.GetString("name");
            

        }

        if (ds.active == true && Input.GetKeyDown("escape") && ph.playerCurrentHealth>0)
        {
            ds.SetActive(false);
        }
        else
        if (ds.active == false)
        {
            if (Input.GetKeyDown("escape"))
                ds.SetActive(true);
                if (slowTime > 0)
            {
                if (moveSpeed == defaultMoveSpeed)
                    ChangeMoveSpeed(percentOfSpeed);
                slowTime -= Time.deltaTime;
            }
            else
            {
                slowTime = 0;
                moveSpeed = defaultMoveSpeed;
            }
            playerMoving = false;

            if (!canMove)
            {
                myRigidBody.velocity = Vector2.zero;
                return;
            }

            if (!atacking)
            {
                moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

                if (moveInput != Vector2.zero)
                {
                    myRigidBody.velocity = new Vector2(moveInput.x * moveSpeed, moveInput.y * moveSpeed);
                    playerMoving = true;
                    lastMove = moveInput;
                }
                else
                {
                    myRigidBody.velocity = Vector2.zero;
                }
                if (Input.GetMouseButtonDown(0) && canAtack == true && shop.active == false)
                {
                    atackTimeCounter = atackTime;
                    atacking = true;
                    myRigidBody.velocity = Vector2.zero;
                    anim.SetBool("Attack", true);
                    sfxMan.playerAttack.Play();
                }
                else if (Input.GetMouseButtonDown(0) && shop.active == false)
                {
                    qv.SeeBuff();
                }

            }

            if (atackTimeCounter > 0)
            {
                atackTimeCounter -= Time.deltaTime;
            }

            else
            {
                atacking = false;
                anim.SetBool("Attack", false);
            }

            anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
            anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
            anim.SetBool("PlayerMoving", playerMoving);
            anim.SetFloat("LastMoveX", lastMove.x);
            anim.SetFloat("LastMoveY", lastMove.y);
        }
    }
    public void ChangeMoveSpeed(int percent)
    {

        moveSpeed = (defaultMoveSpeed * 100 + percent*defaultMoveSpeed) / 100;
    }
    public void StopPlayer()
    {
        rigi.velocity = Vector2.zero;
    }
}
