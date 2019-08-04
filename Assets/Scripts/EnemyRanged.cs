using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRanged : MonoBehaviour
{
    private Transform target;
    private Rigidbody2D body;
    public float maxSpeed;
    public float minTimeToFire;
    public float maxTimeToFire;
    public GameObject projectile;
    private float nextFire;
    private Health health;

    public int damage = 1;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        health = GetComponent<Health>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        nextFire = Time.time + Random.Range(minTimeToFire, maxTimeToFire);
        InvokeRepeating("RandomMovement", 1.0f, 0.5f);
    }

    void Update() {
        ColorState color = GameManager.instance.colorState;
        //Randomly fire in intervals set between two different variables
        if(gameObject.tag.Equals(color.ToString()) && Time.time >= nextFire && !health.dead)
        {
            nextFire = Time.time + Random.Range(minTimeToFire, maxTimeToFire);
            Fire();
        }
    }

    void FixedUpdate() {
        ColorState color = GameManager.instance.colorState;
        if (gameObject.tag.Equals(color.ToString()) && !health.dead){
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) * Mathf.Rad2Deg - 90);
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
        GameObject bullet = Instantiate(projectile, transform.position, transform.rotation);
        bullet.tag = gameObject.tag;
    }

    void RandomMovement()
    {
        float x = gameObject.transform.position.x;
        float y = gameObject.transform.position.y;

        if(x >= 5)
        {
            if(y >= 5)
            {
                //too close to right and top
                Vector2 randomVector = new Vector2(Random.Range(-25, -5), Random.Range(-25, -5));
                body.AddForce(randomVector);
                body.velocity = Vector3.ClampMagnitude(body.velocity, maxSpeed);
            }else if (y <= -5){
                //too close to right and bottom
                Vector2 randomVector = new Vector2(Random.Range(-25, -5), Random.Range(5, 25));
                body.AddForce(randomVector);
                body.velocity = Vector3.ClampMagnitude(body.velocity, maxSpeed);
            }else{
                //too close to right
                Vector2 randomVector = new Vector2(Random.Range(-25, -5), Random.Range(-10, 10));
                body.AddForce(randomVector);
                body.velocity = Vector3.ClampMagnitude(body.velocity, maxSpeed);
            }
        }else if(x <= -5){
            if(y >= 5)
            {
                //too close to left and top
                Vector2 randomVector = new Vector2(Random.Range(5, 25), Random.Range(-25, -5));
                body.AddForce(randomVector);
                body.velocity = Vector3.ClampMagnitude(body.velocity, maxSpeed);
            }else if (y <= -5){
                //too close to left and bottom
                Vector2 randomVector = new Vector2(Random.Range(5, 25), Random.Range(5, 25));
                body.AddForce(randomVector);
                body.velocity = Vector3.ClampMagnitude(body.velocity, maxSpeed);
            }else{
                //too close to left
                Vector2 randomVector = new Vector2(Random.Range(5, 25), Random.Range(-10, 10));
                body.AddForce(randomVector);
                body.velocity = Vector3.ClampMagnitude(body.velocity, maxSpeed);
            }
        }else{
            //randomly add force in different directions
            Vector2 randomVector = new Vector2(Random.Range(-10, 10), Random.Range(-10, 10));
            body.AddForce(randomVector);
            body.velocity = Vector3.ClampMagnitude(body.velocity, maxSpeed);
        }
    }
}
