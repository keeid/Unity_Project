using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer rendererer;
    

    [SerializeField]
    private float speed = 4.0f;                  // 플레이어 이동 속도
    [SerializeField]
    private float jumpPower = 20.0f;             // 플레이어 점프 힘
    private bool isJumping = false;              // 플레이어 위치 체크
    [SerializeField]
    private float curTime = 0;                   // 현재 시간
    [SerializeField]
    private float coolTime = 0.5f;               // 공격 딜레이 시간
    public Transform pos;                        // 공격 범위 위치
    public Vector2 boxSize;                      // 공격 범위 크기
    public int damage = 3;                     // 플레이어 공격 데미지 


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        rendererer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
       
    }

    void Update()
    {
        Jump();
        Attack();
    }

    void FixedUpdate()
    {
        Move();

    }

    // 플레이어 바닥 체크
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isJumping = false;
            animator.SetBool("onJump", false);
        }

    }

    // 플레이어 움직임
    public void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(x * speed, rb.velocity.y);

        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            rendererer.flipX = false;
            animator.SetBool("onRun", true);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            rendererer.flipX = true;
            animator.SetBool("onRun", true);
        }
        else
        {
            animator.SetBool("onRun", false);
        }



    }

    // 플레이어 점프
    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // 땅에 닿아 있다면 점프
            if (!isJumping)
            {
                isJumping = true;
                rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);

                animator.SetBool("onJump", true);
            }
            else
            {
                return;
            }

        }

    }

    // 플레이어 공격
    public void Attack()
    {
        if (curTime <= 0)
        {

            if (Input.GetMouseButtonDown(0))
            {
                Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, boxSize, 0);
                foreach (Collider2D collider in collider2Ds)
                {
                    if(collider.CompareTag("Enemy"))
                    {
                        collider.GetComponent<Enemy>().TakeDamage(damage);
                    }
                }

                animator.SetBool("onAttack", true);

                curTime = coolTime;
            }

        }
        else
        {
            animator.SetBool("onAttack", false);
            curTime -= Time.deltaTime;
        }
        
    }
    
    // 플레이어 공격 범위 
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(pos.position, boxSize);
    }
}


