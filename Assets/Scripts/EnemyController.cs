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

    public Transform enemyPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyPosition = transform.position;
        xDiff = PlayerController.position.x - ememyPosion.x;
        yDiff = PlayerController.position.y - enemyPosition.y;

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

        GetComponent<Rigidbody2D>().velocity = new Vector2(xVelocity, yVelocity);
    }
}
