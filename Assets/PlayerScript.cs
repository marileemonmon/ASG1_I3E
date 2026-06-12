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
    private GameObject currentdoor;
    public AudioSource audioSource;

    GameObject currentCollider;
       void OnInteract (InputValue value)
    {

        RaycastHit hit;

        if(Physics.Raycast(
            transform.position,
            transform.forward,
            out hit,
            interactDistance))
        {
            Debug.Log(hit.collider.tag);
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
            if (hit.collider.CompareTag("Door"))
            {
                print($"Looking at {hit.collider.gameObject.name}");
                currentdoor=hit.collider.gameObject;
            }
            else
            {
                    currentdoor=null;
            }
        }
      
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
        else if (currentkeycard!=null)
        {
            var keycard = currentkeycard.GetComponent<KeyCardCollect>();
                
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
        else if (currentdoor!=null)
        {
            DoorScript door = currentdoor.GetComponentInParent<DoorScript>();
            print(door);
            print($"Interacting with {currentdoor.name}");
            door.open();
      
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Water"))
        {
            var water = other.gameObject.GetComponent<WaterScript>();
            var playerStats = GetComponent<PlayerStats>();
            playerStats.TakeDamage(water.damage);
        }
        else
        {
            if(other.gameObject.CompareTag("Blade"))
            {
                print("Player hit by blade!");
                var blade = other.gameObject.GetComponent<BladeScript>();
                var playerStats = GetComponent<PlayerStats>();
                playerStats.TakeDamage(blade.damage);
            }
            else
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
        }

    }
    private void Update()
    {
    }

}