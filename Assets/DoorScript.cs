/*
* Author:Marilyn
* Date:6/11/2026
* Description: Script to animate the door opening and closing when the player interacts with it
*/
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
/*Audio source for my door interaction*/
    public AudioSource audioSource;
    [SerializeField]
    public int DoorID;
    private bool isOpen = true;

    public void open()
    {
        //activate the animator for the door
        var animatorComponent = GetComponent<Animator>();
        animatorComponent.SetBool("IsOpen", isOpen);
        isOpen = !isOpen;
        if (audioSource != null)//play the door audio
        {
            audioSource.Play();
        }
        
    }
}