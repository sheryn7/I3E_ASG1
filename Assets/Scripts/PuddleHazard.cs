/*
* Author: Sheryn Batrisyia
* Date: 13/06/2026
* Description: Damages the player over time when they step on the puddle hazard.
*/

using UnityEngine;

/// <summary>
/// Handles damage over time when the player is inside the puddle hazard.
/// </summary>
public class PuddleHazard : MonoBehaviour
{
    /// <summary>
    /// Damage dealt per second.
    /// </summary>
    [SerializeField] float damagePerSecond = 10f;

    /// <summary>
    /// Reference to the warning panel displayed when the player enters the puddle.
    /// </summary>
    [SerializeField] GameObject warningPanel;

    /// <summary>
    /// Audio source played while the player is inside the puddle.
    /// </summary>
    [SerializeField] AudioSource puddleSound;

    /// <summary>
    /// Displays the warning panel when the player enters the puddle.
    /// </summary>
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            warningPanel.SetActive(true);
            puddleSound.Play();
        }
    }

    /// <summary>
    /// Damages the player while they stay inside the puddle trigger.
    /// </summary>
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damagePerSecond * Time.deltaTime);
            }
        }
    }

    /// <summary>
    /// Hides the warning panel when the player leaves the puddle.
    /// </summary>
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            warningPanel.SetActive(false);
            puddleSound.Stop();
        }
    }
}
