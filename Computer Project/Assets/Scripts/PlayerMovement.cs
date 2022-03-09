using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

    public float speed;
    public float force;
    public int damage;

    public Scene currentScene;


    public bool attacking;

    private Vector3 change;

    Rigidbody2D playerRB;

    Combat combat;

    Combat currentSlime;

    PlayerStats stats;

    private Animator playerAnimator;

    // Use this for initialization
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        playerRB = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();

        if(currentScene.name == "House" || currentScene.name == "OutsideOfHouse")
        {

        }
        else
        {
            combat = GameObject.FindGameObjectWithTag("Slime").GetComponent<Combat>();
        }

        stats = GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        damage = stats.attackPoints;

        if (change != Vector3.zero)
        {
            CharacterMovement();
            playerAnimator.SetFloat("MovementX", change.x);
            playerAnimator.SetFloat("MovementY", change.y);
            playerAnimator.SetBool("MovingBool", true);
            playerRB.isKinematic = false;
        }
        else
        {
            playerAnimator.SetBool("MovingBool", false);
        }

        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StopCoroutine("PlayerAttacking");
            attacking = true;
            StartCoroutine("PlayerAttacking");
        }
        if (Input.GetKeyDown(KeyCode.V))
        {

        }
    }

    void CharacterMovement()
    {
        playerRB.MovePosition(transform.position + change.normalized * speed * Time.deltaTime);
    }

    IEnumerator PlayerAttacking()
    {
        playerAnimator.SetBool("AttackingBool", true);
        yield return new WaitForSeconds(0.2f);
        playerAnimator.SetBool("AttackingBool", false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Slime") && attacking)
        { 
            Rigidbody2D Slime = collision.GetComponent<Rigidbody2D>();
            currentSlime = collision.GetComponent<Combat>();
            if (Slime != null)
            {
                Slime.isKinematic = false;
                Vector2 distance = Slime.transform.position - transform.position;
                distance = distance.normalized * force;
                Slime.AddForce(distance, ForceMode2D.Impulse);
                StartCoroutine(KnockBack(Slime));
                if (attacking)
                {
                    attacking = false;
                    currentSlime.TakeDamage(damage);
                }
            }
            
        }
    }
    private IEnumerator KnockBack(Rigidbody2D Slime)
    {
        if (Slime != null)
        {
            yield return new WaitForSeconds(0.25f);
            Slime.velocity = Vector2.zero;
            Slime.isKinematic = true;
        }
    }



}
