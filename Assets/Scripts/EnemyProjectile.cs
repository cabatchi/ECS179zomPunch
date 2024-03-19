using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed;

    private Transform player;
    private Vector2 target;

    void Start() 
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
    }

    void Update() 
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y) 
        {
            DestroyProjectile();
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