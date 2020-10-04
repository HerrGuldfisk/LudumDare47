using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateTowardsTagged : MonoBehaviour
{
    [SerializeField] string targetTag;
    [SerializeField] Transform targetTrans;
    private Transform target;

    private void Awake() {
        if (targetTag != "")
        {
            target = GameObject.FindGameObjectWithTag(targetTag).transform;
        }
        else if (targetTrans)
        {
            target = targetTrans;
        }
    }

    void Update()
    {
        if (target)
        {
            Vector3 dir = target.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
