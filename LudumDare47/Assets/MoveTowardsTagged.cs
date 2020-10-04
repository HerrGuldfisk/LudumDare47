using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsTagged : MonoBehaviour
{
    [SerializeField] string tag;
    [SerializeField] float speed;
    private Transform target;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag(tag).transform;
    }

    private void Update()
    {
        Vector3 dir = (target.position - transform.position).normalized;
        transform.position += dir * speed * Time.deltaTime;
    }
}
