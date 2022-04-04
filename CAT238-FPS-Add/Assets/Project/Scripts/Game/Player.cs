using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Visual")]
    public Camera playerCamera;
    [Header("Gameplay")]
    public int initialAmmo = 12;
    private int ammo;
    public int Ammo { get { return ammo; } }

    public float knockbackForce = 10f;
    private bool isHurt;
    public float hurtDuration = 0.5f;
    public int initialHealth = 100;
    private int health;
    public int Health { get { return health; } }


    // Start is called before the first frame update
    void Start()
    {
        health = initialHealth;
        ammo = initialAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        // Mouse Click
        if (Input.GetMouseButtonDown(0))
        {
            if (ammo > 0)
            {
                // Decrease the ammo
                ammo--;
                // Object Pooling Scripts + Creating a bullet
                GameObject bulletObject = ObjectPoolingManager.Instance.GetBullet();
                bulletObject.transform.position = playerCamera.transform.position + transform.forward;
                bulletObject.transform.forward = playerCamera.transform.forward;
            }

        }
    }
    void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.GetComponent<AmmoCrate>() != null)
        {
            // Get Ammo and Store it here and ready for it use
            AmmoCrate ammoCrate = otherCollider.GetComponent<AmmoCrate>();
            // Add Ammo
            ammo += ammoCrate.ammo;
            // Destroy the AmmoCrate Object
            Destroy(ammoCrate.gameObject);
        }
        else if (otherCollider.GetComponent<Enemy>() != null)
        {
            // Get Enemy and ready for it use
            Enemy enemy = otherCollider.GetComponent<Enemy>();
            // Taking a damage
            health -= enemy.damage;

        }
    }

}