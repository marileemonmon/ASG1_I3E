using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text scoreTextGameOver;

    public GameObject MenuPanel;
    public GameObject WinPanel;
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
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Win()
    {
        WinPanel.SetActive(!WinPanel.activeSelf);
    }
    public void UpdateText(int score)
    {
        scoreTextGameOver.text = $"Final Score: {score}/26";
    }
}
