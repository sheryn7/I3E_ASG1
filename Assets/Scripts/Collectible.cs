/*
* Author: Sheryn Batrisyia
* Date: 13/06/2026
* Description: Displays collectible interaction prompts and allows the player to collect items.
*/

using UnityEngine;

/// <summary>
/// Handles collectible item interactions and collection.
/// </summary>
public class Collectible : MonoBehaviour
{
    /// <summary>
    /// Name of the collectible item displayed in the interaction prompt.
    /// </summary>
    [SerializeField] string itemName;

    /// <summary>
    /// Displays the collectible interaction UI when the player looks at the item.
    /// </summary>
    void OnMouseOver()
    {
        if (PlayerCasting.distanceFromTarget < 5)
        {
            UIController.actionText = itemName;
            UIController.commandText = "Collect";
            UIController.uiActive = true;

            if (Input.GetKeyDown(KeyCode.E))
            {
                UIController.actionText = "";
                UIController.commandText = "";
                UIController.uiActive = false;

                CollectibleManager.collectedItems++;

                if (CollectibleManager.collectedItems == 4)
                {
                    FindFirstObjectByType<CollectibleManager>().PlaySuccessSound();
                }

                FindFirstObjectByType<CollectibleManager>().PlayCollectSound();

                Destroy(gameObject);
            }
        }
    }

    /// <summary>
    /// Hides the collectible interaction UI when the player stops looking at the item.
    /// </summary>
    void OnMouseExit()
    {
        UIController.actionText = "";
        UIController.commandText = "";
        UIController.uiActive = false;
    }
}
