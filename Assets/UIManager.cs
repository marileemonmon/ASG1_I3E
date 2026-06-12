using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public TMP_Text scoreText;

    public GameObject MenuPanel;
    public GameObject GameOverPanel;
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
    public void GameOver()
    {
        GameOverPanel.SetActive(!GameOverPanel.activeSelf);
    }
}
