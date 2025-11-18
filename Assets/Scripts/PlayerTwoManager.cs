using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerTwoManager : MonoBehaviour
{
    // Movement Things
    float horizontalInput;
    public Vector3 rightOffset = new Vector3(1f, 0f, 0f); 
    public Vector3 leftOffset = new Vector3(-1f, 0f, 0f); 
    bool isFacingRight = false;
    bool isJumping = false;
    public bool canMove = true;
    Rigidbody2D rb;

    // attack things
    public float P2AttackType = 1;
    public bool P2IsAttacking = false;
    public bool P2CanAttack = true;
    public bool P2WasHit = false;
    public bool isBlocking = false;
    public bool canBlock = true;
    public GameObject P2Hitbox;
    public PlayerTwoStats playerStats;
    public Transform HitboxPointRight;
    public Transform HitboxPointLeft;
    private Coroutine attackCoroutine;
    public PlayerOneStats player1Stats;
    // Block Effect Things
    public SpriteRenderer playerSpriteR;
    private Color originalColor;
    public Color blockColor = Color.blue; 
    public float effectDuration = 1f;
    public float fadeOutDuration = 0.5f;
    private Coroutine blockCo;

    void Start()
    {
        // Movement
        rb = GetComponent<Rigidbody2D>();
        // Attacks
        P2Hitbox.SetActive(false);
        UpdateHitboxPosition();
        originalColor = playerSpriteR.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        // Movement
        horizontalInput = Input.GetAxis("P2Horizontal");

        FlipSprite();

        if (Input.GetButtonDown("P2Jump") && !isJumping && canMove)
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
        if (Input.GetKeyDown(KeyCode.K) && !P2IsAttacking && P2CanAttack)
        {
            StartCoroutine(P2LightAttack());
            P2IsAttacking = true;
            P2AttackType = 1;
        }
        if (Input.GetKeyDown(KeyCode.L) && !P2IsAttacking && P2CanAttack)
        {
            StartCoroutine(P2HeavyAttack());
            P2IsAttacking = true;
            P2AttackType = 2;
        }
        if (Input.GetKeyDown(KeyCode.P) && canBlock)
        {
            isBlocking = true;
            canMove = false;
            P2CanAttack = false;
        }
        if (Input.GetKeyUp(KeyCode.P) && isBlocking)
        {
            isBlocking = false;
            canMove = true;
            P2CanAttack = true;
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
            }
            else
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
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
    public IEnumerator P2LightAttack()
    {
        UpdateHitboxPosition();
        canMove = false;
        canBlock = false;
        P2Hitbox.SetActive(true);
        yield return new WaitForSeconds(playerStats.attackSpeed);
        P2Hitbox.SetActive(false);
        P2IsAttacking = false;
        canMove = true;
        canBlock = true;
        yield break;
    }
    
    public IEnumerator P2HeavyAttack()
    {
        UpdateHitboxPosition();
        canMove = false;
        canBlock = false;
        yield return new WaitForSeconds(playerStats.heavySpeed);
        if (!P2WasHit)
        {
            P2Hitbox.SetActive(true);
            yield return new WaitForSeconds(playerStats.attackSpeed);
        }
        P2Hitbox.SetActive(false);
        P2IsAttacking = false;
        canMove = true;
        canBlock = true;
        yield break;
    }

    public void TakeDamage(float damage, int latCtr)
    {
        if (isBlocking || latCtr >= player1Stats.canHitAmount)
        {
            playerStats.health -= damage * playerStats.blockScore;
            if (blockCo != null)
            {
                StopCoroutine(blockCo);
            }
            blockCo = StartCoroutine(BlockEffect());
        }
        else
        {
            playerStats.health -= damage;
            P2CanAttack = false;
            P2WasHit = true;
            canMove = false;
            canBlock = false;
            if (attackCoroutine != null)
            {
                StopCoroutine(attackCoroutine);
            }
            attackCoroutine = StartCoroutine(P2AttackCapable());
        }
    }

    public IEnumerator P2AttackCapable()
    {
        yield return new WaitForSeconds(1);
        P2WasHit = false;
        P2CanAttack = true;
        canMove = true;
        canBlock = true;
        attackCoroutine = null;
        yield break;
    }

    public IEnumerator BlockEffect()
    {
        playerSpriteR.material.color = blockColor;
        yield return new WaitForSeconds(effectDuration);
        float timer = 0f;
        while (timer < fadeOutDuration)
        {
            timer += Time.deltaTime;
            playerSpriteR.material.color = Color.Lerp(blockColor, originalColor, timer / fadeOutDuration);
            yield return null;
        }
        playerSpriteR.material.color = originalColor;
    }
    
    void UpdateHitboxPosition()
    {
        if (isFacingRight)
        {
            P2Hitbox.transform.position = HitboxPointRight.position;
            P2Hitbox.transform.rotation = HitboxPointRight.rotation;
        }
        else
        {
            P2Hitbox.transform.position = HitboxPointLeft.position;
            P2Hitbox.transform.rotation = HitboxPointLeft.rotation;
        }
    }
}
