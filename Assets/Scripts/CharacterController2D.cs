using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(CapsuleCollider2D))]
public class CharacterController2D : MonoBehaviour
{

    [SerializeField] private LayerMask maskColliders;

    [Range (4, 10)]
    [SerializeField] private int verticalRayCounts = 4;
    [Range(4, 10)]
    [SerializeField] private int horizontalRayCounts = 4;

    private float verticalRaySpacing;
    private float horizontalRaySpacing;

    private CapsuleCollider2D capsuleCollider;

    private RaycastOrigins rayOrigins;

    private const float skinWidth = 0.015f;

    private void Awake()
    {
        capsuleCollider = GetComponent<CapsuleCollider2D>();

        CalculateRaySpacing();
    }


    public void Move(Vector2 velocity)
    {
        HorizontalCollisions(ref velocity);
        VerticalCollisions(ref velocity);
        
        transform.Translate(velocity);
    }

    public void HorizontalCollisions(ref Vector2 velocity)
    {
        var direction = (int)Mathf.Sign(velocity.x);
        var range = Mathf.Abs(direction) + skinWidth;

        var rayDirection = direction == 1 ? rayOrigins.bottomRight : rayOrigins.bottomLeft;

        for (var i = 0; i < horizontalRayCounts; i++)
        {
            var origin = (rayDirection + Vector2.up) * (horizontalRaySpacing * i);
            var dir = Vector2.right * direction;

            var raycastHit = Physics2D.Raycast(origin, dir, range, maskColliders);

            if (raycastHit)
            {
                velocity.x = (raycastHit.distance - skinWidth) * direction;
                range = raycastHit.distance;
            }
            
        }

    }

    public void VerticalCollisions(ref Vector2 velocity)
    {
        var direction = (int)Mathf.Sign(velocity.y);
        var range = Mathf.Abs(direction) + skinWidth;

        var rayDirection = direction == 1 ? rayOrigins.topLeft : rayOrigins.bottomLeft;

        for (var i = 0; i < verticalRayCounts; i++)
        {
            var origin = (rayDirection + Vector2.right) * (verticalRaySpacing * i);
            var dir = Vector2.up * direction;

            var raycastHit = Physics2D.Raycast(origin, dir,range, maskColliders);

            if (raycastHit)
            {
                velocity.y = (raycastHit.distance - skinWidth) * direction;
                range = raycastHit.distance;
            }
            
        }
    }


    private void SetRayOrigins()
    {
        var bounds = capsuleCollider.bounds;
        bounds.Expand(skinWidth * -2f);

        rayOrigins.bottomLeft = new Vector2(bounds.min.x, bounds.min.y);
        rayOrigins.bottomRight = new Vector2(bounds.max.x, bounds.min.y);
        rayOrigins.topLeft = new Vector2(bounds.min.x, bounds.max.y);
        rayOrigins.topRight = new Vector2(bounds.max.x, bounds.max.y);

    }

    private void CalculateRaySpacing()
    {
        var bounds = capsuleCollider.bounds;
        bounds.Expand(skinWidth * -2f);

        verticalRaySpacing = bounds.size.y / (verticalRayCounts - 1);
        horizontalRaySpacing = bounds.size.x / (horizontalRayCounts - 1);
    }




}

public struct RaycastOrigins
{
    public Vector2 topLeft;
    public Vector2 topRight;
    public Vector2 bottomLeft;
    public Vector2 bottomRight;
}
