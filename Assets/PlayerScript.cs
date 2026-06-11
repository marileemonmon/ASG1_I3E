using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerScript : MonoBehaviour
{   
    int score=0;
    bool isMenuShowing = false;

    GameObject currentCollider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name.StartsWith("gem"))
        {
            currentCollider=collision.gameObject;
            print($"Collided with {currentCollider.name}");
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.name.StartsWith("gem"))
        {
            print($"Stopped colliding with {currentCollider.name}.");
            currentCollider=null;
        }
    }
    void OnInteract (InputValue value)
    {
        print($"Interacting with {currentCollider.name}");
        if(currentCollider!=null)
        {
            var collectible = currentCollider.GetComponent<Collectible>();
            if(collectible!=null)
            {
                print($"Interacting with {currentCollider.name}");
                score+=collectible.score;
                print($"Current score: {score}");
                collectible.Collect();
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

}