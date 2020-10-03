using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateTowardsTagged : MonoBehaviour
{
    [SerializeField] string tag;
    private Transform objectTransform;

    private void Awake() {
        objectTransform = GameObject.FindGameObjectWithTag(tag).transform;
    }

    void Update()
    {
        Vector3 dir = objectTransform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
