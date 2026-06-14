/*
* Author: Sheryn Batrisyia
* Date: 13/06/2026
* Description: Displays interaction prompts, opens and closes doors smoothly and locks the staff room door until all collectibles are collected
*/

using UnityEngine;

/// <summary>
/// Handles door prompts, smooth door movement, and locked door conditions.
/// </summary>
public class Door : MonoBehaviour
{
    /// <summary>
    /// Stores whether the door is currently open.
    /// </summary>
    bool doorOpen = false;

    /// <summary>
    /// Rotation angle when the door is open.
    /// </summary>
    [SerializeField] float openAngle = 90f;

    /// <summary>
    /// Controls how fast the door opens and closes.
    /// </summary>
    [SerializeField] float doorSpeed = 3f;

    /// <summary>
    /// Reference to the player.
    /// </summary>
    [SerializeField] Transform player;

    /// <summary>
    /// Sets whether this door is the staff room door.
    /// </summary>
    [SerializeField] bool isStaffRoomDoor;

    /// <summary>
    /// Sets whether this door is the escape door.
    /// </summary>
    [SerializeField] bool isEscapeDoor;

    /// <summary>
    /// Reference to the ending panel.
    /// </summary>
    [SerializeField] GameObject endingPanel;

    /// <summary>
    /// Stores the closed rotation of the door.
    /// </summary>
    Quaternion closedRotation;

    /// <summary>
    /// Stores the opened rotation of the door.
    /// </summary>
    Quaternion openedRotation;

    /// <summary>
    /// Sets the starting open and closed rotations.
    /// </summary>
    void Start()
    {
        closedRotation = transform.localRotation;
        openedRotation = Quaternion.Euler(transform.localEulerAngles.x, transform.localEulerAngles.y + openAngle, transform.localEulerAngles.z);
    }

    /// <summary>
    /// Smoothly opens or closes the door and closes it automatically when the player moves away.
    /// </summary>
    void Update()
    {
        if (doorOpen == true)
        {
            transform.localRotation = Quaternion.Slerp(transform.localRotation, openedRotation, doorSpeed * Time.deltaTime);

            float distance = Vector3.Distance(transform.position, player.position);

            if (distance > 3f)
            {
                doorOpen = false;
            }
        }
        else
        {
            transform.localRotation = Quaternion.Slerp(transform.localRotation, closedRotation, doorSpeed * Time.deltaTime);
        }
    }

    /// <summary>
    /// Displays the door interaction UI and allows the player to open unlocked doors.
    /// </summary>
    void OnMouseOver()
    {
        if (PlayerCasting.distanceFromTarget < 5)
        {
            if (isStaffRoomDoor == true && CollectibleManager.collectedItems < 4)
            {
                UIController.actionText = "Staff Room Locked";
                UIController.commandText = "Collect 4 Items First";
                UIController.uiActive = true;
                UIController.showE = false;
                return;
            }

            if (isEscapeDoor == true && MasterKey.hasMasterKey == false)
            {
                UIController.actionText = "Escape Door Locked";
                UIController.commandText = "Find the Master Key";
                UIController.showE = false;
                UIController.uiActive = true;
                return;
            }

            UIController.showE = true;
            UIController.actionText = "Door Open";
            UIController.commandText = "Open";
            UIController.uiActive = true;

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (isEscapeDoor)
                {
                    endingPanel.SetActive(true);

                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;

                    return;
                }

                doorOpen = !doorOpen;
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
    /// Hides the door prompt when the player stops looking at the door.
    /// </summary>
    void OnMouseExit()
    {
        UIController.actionText = "";
        UIController.commandText = "";
        UIController.uiActive = false;
    }
}
