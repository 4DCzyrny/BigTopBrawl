using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneManager : MonoBehaviour
{
    // Movement Things
    float horizontalInput;
    public Vector3 rightOffset = new Vector3(1f, 0f, 0f); 
    public Vector3 leftOffset = new Vector3(-1f, 0f, 0f); 
    public bool isFacingRight = true;
    bool isJumping = false;
    public bool canMove = true;
    Rigidbody2D rb;

    // Attack Things
    public float P1AttackType = 1;
    public bool P1IsAttacking = false;
    public bool P1CanAttack = true;
    public bool P1WasHit = false;
    public bool isBlocking = false;
    public bool canBlock = true;
    public GameObject P1Hitbox;
    public PlayerOneStats playerStats;
    public Transform HitboxPointRight;
    public Transform HitboxPointLeft;
    private Coroutine attackCoroutine;

    // Animation Things
    public Animator playerAnim;

    void Start()
    {
        // Movement
        rb = GetComponent<Rigidbody2D>();
        // Attacks
        P1Hitbox.SetActive(false);
        UpdateHitboxPosition();
    }

    // Update is called once per frame
    void Update()
    {
        // Movement
        horizontalInput = Input.GetAxis("P1Horizontal");

        FlipSprite();

        if (Input.GetButtonDown("P1Jump") && !isJumping && canMove)
        {
            rb.velocity = new Vector2(rb.velocity.x, playerStats.jump);
            isJumping = true;
        }

        if (!canMove)
        {
            rb.gravityScale = 0;
        }
        else
        {
            rb.gravityScale = 2;
        }

        HitboxPointRight.position = transform.position + rightOffset;
        HitboxPointLeft.position = transform.position + leftOffset;

        // Attacks
        if (Input.GetKeyDown(KeyCode.F) && !P1IsAttacking && P1CanAttack)
        {
            StartCoroutine(P1LightAttack());
            P1IsAttacking = true;
            P1AttackType = 1;
        }
        if (Input.GetKeyDown(KeyCode.G) && !P1IsAttacking && P1CanAttack)
        {
            StartCoroutine(P1HeavyAttack());
            P1IsAttacking = true;
            P1AttackType = 2;
        }
        if (Input.GetKeyDown(KeyCode.E) && canBlock)
        {
            isBlocking = true;
            canMove = false;
            P1CanAttack = false;
        }
        if (Input.GetKeyUp(KeyCode.E) && isBlocking)
        {
            isBlocking = false;
            canMove = true;
            P1CanAttack = true;
        }
    }

    private void FixedUpdate()
    {
        // Movement
        if (canMove)
        {
            if (horizontalInput != 0)
            {
                rb.velocity = new Vector2(horizontalInput * playerStats.speed, rb.velocity.y);
                playerAnim.SetBool("isWalking", true);
            }
            else
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
                playerAnim.SetBool("isWalking", false);
            }
        }
    }

    // Movement Functions
    void FlipSprite()
    {
        if (isFacingRight && canMove && horizontalInput < 0f || !isFacingRight && canMove && horizontalInput > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;
            UpdateHitboxPosition();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isJumping = false;
    }

    // Attack Functions
    public IEnumerator P1LightAttack()
    {
        UpdateHitboxPosition();
        canMove = false;
        canBlock = false;
        P1Hitbox.SetActive(true);
        yield return new WaitForSeconds((float)0.75);
        P1Hitbox.SetActive(false);
        P1IsAttacking = false;
        canMove = true;
        canBlock = true;
        yield break;
    }

    public IEnumerator P1HeavyAttack()
    {
        UpdateHitboxPosition();
        canMove = false;
        canBlock = false;
        yield return new WaitForSeconds((float)1.5);
        if (!P1WasHit)
        {
            P1Hitbox.SetActive(true);
            yield return new WaitForSeconds((float)0.5);
        }
        P1Hitbox.SetActive(true);
        yield return new WaitForSeconds((float)0.5);
        P1Hitbox.SetActive(false);
        P1IsAttacking = false;
        canMove = true;
        canBlock = true;
        yield break;
    }

    public void TakeDamage(float damage)
    {
        if (isBlocking)
        {
            playerStats.health -= damage * playerStats.blockScore;
        }
        else
        {
            playerStats.health -= damage;
            P1CanAttack = false;
            P1WasHit = true;
            canMove = false;
            canBlock = false;
            if (attackCoroutine != null)
            {
                StopCoroutine(attackCoroutine);
            }
            attackCoroutine = StartCoroutine(P1AttackCapable());
        }    
    }

    public IEnumerator P1AttackCapable()
    {
        yield return new WaitForSeconds(1);
        P1WasHit = false;
        P1CanAttack = true;
        canMove = true;
        canBlock = true;
        attackCoroutine = null;
        yield break;
    }
    
    void UpdateHitboxPosition()
    {
        if (isFacingRight && !P1IsAttacking)
        {
            P1Hitbox.transform.position = HitboxPointRight.position;
            P1Hitbox.transform.rotation = HitboxPointRight.rotation;
        }
        else if (!isFacingRight && !P1IsAttacking)
        {
            P1Hitbox.transform.position = HitboxPointLeft.position;
            P1Hitbox.transform.rotation = HitboxPointLeft.rotation;
        }
    }
}
