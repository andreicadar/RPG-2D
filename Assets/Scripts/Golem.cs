using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem : MonoBehaviour
{
    public Animator anim;
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
            dist = Vector2.Distance(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), new Vector2(player.transform.position.x, player.transform.position.y));

        if (dist <= (attackRange.radius))
            anim.SetBool("player in range", true);
        else
            anim.SetBool("player in range", false);
        if (canAttack == true)
            anim.SetBool("canpowerup", true);
        if (dist <= (attackRange.radius) && canAttack == true)
        {
            StartCoroutine(waitunitilAnim(2f));
        }
        if(canAttack==false)
        {
            StartCoroutine(waitunitilNextAttack(6f));
        }
        if(anim.GetBool("player in range") == true && anim.GetBool("canpowerup") == true)
        {
            anim.SetBool("Or", true);
        }
        else
        {
            anim.SetBool("Or", false);
        }

    }




    public IEnumerator waitunitilAnim(float time)
    {
       
        yield return new WaitForSeconds(time);

        canAttack = false;
        anim.SetBool("canpowerup", canAttack);

    }
    public IEnumerator waitunitilNextAttack(float time)
    {

        yield return new WaitForSeconds(time);

        canAttack = true;
        anim.SetBool("canpowerup", canAttack);

    }
}

