using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetInitScript : MonoBehaviour
{
    private float planetScale;
    private float randomScaleMin = 8f;
    private float randomScaleMax = 80f;

    private CircleCollider2D atmoCollider;
    private float atmoColliderRadius;
    private float randomRadiusMin = 1.2f;
    private float randomRadiusMax = 4f;

    public GameObject atmoObject;
    public SpriteRenderer atmoRenderer;
    private float atmoObjScale;

    public Material[] materials;
    public MeshRenderer planetRenderer;

    private float gravity;
    private float randomGravMin = 20f;
    private float randomGravMax = 80f;
    private float percentVariation = 15f;

    // Start is called before the first frame update
    void Awake()
    {

        // Calc atmo etc.
        atmoCollider = GetComponent<CircleCollider2D>();

        planetScale = Random.Range(randomScaleMin, randomScaleMax);
        atmoColliderRadius = Random.Range(
            randomRadiusMin, 
            Mathf.Clamp((randomRadiusMax - Mathf.Log(randomScaleMax, 10)), randomRadiusMin, randomRadiusMax));

        atmoObjScale = atmoColliderRadius * 2;

        transform.localScale = Vector3.one * planetScale;
        atmoCollider.radius = atmoColliderRadius;
        atmoObject.transform.localScale = Vector3.one * atmoObjScale;


        // Calc gravity
        gravity = (planetScale / (randomScaleMax - randomScaleMin) * (randomGravMax - randomGravMin)) 
            + Random.Range((-percentVariation/ (randomScaleMax - randomScaleMin) * (randomGravMax - randomGravMin))
            , (percentVariation / (randomScaleMax - randomScaleMin) * (randomGravMax - randomGravMin)));

        GetComponent<Gravity>().gravity = Mathf.Clamp(gravity, randomGravMin, randomGravMax);

        Color tmpColor = atmoRenderer.color;
        tmpColor.a = Mathf.Clamp(Mathf.Pow((gravity / (randomGravMax - randomGravMin)), 2f) * 30/100, 0.05f, 0.7f);
        atmoRenderer.color = tmpColor;


        // Decide material

        if (materials.Length == 0)
        {
            return;
        }
        else 
        {
            int i = Random.Range(0, materials.Length - 1);

            planetRenderer.sharedMaterial = materials[i];
        }
    }

    public static float RandomGaussian(float minValue = 0.0f, float maxValue = 1.0f)
    {
        float u, v, S;

        do
        {
            u = 2.0f * UnityEngine.Random.value - 1.0f;
            v = 2.0f * UnityEngine.Random.value - 1.0f;
            S = u * u + v * v;
        }
        while (S >= 1.0f);

        // Standard Normal Distribution
        float std = u * Mathf.Sqrt(-2.0f * Mathf.Log(S) / S);

        // Normal Distribution centered between the min and max value
        // and clamped following the "three-sigma rule"
        float mean = (minValue + maxValue) / 2.0f;
        float sigma = (maxValue - mean) / 3.0f;
        return Mathf.Clamp(std * sigma + mean, minValue, maxValue);
    }
}
