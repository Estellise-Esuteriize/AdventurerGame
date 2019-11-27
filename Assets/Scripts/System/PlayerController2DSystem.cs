using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

//[UpdateInGroup(typeof(Controller2DGroup))]
//[UpdateBefore(typeof(PlayerGravitySystem))]
public class PlayerController2DSystem : ComponentSystem
{

    private IDictionary<int, float> movementSpeed = new Dictionary<int, float>();
    
    private float3 velocity;

    private static int ids = 1;

    protected override void OnStartRunning()
    {
        base.OnCreate();

        Entities.ForEach<PlayerData>(InitializedPlayerData);
      
    }

    protected override void OnUpdate()
    {
        Entities.ForEach<PlayerData, Translation>(HandlePlayerMovement);
    }

    private void HandlePlayerMovement(ref PlayerData playerData, ref Translation translation)
    {
        var playerId = playerData.PlayerID;
        movementSpeed.TryGetValue(playerId, out var tempMovementSpeed);

        Debug.Log(tempMovementSpeed);

        velocity.x = Input.GetAxis("Horizontal") * tempMovementSpeed * Time.deltaTime;

        translation.Value += velocity;
    }

    private void InitializedPlayerData(ref PlayerData data)
    {
        var newId = ids++;

        data.PlayerID = newId;

        movementSpeed.Add(newId, data.MovementSpeed);

    }
   
}
