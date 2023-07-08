using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Camera cameraPlayers;
    [SerializeField] private ShootProjectile shootProjectile;
    [SerializeField] private float maxDistanceAttack = 1000f;
    [SerializeField] private float fireRate = 4f;

    private float timeToFire;

    void Update()
    {
        if (Input.GetButton("Fire1")&& Time.time >= timeToFire)
        {
            timeToFire = Time.time+1/fireRate;
            shootProjectile.Attack(cameraPlayers, maxDistanceAttack);
        }
    }
}
