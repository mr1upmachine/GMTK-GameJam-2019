﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTower : MonoBehaviour
{
    public float minTimeToFire;
    public float maxTimeToFire;
    public int projectileCount = 6;
    public GameObject projectile;

    private float nextFire;
    private float degreesBetweenProjectiles;
    private Health health;
    public int damage = 1;

    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Health>();
        nextFire = Time.time + Random.Range(minTimeToFire, maxTimeToFire);
        degreesBetweenProjectiles = 360 / projectileCount;
    }

    // Update is called once per frame
    void Update()
    {
        ColorState color = GameManager.instance.colorState;
        //Randomly fire in intervals set between two different variables
        if(gameObject.tag.Equals(color.ToString()) && Time.time >= nextFire && !health.dead)
        {
            nextFire = Time.time + Random.Range(minTimeToFire, maxTimeToFire);
            Fire();
        }
    }

    void OnCollisionEnter2D (Collision2D hitInfo)
    {
        //Ensures projectiles fired by enemies don't damage other enemys
        if(hitInfo.gameObject.tag == gameObject.tag || health.dead){
            return;
        }

        if(hitInfo.gameObject.tag != "Arena")
        {
            //check if colliding option has health script and deal damage if it does
            Health health = hitInfo.gameObject.GetComponent<Health>();
            if(health != null)
            {
                health.TakeDamage(damage);
            }
        }
    }

    void Fire()
    {
        for(int i = 1; i <= projectileCount; i++)
        {
            float projectileRotationZ = transform.eulerAngles.z + (degreesBetweenProjectiles * i);
            Quaternion rotation = Quaternion.Euler(0, 0, projectileRotationZ);
            GameObject bullet = Instantiate(projectile, transform.position, rotation);
            bullet.tag = gameObject.tag;
        }
    }
}
