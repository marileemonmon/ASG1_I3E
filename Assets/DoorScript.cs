using UnityEngine;

public class DoorScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    bool isOpen = false;
    public AudioSource audioSource;
    public int Interact()
    {
        print("Door interacted with");
        var animatorComponent = GetComponent<Animator>();
        animatorComponent.SetBool("isOpen", !isOpen);
        isOpen = !isOpen;
        if (isOpen && audioSource != null)
        {
            audioSource.Play();
        }
        return 0;
    }
}
