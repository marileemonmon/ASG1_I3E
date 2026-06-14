/*
* Author:Marilyn
* Date:6/10/2026
* Description: Script to rotate the blade around its y-axis
*/
using UnityEngine;

public class BladeRotationScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,5,0);
    }
}
