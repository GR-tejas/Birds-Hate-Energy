using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasScript : MonoBehaviour
{
    public TextMeshProUGUI ballEnergyText;
    public TextMeshProUGUI staffEnergyText;
    public TextMeshProUGUI requiredEnergyText;


    [SerializeField]
    GameObject tutorialWindow1;

    [SerializeField]
    GameObject winWindow;

    [SerializeField]
    GameObject loseWindow;

    void Start()
    {
        GameManagerScript.instance.gameState = GameManagerScript.GameState.PAUSE;
        tutorialWindow1.SetActive(true);
        winWindow.SetActive(false);
    }

    void Update()
    {
        SetEnergyText();
        SetEnergyTextColor();
        if (GameManagerScript.instance.gameState == GameManagerScript.GameState.Win)
        {
            winWindow.SetActive(true);
        }

        if (GameManagerScript.instance.gameState == GameManagerScript.GameState.GAMEOVER)
            loseWindow.SetActive(true);
    }

    private void SetEnergyText()
    {
        ballEnergyText.text = "Ball Energy = " + GameManagerScript.instance.ballEnergy;
        staffEnergyText.text = "Staff Energy = " + GameManagerScript.instance.endEnergy;
        requiredEnergyText.text = "Required Energy = " + GameManagerScript.instance.requiredEnergy;
    }

    private void SetEnergyTextColor()
    {
        ballEnergyText.color = GameManagerScript.instance.ballEnergy >= 10 ? Color.red : Color.white;
        staffEnergyText.color = GameManagerScript.instance.endEnergy >= GameManagerScript.instance.requiredEnergy ? Color.green : Color.white;
    }

    public void OnMenuButtonClicked()
    {
        SceneManager.LoadScene(0);
    }

    public void OnContinueButtonClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OnRestartButtonClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}