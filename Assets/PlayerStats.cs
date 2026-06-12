using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    public int MaxHealth;
    public int CurrentHealth;
    public HealthBar healthBar;
    public UIManager MyUIManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CurrentHealth = MaxHealth;
        healthBar.SetMaxHealth(MaxHealth);
    }
    public void TakeDamage(float amount)
    {
        CurrentHealth -= (int)amount;
        print("Player took " + amount + " damage. Current health: " + CurrentHealth);
        healthBar.SetSlider(CurrentHealth);
        if (CurrentHealth == 0)
        {
            print("Player has died.");
            MyUIManager.GameOver();
        }
    }
}
