using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text scoreText;

    public GameObject MenuPanel;
    public void UpdateScore(int score)
    {
        scoreText.text = $"Score: {score}/26";
    }
    public void ToggleMenu()
    {
        MenuPanel.SetActive(!MenuPanel.activeSelf);
        Cursor.visible = MenuPanel.activeSelf;
        Cursor.lockState = MenuPanel.activeSelf ? 
                            CursorLockMode.None : 
                            CursorLockMode.Locked;
    }
}
