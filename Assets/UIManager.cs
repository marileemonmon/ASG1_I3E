/*
* Author:Marilyn
* Date:6/11/2026
* Description: Script to manage all the UI of my player interactions
*/
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text scoreTextGameOver;
    public TMP_Text scoreTextWin;
    public TMP_Text LockedDoorText;
    public TMP_Text FinishText;
    public TMP_Text CongratsText;
    [SerializeField]
    public GameObject MenuPanel;
    [SerializeField]
    public GameObject WinPanel;
    [SerializeField]
    public GameObject GameOverPanel;
    [SerializeField]
    public GameObject LockedDoorPanel;
    [SerializeField]
    public GameObject FinishPanel;
    [SerializeField]
    public GameObject CongratsPanel;

    void Start()
    {
        // Off all the panels at the start of the game
        MenuPanel.SetActive(false);
        GameOverPanel.SetActive(false);
        LockedDoorPanel.SetActive(false);
        FinishPanel.SetActive(false);
        CongratsPanel.SetActive(false);
    }
    public void UpdateScore(int score)
    {
        scoreText.text = $"Score: {score}/26";
    }
    // Toggle the menu panel and lock/unlock the cursor when the menu is opened/closed
    public void ToggleMenu()
    {
        MenuPanel.SetActive(!MenuPanel.activeSelf);
        Cursor.visible = MenuPanel.activeSelf;
        Cursor.lockState = MenuPanel.activeSelf ? 
                            CursorLockMode.None : 
                            CursorLockMode.Locked;
    }
    // Restart the current scene to restart the game
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    //Toggle the game over panel and lock/unlock the cursor when the game over panel is opened/closed
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
    //Toggle the LockedDoorpanel
    public void ShowLockedDoorPanel()
    {
        LockedDoorPanel.SetActive(true);
        Invoke("HideLockedDoorPanel", 2f); // Hide after 2 seconds
    }
    //Hide the locked door panel
    private void HideLockedDoorPanel()
    {
        LockedDoorPanel.SetActive(false);
    }
    public void UpdateLockedDoorText(int requiredKeycards, int currentKeycards)
    {
        
        LockedDoorText.text = $"You need {requiredKeycards} keycards to open this door. You currently have {currentKeycards} keycards.";
    }
    //Toggle the finish panel so the player game ends
    public void ShowFinishPanel()
    {
        FinishPanel.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void UpdateFinishText(int score)
    {
        FinishText.text = $"Congratulations! You finished the game!" + 
                                $"\nFinal Score: {score}/26"+
                                $"\n Thank you for playing!";
    }
    //Toggle the congrats panel when the player collects all the gems.
    public void ShowCongratsPanel()
    {
        CongratsPanel.SetActive(true);
        Invoke("HideCongratsPanel", 2f); // Hide after 2 seconds
    }
    //Hides the Congrats panel after 2 seconds
    private void HideCongratsPanel()
    {
        CongratsPanel.SetActive(false);
    }
    public void UpdateCongratsText(int score)
    {
        CongratsText.text = $"Congratulations! You collected all the GEMS!" + 
                                $"\nFinal Score: {score}/26";
    }
}
