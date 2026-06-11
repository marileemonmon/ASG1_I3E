using UnityEngine;

public class KeyCardCollect : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int Keycards=1;
    public int Collect()
    {
        //Destroy the coin after the sound has played
        Destroy(gameObject);
        return Keycards;

    }
}
