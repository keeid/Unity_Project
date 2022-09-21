using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator animator;

    [SerializeField]
    private float curHp;
    private float hp = 10;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        curHp = hp;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // �� ���� ������ ����
    public void TakeDamage(int damage)
    {
        if(curHp >= 0)
        {
            curHp -= damage;
        }
        else
        {
            StartCoroutine(OnDie());   

        }

    }

    // �� ���� ����
    IEnumerator OnDie()
    {
        animator.SetTrigger("onDead");
        
        yield return new WaitForSeconds(1f);

        gameObject.SetActive(false);
    }
}
