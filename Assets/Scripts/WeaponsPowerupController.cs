using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsPowerupController : MonoBehaviour
{
    [SerializeField] private Projectile projectilePrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerAttack player = collision.gameObject.GetComponent<PlayerAttack>();
        if (player != null)
        {
            player.SwitchWeapon(projectilePrefab);
            Destroy(gameObject);
        }
    }
}
