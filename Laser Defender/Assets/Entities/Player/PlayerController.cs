using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 15;
    public float padding = 1f;
    public GameObject projectile;
    public float projecttileSpeed = 1;
    public float firingRate = 0.2f;
    public float Health = 250f;

    private float xmin;
    private float xmax;

    // Use this for initialization
    void Start()
    {
        float distance = transform.position.z - Camera.main.transform.position.z;
        var leftMostPoint = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        var rightMostPoint = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));

        xmin = leftMostPoint.x + padding;
        xmax = rightMostPoint.x - padding;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InvokeRepeating("Fire", 0.000001f, firingRate);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            CancelInvoke("Fire");
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.transform.position += Vector3.right * speed * Time.deltaTime;
        }

        var newX = Mathf.Clamp(transform.position.x, xmin, xmax);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var projectile = collision.gameObject.GetComponent<Projectile>();

        if (projectile == null)
        {
            return;
        }

        Health -= projectile.Damage;

        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Fire()
    {
        var startPosition = transform.position + new Vector3(0, 1f, 0);
        var laserBeam = Instantiate(projectile, startPosition, Quaternion.identity);
        laserBeam.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projecttileSpeed);
    }
}
