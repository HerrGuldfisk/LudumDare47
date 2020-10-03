using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShipController : MonoBehaviour
{
    private moveForward speedScript;
    [SerializeField] float accAmount = 1;

    public InputAction gas;

    private void OnEnable()
    {
        gas.Enable();
    }
    private void OnDisable()
    {
        gas.Disable();
    }

    private void Awake()
    {
        speedScript = transform.GetComponent<moveForward>();
    }

    private void Update()
    {
        speedScript.ChangeSpeed(gas.ReadValue<float>() * accAmount * Time.deltaTime);
    }

}
