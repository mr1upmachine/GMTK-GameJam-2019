using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D body;

    float horizontalL;
    float verticalL;
    float horizontalR;
    float verticalR;
    float moveLimiter = 0.7f;
    public float runSpeed = 20.0f;

    public float fireRate = 0.5f;
    float waitFire;

    public Transform position;
    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalL = Input.GetAxisRaw("HorizontalL");
        verticalL = Input.GetAxisRaw("VerticalL");

        Vector3 mouseScreen = Input.mousePosition;
        Vector3 mouse = Camera.main.ScreenToWorldPoint(mouseScreen);
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(mouse.y - transform.position.y, mouse.x - transform.position.x) * Mathf.Rad2Deg - 90);

        if(Input.GetButton("Fire1"))
        {
            Shoot();
        }
    }

    void FixedUpdate()
    {
        if(horizontalL != 0 || verticalL != 0)
        {
            horizontalL *= moveLimiter;
            verticalL *= moveLimiter;
        }

        body.velocity = new Vector2(horizontalL * runSpeed, verticalL * runSpeed);
    }

    void Shoot()
    {
        waitFire += Time.deltaTime;

        if(waitFire > fireRate)
        {
            waitFire = 0;
            Instantiate(projectile, transform.position, transform.rotation);

        }
    }
}
