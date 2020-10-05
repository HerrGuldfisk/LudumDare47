using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampController : MonoBehaviour
{
    public ParticleSystem lampLeft;
    public ParticleSystem lampRight;

    private void Awake()
    {
        TurnOffLamps();
    }

    public void TurnOffLamps()
    {
        lampLeft.Stop();
        lampRight.Stop();
    }

    public void TurnOnLamps()
    {
        lampLeft.Play();
        lampRight.Play();
    }
}
