/*
* Author: Sheryn Batrisyia
* Date: 13/06/2026
* Description: Allows the player to open a locker and reveal a hidden key.
*/

using UnityEngine;

/// <summary>
/// Handles locker interaction and key reveal.
/// </summary>
public class Locker : MonoBehaviour
{
    /// <summary>
    /// Stores whether the locker has been opened.
    /// </summary>
    bool lockerOpen = false;

    /// <summary>
    /// Rotation angle when the locker is opened.
    /// </summary>
    [SerializeField] float openAngle = 90f;

    /// <summary>
    /// Reference to the hidden key.
    /// </summary>
    [SerializeField] GameObject hiddenKey;

    /// <summary>
    /// Displays the locker interaction prompt and opens the locker.
    /// </summary>
    void OnMouseOver()
    {
        if (PlayerCasting.distanceFromTarget < 10)
        {
            UIController.actionText = "Open Locker";
            UIController.commandText = "Open";
            UIController.uiActive = true;

            if (Input.GetKeyDown(KeyCode.E) && lockerOpen == false)
            {
                transform.localRotation = Quaternion.Euler(0, openAngle, 0);

                lockerOpen = true;

                hiddenKey.SetActive(true);
            }
        }
    }

    /// <summary>
    /// Hides the interaction prompt when the player stops looking at the locker.
    /// </summary>
    void OnMouseExit()
    {
        UIController.actionText = "";
        UIController.commandText = "";
        UIController.uiActive = false;
    }
}
