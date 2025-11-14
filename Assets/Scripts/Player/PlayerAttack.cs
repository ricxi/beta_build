using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerAttack : MonoBehaviour
{
    private Projectile currentWeapon;
    [SerializeField] private Projectile bulletPrefab;
    [SerializeField] private Transform gunpoint;

    private void Start()
    {
        if (bulletPrefab != null) currentWeapon = bulletPrefab;
        else Debug.LogError("Missing: currentWeapon must have Projectile reference default.");
    }

    private void FixedUpdate()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }

    public void Fire()
    {
        GameObject gameObject = Instantiate(currentWeapon.gameObject, gunpoint.position, Quaternion.identity);
    }

    public void SwitchWeapon(Projectile projectilePrefab)
    {
        currentWeapon = projectilePrefab;
    }

    public void ResetToBaseWeapon()
    {
        currentWeapon = bulletPrefab;
    }
}
