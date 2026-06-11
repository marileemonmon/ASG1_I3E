using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerScript : MonoBehaviour
{   
    int score=0;
    int keycards=0;
    [SerializeField]
    private float interactDistance = 3f;
    private GameObject currentgem;
    private GameObject currentkeycard;
    public AudioSource audioSource;

    GameObject currentCollider;
       void OnInteract (InputValue value)
    {
      
        if (currentgem!=null)
        {
            var collectible = currentgem.GetComponent<Collectible>();
                
                print($"Interacting with {currentgem.name}");
                score+=collectible.score;
                print($"Current score: {score}");
                collectible.Collect();
                //Play the coin collect sound
                if (audioSource != null)
                {
                    audioSource.Play();
                }

        
        }
        if (currentkeycard!=null)
        {
            var keycard = currentkeycard.GetComponent<Collectible>();
                
                print($"Interacting with {currentkeycard.name}");
                keycards++;
                print($"Current keycards: {keycards}");
                keycard.Collect();
                //Play the coin collect sound
                if (audioSource != null)
                {
                    audioSource.Play();
                }

        
        }

    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name=="FinishLine"&&score==27)
        {
            print($"Final score: {score} Congratulations! You win!");
        }
        else
        {
            print($"You have not collected all the points!");
        }
    }
    private void Update()
    {
        {
            RaycastHit hit;

            if(Physics.Raycast(
                transform.position,
                transform.forward,
                out hit,
                interactDistance))
            {
               if(hit.collider.CompareTag("Gem"))
               {
                   print($"Looking at {hit.collider.gameObject.name}");
                   currentgem=hit.collider.gameObject;
               }
                else
                {
                     currentgem=null;
                }
                if (hit.collider.CompareTag("KeyCard"))
                {
                    print($"Looking at {hit.collider.gameObject.name}");
                    currentkeycard=hit.collider.gameObject;
                }
                else
                {
                     currentkeycard=null;
                }
            }

        }
    }

}