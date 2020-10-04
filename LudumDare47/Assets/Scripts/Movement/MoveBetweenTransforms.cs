using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBetweenTransforms : MonoBehaviour
{
    [SerializeField] Transform start;
    [SerializeField] Transform target;
    [SerializeField] float moveTime;
    [SerializeField] bool moveAtStart = false;

    private float currentTime = 0;
    private bool isMoving = false;

    private void Awake()
    {
        if (moveAtStart)
        {
            isMoving = true;
        }
    }

    private void Update()
    {
        if (isMoving && currentTime < moveTime)
        {
            currentTime += Time.deltaTime;
            float moveAmount = currentTime / moveTime;
            transform.position = start.position + (target.position - start.position)*moveAmount;
        }
    }

    public void startMoving(Transform moveStart, Transform moveTarget, float time)
    {
        moveTime = time;
        start = moveStart;
        target = moveTarget;
        isMoving = true;
    }
}
