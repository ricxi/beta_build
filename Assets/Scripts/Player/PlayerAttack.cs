using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Projectile bulletPrefab;
    [SerializeField] private Transform gunpoint;
    // [SerializeField] private AudioClip shootSound;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip defaultShootSound;
    private Projectile currentWeapon;
    private AudioClip shootSound;

    private void Start()
    {
        if (bulletPrefab != null) currentWeapon = bulletPrefab;
        else Debug.LogError("Missing: currentWeapon must have Projectile reference default.");

        // if (!audioSource) audioSource = GetComponent<AudioSource>();
        // if (!currentWeapon.ShootSound) shootSound = defaultShootSound;
        // else shootSound = currentWeapon.ShootSound;
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
        audioSource.PlayOneShot(currentWeapon.ShootSound);
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
