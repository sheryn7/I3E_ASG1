/*
* Author: Sheryn Batrisyia
* Date: 13/06/2026
* Description: Displays interaction prompts when the player looks at a door
*/
using UnityEngine;

/// <summary>
/// Handles door interaction prompts when the player hovers over the door.
/// </summary>
public class Door : MonoBehaviour
{
    /// <summary>
    /// Stores the current state of the door.
    /// </summary>
    bool doorOpen = false;

    /// <summary>
    /// Rotation angle when the door is open.
    /// </summary>
    [SerializeField] float openAngle = 90f;

    /// <summary>
    /// Reference to the player.
    /// </summary>
    [SerializeField] Transform player;

    /// <summary>
    /// Reference to the door animator.
    /// </summary>
    [SerializeField] Animator doorAnimator;

    /// <summary>
    /// Displays the door interaction UI when the player looks at the door.
    /// </summary>
    void OnMouseOver()
    {
        if(PlayerCasting.distanceFromTarget < 10)
        {
            UIController.actionText = "Open Door";
            UIController.commandText = "Open";
            UIController.uiActive = true;

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (doorOpen == false)
                {
                    transform.localRotation = Quaternion.Euler(0, openAngle, 0);
                    doorOpen = true;
                }
                else
                {
                    transform.localRotation = Quaternion.Euler(0, 0, 0);
                    doorOpen = false;
                }
            }
        }
        else
        {
            UIController.actionText = "";
            UIController.commandText = "";
            UIController.uiActive = false;
        }
    }

    /// <summary>
    /// Hides the door interaction UI when the player stops looking at the door.
    /// </summary>
    void OnMouseExit()
    {
        UIController.actionText = "";
        UIController.commandText = "";
        UIController.uiActive = false;
    }

    /// <summary>
    /// Automatically closes the door when the player moves away.
    /// </summary>
    void Update()
    {
        if (doorOpen == true)
        {
            float distance = Vector3.Distance(transform.position, player.position);

            if (distance > 3f)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
                doorOpen = false;
            }
        }
    }
}
