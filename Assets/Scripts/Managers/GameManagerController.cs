using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;
using Unity.Rendering;
using Unity.Transforms;
using UnityEngine;

public class GameManagerController : MonoBehaviour
{

    public GameObject playerPrefab;

    private EntityManager entityManager;

    private List<Entity> entities;

    private void Start()
    {
        entityManager = World.Active.EntityManager;

       SetUpPlayer();
    }

    private void SetUpPlayer()
    {
        GameObjectConversionUtility.ConvertGameObjectHierarchy(playerPrefab, ConversionSettings());
    }

    private GameObjectConversionSettings ConversionSettings()
    {
        var activeWorld = entityManager.World;
        var convertionFlag = GameObjectConversionUtility.ConversionFlags.AssignName;

        return new GameObjectConversionSettings(activeWorld, convertionFlag);
    }
}
