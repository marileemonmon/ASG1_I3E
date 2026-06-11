using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int score=1;
    public AudioSource audioSource;
    public int Collect()
    {
        //Play the coin collect sound
        if (audioSource != null)
        {
            audioSource.Play();
        }
        //Hide the coin
        var renderer = GetComponent<MeshRenderer>();
        renderer.enabled = false;
        //Destroy the coin after the sound has played
        Destroy(gameObject, 1);
        return score;
    }
}