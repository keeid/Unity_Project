using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private new Transform transform;
    private Vector3 moveDirection;

    private void Start()
    {
        animator = GetComponent<Animator>();
        transform = GetComponent<Transform>();
    }

    private void Update()
    {
        if(moveDirection != Vector3.zero)
        {
            // 진행 방향으로 회전
            transform.rotation = Quaternion.LookRotation(moveDirection);
            // 회전한 후 전진 방향으로 이동
            transform.Translate(Vector3.forward * Time.deltaTime * 4.0f);
        }
    }

    public void OnMove(InputValue value)
    {
        Vector2 direction = value.Get<Vector2>();
        // 2차원 좌표를 3차원 좌표로 변환
        moveDirection = new Vector3(direction.x,0,direction.y);

        // Warrior Run 애니메이션 실행
        animator.SetFloat("Movement", direction.magnitude);
        Debug.Log($"Move = ({direction.x}, {direction.y})");
    }

    public void OnAttack()
    {
        Debug.Log("Attack");
        animator.SetTrigger("Attack");
    }
}
