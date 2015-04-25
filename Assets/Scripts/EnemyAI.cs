using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    private Transform target;
    [SerializeField]
    private float speed;
    private bool activated = false;

    void Start()
    {
        Physics2D.IgnoreLayerCollision(gameObject.layer, 8);
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (!activated && target.position.x > 450) activated = true;
        if (activated)
        {
            Vector3 dir = (target.position - transform.position).normalized;
            dir = dir * speed * Time.deltaTime;
            transform.position += dir;
        }
    }
}

