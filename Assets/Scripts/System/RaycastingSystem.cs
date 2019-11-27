using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Jobs;
using Unity.Burst;
using Unity.Collections;
using Unity.Rendering;
using Unity.Transforms;

public class RaycastingSystem : JobComponentSystem
{

    protected override void OnStartRunning()
    {
        base.OnStartRunning();

        //Debug.Log("ON START RUNNING");

        //var entites = EntityManager.GetAllEntities();

        //Debug.Log(entites.Length);

        //var component = EntityManager.GetComponentData<RenderBounds>(entites[0]);

        //var query = GetEntityQuery(typeof(RenderBounds));

        //Debug.Log("QUERY " + query.CalculateEntityCount());

        var group = GetEntityQuery(typeof(RenderBounds));

        var components = group.ToComponentDataArray<RenderBounds>(Allocator.TempJob);

        foreach (var component in components)
        {
            Debug.Log("EXTENTS " + component.Value.Extents);
        }

        //Debug.Log(components[0].Value.Extents);

        components.Dispose();
    }

    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        return new RaycastingSystemJob().Schedule(this, inputDeps);
    }


    //private void CalculateRaySpacing([ReadOnly] ref RenderBounds box)
    //{
    //    var bounds = box.Value.Extents;

    //    Debug.Log(bounds.ToString());
        
    //}

    //private void UpdateRayCastOrigins()
    //{

    //}


    public struct RaycastingSystemJob : IJobForEach<RenderBounds>
    {
        public void Execute(ref RenderBounds raycastData)
        {
            Debug.Log("DATA" + raycastData.Value.Extents);
        }
    }


    public struct InitializeRaycastingSystem : IJob
    {



        public void Execute()
        {

        }
    }

}
