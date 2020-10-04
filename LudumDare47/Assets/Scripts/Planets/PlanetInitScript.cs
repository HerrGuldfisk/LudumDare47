using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetInitScript : MonoBehaviour
{
    private float planetScale;
    private float randomScaleMin = 8f;
    private float randomScaleMax = 100f;

    private CircleCollider2D atmoCollider;
    private float atmoColliderRadius;
    private float randomRadiusMin = 1.1f;
    private float randomRadiusMax = 4f;

    public GameObject atmoObject;
    private float atmoObjScale;

    public Material[] materials;
    public Renderer renderer;

    // Start is called before the first frame update
    void Awake()
    {

        // Calc atmo etc.
        atmoCollider = GetComponent<CircleCollider2D>();

        planetScale = Random.Range(randomScaleMin, randomScaleMax);
        atmoColliderRadius = Random.Range(randomRadiusMin, Mathf.Clamp((randomRadiusMax - Mathf.Log(randomScaleMax, 10)), randomRadiusMin, randomRadiusMax));
        atmoObjScale = atmoColliderRadius * 2;

        transform.localScale = Vector3.one * planetScale;
        atmoCollider.radius = atmoColliderRadius;
        atmoObject.transform.localScale = Vector3.one * atmoObjScale;

        // Decide material

        if (materials.Length == 0)
        {
            return;
        }
        else 
        {
            int i = Random.Range(0, materials.Length - 1);

            renderer.sharedMaterial = materials[i];
        }
    }
}
