using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer rendererer;
    

    [SerializeField]
    private float speed = 4.0f;                  // �÷��̾� �̵� �ӵ�
    [SerializeField]
    private float jumpPower = 20.0f;             // �÷��̾� ���� ��
    private bool isJumping = false;              // �÷��̾� ��ġ üũ
    [SerializeField]
    private float curTime = 0;                   // ���� �ð�
    [SerializeField]
    private float coolTime = 0.5f;               // ���� ������ �ð�
    public Transform pos;                        // ���� ���� ��ġ
    public Vector2 boxSize;                      // ���� ���� ũ��
    public int damage = 3;                     // �÷��̾� ���� ������ 


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

    // �÷��̾� �ٴ� üũ
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isJumping = false;
            animator.SetBool("onJump", false);
        }

    }

    // �÷��̾� ������
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

    // �÷��̾� ����
    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // ���� ��� �ִٸ� ����
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

    // �÷��̾� ����
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
    
    // �÷��̾� ���� ���� 
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(pos.position, boxSize);
    }
}


