using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBetweenTransforms : MonoBehaviour
{
    [SerializeField] Transform start;
    [SerializeField] Transform target;
    [SerializeField] float moveTime;
    private float currentTime = 0;
    private bool isMoving = false;

    private void Update()
    {
        if (currentTime < moveTime)
        {
            currentTime += Time.deltaTime;
            float moveAmount = currentTime / moveTime;
            transform.position = start.position + (target.position - start.position)*moveAmount;
        }
    }
}
