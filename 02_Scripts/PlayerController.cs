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
            // ���� �������� ȸ��
            transform.rotation = Quaternion.LookRotation(moveDirection);
            // ȸ���� �� ���� �������� �̵�
            transform.Translate(Vector3.forward * Time.deltaTime * 4.0f);
        }
    }

    public void OnMove(InputValue value)
    {
        Vector2 direction = value.Get<Vector2>();
        // 2���� ��ǥ�� 3���� ��ǥ�� ��ȯ
        moveDirection = new Vector3(direction.x,0,direction.y);

        // Warrior Run �ִϸ��̼� ����
        animator.SetFloat("Movement", direction.magnitude);
        Debug.Log($"Move = ({direction.x}, {direction.y})");
    }

    public void OnAttack()
    {
        Debug.Log("Attack");
        animator.SetTrigger("Attack");
    }
}
