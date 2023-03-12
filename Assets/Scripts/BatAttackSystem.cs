using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatAttackSystem : MonoBehaviour
{

    private CircleCollider2D attackRange;
    private BoxCollider2D box;
    private bool atacks = false;
    private Vector3 initpos;
    public GameObject player;
    private float dist;
    private bool canAttack;
    private Vector3 iPos;
    private bool moved;
    public float speed;
    private float step;
    private Vector3 pozP;
    public bool HitP;
    private bool Atacking;
    public float timeToWait;


    // Use this for initialization
    void Start()
    {
        attackRange = gameObject.GetComponent<CircleCollider2D>();
        box = gameObject.GetComponent<BoxCollider2D>();
        player = GameObject.Find("Player");
        canAttack = true;
        HitP = false;
        Atacking = false;
    }

    // Update is called once per frame
    void Update()
    {
         step = speed * Time.deltaTime;
            if (Atacking == false)
            {
                dist = Vector2.Distance(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), new Vector2(player.transform.position.x, player.transform.position.y));
                pozP = player.transform.position;
            }
        if(dist<=(attackRange.radius)*7.5f && canAttack == true)
        {
            iPos = gameObject.transform.position;



            if (dist > 0.1 && HitP == false)
            {
                Atacking = true;
                dist = Vector2.Distance(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), new Vector2(pozP.x, pozP.y));
                transform.position = Vector2.MoveTowards(transform.position, pozP, step);
            }
            else
            {
                canAttack = false;
                StartCoroutine(Move(player.transform.position));
                Atacking = false;
            }
        }

    }




    public IEnumerator Move(Vector3 poz)
    {
        yield return new WaitForSeconds(5);
        
        canAttack = true;
        HitP = false;

    }
}
  
