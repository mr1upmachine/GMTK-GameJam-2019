using System.Collections;
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

    // Start is called before the first frame update
    void Start()
    {
         nextFire = Time.time + Random.Range(minTimeToFire, maxTimeToFire);
         degreesBetweenProjectiles = 360 / projectileCount;
    }

    // Update is called once per frame
    void Update()
    {
        ColorState color = GameManager.instance.colorState;
        //Randomly fire in intervals set between two different variables
        if(gameObject.tag.Contains(color.ToString()) && Time.time >= nextFire)
        {
            nextFire = Time.time + Random.Range(minTimeToFire, maxTimeToFire);
            Fire();
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
