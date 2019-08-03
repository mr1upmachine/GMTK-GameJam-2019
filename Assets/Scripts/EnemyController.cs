using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float enemySpeed = 1;
    public float xVelocity;
    public float yVelocity;

    public float xDiff;
    public float yDiff;

    public GameObject playerRef;

    public Vector2 enemyPosition;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        enemyPosition = transform.position;
        xDiff = playerRef.transform.position.x - enemyPosition.x;
        yDiff = playerRef.transform.position.y - enemyPosition.y;

        if (xDiff > 0)
        {
            xVelocity = enemySpeed;
        }
        if (xDiff < 0)
        {
            xVelocity = -enemySpeed;
        }

        if (yDiff > 0)
        {
            yVelocity = enemySpeed;
        }
        if (yDiff < 0)
        {
            yVelocity = -enemySpeed;
        }

        Move();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 8)
        {
            //xVelocity = Random.Range(-1, 1) * 2;
            yVelocity = 10;
            Move();
        }
    }

    private void Move()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(xVelocity, yVelocity);
    }
}
