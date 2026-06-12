using UnityEngine;

public class DoorScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public AudioSource audioSource;
    [SerializeField]
    public int DoorID;
    private bool isOpen = true;

    public void open()
    {

        var animatorComponent = GetComponent<Animator>();
        animatorComponent.SetBool("IsOpen", isOpen);
        isOpen = !isOpen;
        if (audioSource != null)
        {
            audioSource.Play();
        }
        
    }
}