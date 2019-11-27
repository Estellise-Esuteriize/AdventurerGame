using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;



[Serializable]
public struct GravityData : IComponentData
{
    public bool Falling;

    public float Gravity;
}

public class GravityComponent : ComponentDataProxy<GravityData>{ }

