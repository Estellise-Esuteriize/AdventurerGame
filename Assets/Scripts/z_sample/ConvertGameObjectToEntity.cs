using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class ConvertGameObjectToEntity : MonoBehaviour
{
    void Start()
    {
        GameObjectConversionUtility.ConvertGameObjectHierarchy(gameObject, new GameObjectConversionSettings(World.Active, GameObjectConversionUtility.ConversionFlags.AssignName));
    }

}
