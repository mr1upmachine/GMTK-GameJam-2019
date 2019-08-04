using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{

    public float maxSpeed;
    public float stoppingDistance;

    private Transform target;
    private Rigidbody2D body;


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        ColorState color = GameManager.instance.colorState;
        if (gameObject.tag.Contains(color.ToString())){
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) * Mathf.Rad2Deg - 90);
        }
        if(Vector2.Distance(transform.position, target.position) > stoppingDistance)
        {
            Vector2 relativePos = target.position - transform.position;
            body.AddForce(relativePos * 2);
        }

        body.velocity = Vector3.ClampMagnitude(body.velocity, maxSpeed);
    }
}
