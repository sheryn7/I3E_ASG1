/* 
* Author: Sheryn Batrisyia
* Date: 13/06/2026
* Description: Controls the interaction UI by displaying action text, command text and interaction prompts when the player looks at an interactable object
*/
using UnityEngine;

/// <summary>
/// Manages the interaction user interface displayed to the player.
/// </summary>
public class UIController : MonoBehaviour
{
    /// <summary>
    /// Stores the action description shown to the player.
    /// </summary>
    public static string actionText;

    /// <summary>
    /// Stores the command text shown to the player.
    /// </summary>
    public static string commandText;

    /// <summary>
    /// Determines whether the interaction UI should be displayed.
    /// </summary>
    public static bool uiActive;

    /// <summary>
    /// Reference to the action text UI element.
    /// </summary>
    [SerializeField] GameObject actionBox;

    /// <summary>
    /// Reference to the command text UI element.
    /// </summary>
    [SerializeField] GameObject commandBox;

    /// <summary>
    /// Reference to the interaction crosshair UI element.
    /// </summary>
    [SerializeField] GameObject interactCross;
    
    /// <summary>
    /// Updates the interaction UI based on whether the UI is active.
    /// </summary>
    void Update()
    {
        if (uiActive == true)
        {
            actionBox.SetActive(true);
            commandBox.SetActive(true);
            interactCross.SetActive(true);
            actionBox.GetComponent<TMPro.TMP_Text>().text = actionText;

            // Display interaction key and command text
            commandBox.GetComponent<TMPro.TMP_Text>().text = "[E] " + commandText;  //Prompt E key + the command text
        }
        else    // "If UI is inactive, do this"
        {
            actionBox.SetActive(false);
            commandBox.SetActive(false);
            interactCross.SetActive(false);
        }
    }
}
