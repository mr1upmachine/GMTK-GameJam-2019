using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D body;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;
    public float acceleration = 50.0f;
    public float maxSpeed = 20.0f;
    public int drag = 5;
    public int shootDrag = 25;
    public float shootKnockback = 5f;

    public float fireRate = 0.5f;
    float waitFire;

    public Transform position;
    public GameObject projectile;

    private bool isFiring = false;

    // Start is called before the first frame update
    void Start()
    {
        //get Rigidbody2D on start
        body = GetComponent<Rigidbody2D>();
        body.drag = drag;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        //Get mouse position and face player towards it
        if (GameManager.instance.gameState != GameState.PAUSE)
        {
            Vector3 mouseScreen = Input.mousePosition;
            Vector3 mouse = Camera.main.ScreenToWorldPoint(mouseScreen);
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(mouse.y - transform.position.y, mouse.x - transform.position.x) * Mathf.Rad2Deg - 90);
        }


        if (Input.GetButton("Fire1"))
        {
            Shoot();
            body.drag = shootDrag;

            return;
        }

        body.drag = drag;
    }

    //Used for physics interactions
    void FixedUpdate()
    {
        //keep diagonal movement from being too fast
        if (horizontal != 0 && vertical != 0)
        {
            body.AddForce(new Vector2(horizontal * acceleration * 0.65f, vertical * acceleration * 0.65f));
        } else
        {
            body.AddForce(new Vector2(horizontal * acceleration, vertical * acceleration));
        }

        if (body.velocity.magnitude > maxSpeed)
        {
            body.velocity = body.velocity.normalized * maxSpeed;
            Debug.Log(body.velocity);
        }
    }

    void Shoot()
    {
        //increment firing cooldown
        waitFire += Time.deltaTime;

        //check firing cooldown to ensure projectiles aren't being fired too quickly
        if (waitFire > fireRate)
        {
            waitFire = 0;
            GameObject bullet = Instantiate(projectile, transform.position, transform.rotation);
            bullet.tag = "Player";

            // Pushes the player back slightly when 
            float degreeX = body.rotation * -1f;
            float degreeY = body.rotation;
            float fX = Mathf.Sin(degreeX * Mathf.Deg2Rad);
            float fY = Mathf.Cos(degreeY * Mathf.Deg2Rad);
            float modifiers = acceleration * shootKnockback * -1f;
            body.AddForce(new Vector2(modifiers * fX, modifiers * fY));
        }
    }
}
