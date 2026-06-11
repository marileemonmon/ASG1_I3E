using UnityEngine;

public class DoorScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public AudioSource audioSource;
    private bool isOpen = true;
    public void open()
    {
        
        var animatorComponent = GetComponent<Animator>();
        animatorComponent.SetBool("IsOpen", isOpen);
        isOpen = !isOpen;
        
    }
}