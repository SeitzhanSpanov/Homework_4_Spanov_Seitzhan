using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEvent : EventArgs
{
    public float Health { get; set; }

    public void HealthChangeEvent(float health)
    {
        Health = health;
    }
}

