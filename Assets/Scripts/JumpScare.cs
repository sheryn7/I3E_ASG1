/*
* Author: Sheryn Batrisyia
* Date: 13/06/2026
* Description: Handles the jump scare trigger, hides the panel, reveals the monster and respawns the player.
*/
using System.Collections;
using UnityEngine;

/// <summary>
/// Handles the jump scare event when the player enters the trigger zone.
/// </summary>
public class JumpScare : MonoBehaviour
{
    /// <summary>
    /// Reference to the panel holder GameObject that will be hidden when the jump scare is triggered.
    /// </summary>
    [SerializeField] GameObject panelHolder;

    /// <summary>
    /// Reference to the monster that appears after the panel is removed.
    /// </summary>
    [SerializeField] GameObject monster;

    /// <summary>
    /// Reference to the player object.
    /// </summary>
    [SerializeField] Transform player;

    /// <summary>
    /// Reference to the corridor respawn point.
    /// </summary>
    [SerializeField] Transform respawnPoint;

    /// <summary>
    /// Reference to the death message displayed to the player.
    /// </summary>
    [SerializeField] GameObject deathText;

    /// <summary>
    /// Audio source played when the jump scare is triggered.
    /// </summary>
    [SerializeField] AudioSource jumpScareSound;

    /// <summary>
    /// Prevents the jump scare from triggering multiple times.
    /// </summary>
    bool hasTriggered = false;

    /// <summary>
    /// Detects when an object enters the trigger zone and triggers the jump scare.
    /// </summary>
    /// <param name="other">The collider that entered the trigger.</param>
    void OnTriggerEnter(Collider other)
    {
         if (other.CompareTag("Player") && hasTriggered == false)
        {
            hasTriggered = true;

            panelHolder.SetActive(false);
            monster.SetActive(true);

            jumpScareSound.Play();

            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(999f);
            }

            StartCoroutine(RespawnPlayer());
        }
    }

    /// <summary>
    /// Waits for 5 seconds before respawning the player.
    /// </summary>
    IEnumerator RespawnPlayer()
    {
        yield return new WaitForSeconds(2f);

        deathText.SetActive(true);

        yield return new WaitForSeconds(3f);

        CharacterController controller = player.GetComponent<CharacterController>();

        controller.enabled = false;
        player.position = respawnPoint.position;
        player.eulerAngles = new Vector3(0, 180, 0);
        controller.enabled = true;

        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            playerHealth.ResetHealth();
        }

        monster.SetActive(false);
        deathText.SetActive(false);
    }
}
