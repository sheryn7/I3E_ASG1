/*
* Author: Sheryn Batrisyia
* Date: 13/06/2026
* Description: Casts a ray forward from the player and stores the distance from the object being looked at
*/

using UnityEngine;

/// <summary>
/// Handles raycasting from the player to detect how far the player is from the object they are looking at.
/// </summary>
public class PlayerCasting : MonoBehaviour
{
    /// <summary>
    /// Stores the distance between the player and the object hit by the raycast.
    /// This can be accessed by other scripts.
    /// </summary>
    public static float distanceFromTarget;

    /// <summary>
    /// Shows the current distance to the target in the Unity Inspector.
    /// </summary>
    [SerializeField] float toTarget;

    /// <summary>
    /// Casts a ray forward every frame and updates the target distance when something is hit.
    /// </summary>
    void Update()
    {
        RaycastHit Hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Hit))
        {
            toTarget = Hit.distance;
            distanceFromTarget = toTarget;
        }
    }
}