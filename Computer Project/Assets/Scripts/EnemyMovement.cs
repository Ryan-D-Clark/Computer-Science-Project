using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float range;
    public float speed;
    public bool attacking;

    private Animator anim;

    Transform player;
    Combat combat;
    PlayerStats stats;
    Rigidbody2D playerRB;

    // Use this for initialization
    void Start ()
    {
        combat = GetComponent<Combat>();
        stats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        playerRB = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();

    }
	
	// Update is called once per frame
	void Update ()
    {

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        anim = GetComponent<Animator>();

        if(combat.dead == false)
        {
		    if(Vector2.Distance(transform.position, player.position) > range)
            {
                anim.SetBool("IsIdle",true);
            }

            if (Vector2.Distance(transform.position, player.position) < range)
            {
                anim.SetBool("IsIdle", false);

                if (Vector2.Distance(transform.position, player.position) > 1)
                {
                    anim.SetBool("InRange", true);
                    anim.SetBool("IsAttacking", false);
                    transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
                }

                if (Vector2.Distance(transform.position, player.position) <= 1)
                {
                    anim.SetBool("IsAttacking", true);
                    StartCoroutine("Delay");
                }
            }
        }

        if (combat.dead == true)
        {
            anim.SetBool("IsDead", true);
            Killed();
        }

    }
    public void Killed()
    {
        stats.EXPGain(combat.EXPReward);
        Destroy(gameObject);
    }

    IEnumerator Delay()
    {
        attacking = true;
        yield return new WaitForSeconds(0.75f);
        Attacking();
    }

    void Attacking()
    {
        Vector2 distance = playerRB.transform.position - transform.position;
        distance = distance.normalized;
        playerRB.AddForce(distance, ForceMode2D.Impulse);
        StartCoroutine(Knockback(playerRB));
    }

    private IEnumerator Knockback(Rigidbody2D playerRB)
    {
        yield return new WaitForSeconds(0.25f);
        playerRB.velocity = Vector2.zero;
        playerRB.isKinematic = true;
        if (attacking == true)
        {
            stats.TakeDamage(combat.enemyDamage);
            attacking = false;
            StopCoroutine(Knockback(playerRB));
        }
    }

}







