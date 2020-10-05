using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCloseAttack : MonoBehaviour
{
    private Animator animator;
    private List<GameObject> isCloseList;
    private int isAttackingKey;

    void Start()
    {
        isCloseList = new List<GameObject>();
        animator = GetComponentInChildren<Animator>();
        isAttackingKey = Animator.StringToHash("IsAttacking");
    }

    
    void Update()
    {
        if(isCloseList.Count > 0)
        {
            Debug.Log("te ataco");
            animator.SetBool(isAttackingKey, true);
        }
        else
        {
            animator.SetBool(isAttackingKey, false);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            isCloseList.Add(collision.gameObject);

        }

    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isCloseList.Remove(collision.gameObject);
        }

    }
}
