using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D body;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;
    public float runSpeed = 20.0f;

    public float fireRate = 0.5f;
    float waitFire;

    public Transform position;
    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        //get Rigidbody2D on start
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        //Get mouse position and face player towards it
        Vector3 mouseScreen = Input.mousePosition;
        Vector3 mouse = Camera.main.ScreenToWorldPoint(mouseScreen);
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(mouse.y - transform.position.y, mouse.x - transform.position.x) * Mathf.Rad2Deg - 90);

        if(Input.GetButton("Fire1"))
        {
            Shoot();
        }
    }

    //Used for physics interactions
    void FixedUpdate()
    {
        //keep diagonal movement from being too fast
        if(horizontal != 0 || vertical != 0)
        {
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        //move player
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }

    void Shoot()
    {
        //increment firing cooldown
        waitFire += Time.deltaTime;

        //check firing cooldown to ensure projectiles aren't being fired too quickly
        if(waitFire > fireRate)
        {
            waitFire = 0;
            GameObject bullet = Instantiate(projectile, transform.position, transform.rotation);
            bullet.tag = "Player";
        }
    }
}
