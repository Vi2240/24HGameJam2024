using UnityEngine;
using static UnityEngine.GraphicsBuffer;

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
}
//Previous tries
//Vector2 newPosition = Vector2.MoveTowards(transform.position, target.position, enemySpeed * Time.deltaTime);
//transform.position = newPosition;
