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
    /// <summary>
    /// Audio source played when a collectible is collected.
    /// </summary>
    [SerializeField] AudioSource collectSound;

    /// <summary>
    /// Audio source played when all collectibles have been collected.
    /// </summary>
    [SerializeField] AudioSource successSound;

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

    /// <summary>
    /// Plays the collectible pickup sound.
    /// </summary>
    public void PlayCollectSound()
    {
        collectSound.Play();
    }

    /// <summary>
    /// Plays the success sound when all collectibles have been collected.
    /// </summary>
    public void PlaySuccessSound()
    {
        successSound.Play();
    }
}