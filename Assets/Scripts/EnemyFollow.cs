using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{

    public float maxSpeed;
    public float stoppingDistance;
    public int damage;

    private Transform target;
    private Rigidbody2D body;
    private ParticleSystem particle;
    private SpriteRenderer sprite;
    private Health eHealth;
    private StateCheck state;


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        eHealth = GetComponent<Health>();
        state = GetComponent<StateCheck>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        particle = GetComponent<ParticleSystem>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        ColorState color = GameManager.instance.colorState;
        if (gameObject.tag.Contains(color.ToString()) && !state.isDisabled && !eHealth.dead){
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) * Mathf.Rad2Deg - 90);
        }
        if(Vector2.Distance(transform.position, target.position) > stoppingDistance)
        {
            Vector2 relativePos = target.position - transform.position;
            body.AddForce(relativePos * 2);
        }

        if(!state.isDisabled)
        {
            body.velocity = Vector3.ClampMagnitude(body.velocity, maxSpeed);
        }
    }

    void OnCollisionEnter2D (Collision2D hitInfo)
    {
        //Ensures projectiles fired by enemies don't damage other enemys
        if(hitInfo.gameObject.tag == gameObject.tag){
            return;
        }

        if(eHealth.dead)
        {
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
            particle.Play();
            sprite.enabled = false;
            Destroy(gameObject, 1.5f);
        }
    }
}
