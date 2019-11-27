using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using System;

[Serializable]
public struct PlayerData : IComponentData
{
    public int PlayerID;

    public float MovementSpeed;
    public float3 Velocity;
}


public class PlayerComponent : ComponentDataProxy<PlayerData> {}