using UnityEngine;
public class EnemyScript : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float enemySpeed = 1.0f;

    [Header("Health")]
    [SerializeField] float maxHealth = 100f;

    Transform target;

    void Start()
    {
        target = FindObjectOfType<Tower>().transform;
    }

    void Update()
    {
        EnemyMovement();
    }

    void EnemyMovement()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, enemySpeed * Time.deltaTime);
        transform.up = target.transform.position - transform.position;
    }

    void EnemyHealth()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            enemySpeed = 0f;
            Debug.Log("I have collided!");
            Destroy(this.gameObject);
        }
    }
}
//Previous tries
//Vector2 newPosition = Vector2.MoveTowards(transform.position, target.position, enemySpeed * Time.deltaTime);
//transform.position = newPosition;
