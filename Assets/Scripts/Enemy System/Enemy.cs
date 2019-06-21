using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private string name;

    [SerializeField]
    private float speed;

    private Transform player;

    [SerializeField]
    private float maxDistance = 5;

    [SerializeField]
    private float minDistance = 1.5f;

    private float distance;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        player = FindObjectOfType<CharacterController>().gameObject.GetComponent<Transform>();
    }

    private void Update()
    {
        DistanceControl();
    }

    private void DistanceControl()
    {
        distance = Vector3.Distance(transform.position, player.position);
        if (distance <= maxDistance && distance >= minDistance)
        {
            FollowPlayer();
            animator.SetBool("isWalking", true);

        }
        else
        {
            Attack();
            animator.SetBool("isWalking", false); 
        }
    }

    public virtual void FollowPlayer() // Player'i takip etme.
    {
        transform.LookAt(player);
        transform.position += transform.forward * speed / 10 * Time.deltaTime;

    }
    public virtual void Attack()
    {
        // Saldırı işlemleri
    }

}
