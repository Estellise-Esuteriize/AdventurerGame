using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using System;
using Unity.Mathematics;

[Serializable]
public struct VelocityData : IComponentData
{
    public float3 Velocity;
}

public class VelocityComponent : ComponentDataProxy<VelocityData> { }
