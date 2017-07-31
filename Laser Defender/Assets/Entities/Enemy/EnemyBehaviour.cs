using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public GameObject Projectile;
    public float Health = 150;
    public float ProjectileSpeed = 10;
    public float ShotsPerSeconds = 0.5f;
    public int ScoreValue = 150;
    public AudioClip FireSound;
    public AudioClip DeadSound;

    private ScoreKeeper scoreKeeper;

    // Use this for initialization
    void Start()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
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
        var projectile = Instantiate(Projectile, transform.position, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -ProjectileSpeed);
        AudioSource.PlayClipAtPoint(FireSound, transform.position);
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
            Die();
        }
    }

    private void Die()
    {
        AudioSource.PlayClipAtPoint(DeadSound, transform.position);
        Destroy(gameObject);
        scoreKeeper.Score(ScoreValue);
    }
}
