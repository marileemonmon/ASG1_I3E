/*
* Author:Marilyn
* Date:6/10/2026
* Description: Script to collect the gems and add to the score
*/
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