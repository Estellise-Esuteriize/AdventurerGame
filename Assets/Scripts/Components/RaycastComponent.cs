using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using System;

[Serializable]
public struct RaycastData : IComponentData
{
    public float SkinWidth;

    public int VerticalRayCounts;
    public int HorizontalRayCounts;

    public float VerticalRaySpacing;
    public float HorizontalRaySpacing;

    //public RaycastOrigins RayOrigins;
}

[Serializable]
public struct RaycastOriginsData
{
    public float BottomLeft;
    public float BottomRight;

    public float TopLeft;
    public float TopRight;
}

public class RaycastComponent : ComponentDataProxy<RaycastData>{}
