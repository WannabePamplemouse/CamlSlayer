using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    private Transform target;
    [SerializeField]
    private float speed;

    void Start()
    {
        Physics2D.IgnoreLayerCollision(gameObject.layer, 8);
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        Vector3 dir = (target.position - transform.position).normalized;
        dir = dir * speed * Time.deltaTime;
        transform.position += dir;
    }
}

