using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }




    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.tag=="Player")
        //{
        //    animator.SetTrigger("Attack");
        //}
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            animator.SetTrigger("Attack");
        }
    }
}
