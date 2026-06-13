using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text scoreTextGameOver;
    public TMP_Text scoreTextWin;
    public TMP_Text LockedDoorText;
    [SerializeField]
    public GameObject MenuPanel;
    [SerializeField]
    public GameObject WinPanel;
    [SerializeField]
    public GameObject GameOverPanel;
    [SerializeField]
    public GameObject LockedDoorPanel;
    void Start()
    {
        MenuPanel.SetActive(false);
        WinPanel.SetActive(false);
        GameOverPanel.SetActive(false);
        LockedDoorPanel.SetActive(false);
    }
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
        Cursor.visible = WinPanel.activeSelf;
        Cursor.lockState = WinPanel.activeSelf ? 
                            CursorLockMode.None : 
                            CursorLockMode.Locked;
    }
    public void UpdateScoreText(int score)
    {
        scoreTextWin.text = $"Congratulations! You Win!" + 
                                $"\nFinal Score: {score}/26";
    }
    public void GameOver()
    {
        GameOverPanel.SetActive(!GameOverPanel.activeSelf);
        Cursor.visible = GameOverPanel.activeSelf;
        Cursor.lockState = GameOverPanel.activeSelf ? 
                            CursorLockMode.None : 
                            CursorLockMode.Locked;
    }
    public void UpdateGameOverScoreText(int score)
    {
        scoreTextGameOver.text = $"Game Over!" + 
                                $"\nFinal Score: {score}/26";
    }
    public void ShowLockedDoorPanel()
    {
        LockedDoorPanel.SetActive(true);
        Invoke("HideLockedDoorPanel", 2f); // Hide after 2 seconds
    }
    private void HideLockedDoorPanel()
    {
        LockedDoorPanel.SetActive(false);
    }
    public void UpdateLockedDoorText(int requiredKeycards, int currentKeycards)
    {
        
        LockedDoorText.text = $"You need {requiredKeycards} keycards to open this door. You currently have {currentKeycards} keycards.";
    }
}
