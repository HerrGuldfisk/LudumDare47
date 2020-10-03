using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveForward : MonoBehaviour
{
    [SerializeField] float startSpeed;
    private float speed;

    private void Awake()
    {
        speed = startSpeed;
    }

    void FixedUpdate()
    {
        transform.Translate(speed*0.01f, 0, 0);
    }

    public void ChangeSpeed(float value)
    {
        speed += value;
    }
}
