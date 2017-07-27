using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.Threading.Tasks;

public class EnemyBehavior : MonoBehaviour
{
    public GameObject Projectile;
    public float Health = 150;
    public float ProjectileSpeed = 10;
    public float ShotsPerSeconds = 0.5f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var probability = Time.deltaTime * ShotsPerSeconds;

        if (Random.value < probability)
        {
            Fire();
        }
    }

    private void Fire()
    {
        var startPosition = transform.position + new Vector3(0, -1f, 0);
        var projectile = Instantiate(Projectile, startPosition, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -ProjectileSpeed);
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
}
