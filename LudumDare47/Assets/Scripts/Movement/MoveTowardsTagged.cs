using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsTagged : MonoBehaviour
{
    [SerializeField] string tag;
    [SerializeField] float speed;
    [SerializeField] bool moveAtSpawn;
    private Transform target;
    private bool isMoving = false;

    private void Awake()
    {
        if (moveAtSpawn)
        {
            target = GameObject.FindGameObjectWithTag(tag).transform;
            isMoving = true;
        }
    }

    private void Update()
    {
        Vector3 dir = (target.position - transform.position).normalized;
        transform.position += dir * speed * Time.deltaTime;
    }

    public void startMoving(Transform moveTarget)
    {
        target = moveTarget;
        isMoving = true;
    }
}
