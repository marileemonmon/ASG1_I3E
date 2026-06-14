/*
* Author:Marilyn
* Date:6/12/2026
* Description: Script to display the player's health
*/
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public void SetSlider(float amount)
    {
        healthSlider.value = amount;
    }
    public void SetMaxHealth(float amount)
    {
        healthSlider.maxValue = amount;
        SetSlider(amount);
    }
}
