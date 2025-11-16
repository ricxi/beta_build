using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyController : MonoBehaviour
{
    [SerializeField] public AggroTrigger aggroCollider;
    [SerializeField] private string playerTag = "Player";
    private Transform playerTransform;
    private bool isAggroed = false;

    private void Start()
    {
        if (aggroCollider != null)
            aggroCollider.OnAggroTriggerEnter2D += ChasePlayer;
    }

    void FixedUpdate()
    {
        if (isAggroed && playerTransform != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, 10f * Time.deltaTime);
        }
    }

    public void ChasePlayer(Collider2D collision)
    {
        if (collision.CompareTag(playerTag))
        {
            isAggroed = true;
            playerTransform = collision.transform;
        }
    }

    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     PlayerHealth player = collision.collider.gameObject.GetComponent<PlayerHealth>();
    //     if (player != null)
    //     {
    //         player.TakeDamage(enemyType.damage);
    //     }

    // }
}
