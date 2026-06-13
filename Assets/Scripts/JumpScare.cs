/*
* Author: Sheryn Batrisyia
* Date: 13/06/2026
* Description: Handles the jump scare trigger and hides the panel when the player enters the trigger area
*/
using UnityEngine;

/// <summary>
/// Handles the jump scare event when the player enters the trigger zone.
/// </summary>
public class JumpScare : MonoBehaviour
{
    /// <summary>
    /// Reference to the panel holder GameObject that will be hidden when the jump scare is triggered.
    /// </summary>
    public GameObject panelHolder;

    /// <summary>
    /// Detects when an object enters the trigger zone and disables the panel holder.
    /// </summary>
    void OnTriggerEnter(Collider other)
    {
        panelHolder.SetActive(false);    // when triggered, turn off panel holder
    }
}
