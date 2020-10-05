using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showIfTargetIsOnScreen : MonoBehaviour
{
    [SerializeField] SpriteRenderer[] spritesToHide;
    [SerializeField] Transform objectToCheck;
    [SerializeField] bool hideIfHidden;

    private void Update()
    {
        Vector3 screenPoint = Camera.main.WorldToViewportPoint(objectToCheck.position);
        bool onScreen = screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
        
        if (onScreen)
        {
            foreach(SpriteRenderer sprite in spritesToHide)
            {
                sprite.enabled = hideIfHidden;
            }
        }
        else
        {
            foreach (SpriteRenderer sprite in spritesToHide)
            {
                sprite.enabled = !hideIfHidden;
            }
        }
    }
}
