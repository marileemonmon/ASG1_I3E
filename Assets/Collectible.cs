using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int score=1;
    public int Collect()
    {
        //Destroy the coin after the sound has played
        Destroy(gameObject);
        return score;

    }
}