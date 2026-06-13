/*
* Author: Sheryn Batrisyia
* Date: 13/06/2026
* Description: Tracks and displays the number of collectibles collected by the player.
*/

using UnityEngine;
using TMPro;

/// <summary>
/// Tracks and displays collectible progress.
/// </summary>
public class CollectibleManager : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Collectible Manager Running");
    }
    /// <summary>
    /// Stores the number of collectibles collected by the player.
    /// </summary>
    public static int collectedItems = 0;

    /// <summary>
    /// Reference to the collectible counter text.
    /// </summary>
    [SerializeField] TMP_Text collectibleText;

    /// <summary>
    /// Updates the collectible counter UI every frame.
    /// </summary>
    void Update()
    {
        if (MasterKey.hasMasterKey)
        {
            collectibleText.text = "Escape Door Unlocked!";
        }
        else if (collectedItems >= 4)
        {
            collectibleText.text = "Find the Master Key";
        }
        else
        {
            collectibleText.text = "Items Collected: " + collectedItems + "/4";
        }
    }
}