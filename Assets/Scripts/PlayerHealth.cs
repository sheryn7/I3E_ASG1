/*
* Author: Sheryn Batrisyia
* Date: 13/06/2026
* Description: Manages the player's health and displays the health value on screen.
*/

using UnityEngine;
using TMPro;

/// <summary>
/// Handles player health and health UI.
/// </summary>
public class PlayerHealth : MonoBehaviour
{
    /// <summary>
    /// Stores the player's current health.
    /// </summary>
    [SerializeField] float health = 100f;

    /// <summary>
    /// Reference to the health text UI.
    /// </summary>
    [SerializeField] TMP_Text healthText;

    /// <summary>
    /// Updates the health display.
    /// </summary>
    void Update()
    {
        healthText.text = "Health: " + Mathf.RoundToInt(health);
    }

    /// <summary>
    /// Reduces the player's health.
    /// </summary>
    /// <param name="damage">Amount of damage taken.</param>
    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            health = 0;
            Debug.Log("Player died");
        }
    }

    /// <summary>
    /// Restores the player's health back to full health.
    /// </summary>
    public void ResetHealth()
    {
        health = 100f;
    }
}
