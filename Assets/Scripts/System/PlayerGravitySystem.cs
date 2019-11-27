using System;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;
using UnityEngine;

public class PlayerGravitySystem : ComponentSystem
{
    protected override void OnStartRunning()
    {
        base.OnStartRunning();

        Debug.Log("PLAYER GRAVITY ON START RUNNING");
    }

    protected override void OnUpdate()
    {
        Entities.ForEach<GravityData, Translation>(UpdateGravity);
    }

    private void UpdateGravity(ref GravityData data, ref Translation translation)
    {

        Debug.Log("PLAYER GRAVITY UPDATE");

        if (data.Falling)
        {
            var velocity = translation.Value;

            velocity.y -= data.Gravity * Time.deltaTime;

            translation.Value = velocity;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            data.Falling = false;
        }

    }

    /** /
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        var gravityJob = new PlayerGravityJob { };

        var handle = gravityJob.Schedule(this, inputDeps);

        return handle;
    }
   

    [BurstCompile]
    private struct PlayerGravityJob : IJobForEach<GravityData, Translation>
    {
        public void Execute(ref GravityData gravity, ref Translation position)
        {
            var velocity = position.Value;

            velocity.y -= gravity.Gravity * Time.fixedDeltaTime;

            position.Value = velocity;
        }
    }

    /**/
}
