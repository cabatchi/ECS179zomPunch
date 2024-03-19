using UnityEngine;

public class HomingBullet : MonoBehaviour
{
    public float speed;

    private Transform player;
    private Vector2 target;
    private float projectileTime = 2f;

    void Start() 
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
    }

    void Update() 
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y) 
        {
            DestroyProjectile();
        }
        if (projectileTime <= 0) 
        {
            DestroyProjectile();
        } 
        else 
        {
            projectileTime -= Time.deltaTime;
        }


    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player")) 
        {
            DestroyProjectile();
        }
    }

    private void DestroyProjectile() 
    {
        Destroy(gameObject);
    }
}