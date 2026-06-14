/*
* Author: Sheryn Batrisyia
* Date: 13/06/2026
* Description: Allows the player to collect the Master Key and unlock the escape door.
*/

using UnityEngine;

/// <summary>
/// Handles Master Key collection and unlocks the escape door.
/// </summary>
public class MasterKey : MonoBehaviour
{

    /// <summary>
    /// Audio source played when the Master Key is collected.
    /// </summary>
    [SerializeField] AudioSource keyPickupSound;

    /// <summary>
    /// Stores whether the player has collected the Master Key.
    /// </summary>
    public static bool hasMasterKey = false;

    /// <summary>
    /// Displays the Master Key interaction UI and allows the player to collect it.
    /// </summary>
    void OnMouseOver()
    {
        if (PlayerCasting.distanceFromTarget < 5)
        {
            UIController.actionText = "Master Key";
            UIController.commandText = "Collect";
            UIController.showE = true;
            UIController.uiActive = true;

            if (Input.GetKeyDown(KeyCode.E))
            {
                hasMasterKey = true;

                keyPickupSound.Play();

                UIController.actionText = "";
                UIController.commandText = "";
                UIController.uiActive = false;

                Destroy(gameObject);
            }
        }
    }

    /// <summary>
    /// Hides the interaction UI when the player stops looking at the Master Key.
    /// </summary>
    void OnMouseExit()
    {
        UIController.actionText = "";
        UIController.commandText = "";
        UIController.uiActive = false;
    }
}