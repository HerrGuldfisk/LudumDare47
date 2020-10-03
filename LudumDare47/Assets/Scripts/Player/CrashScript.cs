using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashScript : MonoBehaviour
{
    GameObject gameObject;

    void Crash()
    {
        Debug.Log("You crashed!");
        Destroy(gameObject);
    }
}
