using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerScript : MonoBehaviour
{   
    int score=0;
    public int keycards=0;
    [SerializeField]
    private GameObject playerCamera;
    [SerializeField]
    private float interactDistance = 3f;
    private GameObject currentgem;
    private GameObject currentkeycard;
    private GameObject currentdoor;
    public AudioSource audioSource;
    public UIManager MyUIManager;


    GameObject currentCollider;
           void OnInteract (InputValue value)
    {

        RaycastHit hit;

        if(Physics.Raycast(playerCamera.transform.position,
         playerCamera.transform.forward, out hit, interactDistance))
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
                MyUIManager.UpdateScore(score);
                MyUIManager.UpdateScoreText(score);
                MyUIManager.UpdateGameOverScoreText(score);

        
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
            if( keycards>=door.DoorID)
            {
                door.open();
            }
            else
            {
                print($"You need {door.DoorID} keycards to open this door. You currently have {keycards} keycards.");
            }
      
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
                if(other.gameObject.CompareTag("FinishLine")&&score==5)
                {
                    print($"Final score: {score} Congratulations! You win!");
                    MyUIManager.Win();
                }
                else
                {
                    print($"You have not collected all the gems!");
                }
            }
            else
            {
                print("Nothing to interact with.");
            }
        }
    }
    void OnMenu(InputValue value)
    {
        MyUIManager.ToggleMenu();
    }
    private void Update()
    {
    }
    void OnGameOver(InputValue value)
    {
        MyUIManager.GameOver();
    }


}