using UnityEngine;

public class JumpScare : MonoBehaviour
{
    public GameObject panelHolder;

    void OnTriggerEnter(Collider other)
    {
        panelHolder.SetActive(false);    // when triggered, turn off panel holder
    }
}
