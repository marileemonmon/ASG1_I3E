/*
* Author:Marilyn
* Date:6/11/2026
* Description: Script to collect key cards
*/
using UnityEngine;

public class KeyCardCollect : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int Keycards=1;
    public int Collect()
    {
        //Destroy the keycard after collection
        Destroy(gameObject);
        return Keycards;

    }
}
