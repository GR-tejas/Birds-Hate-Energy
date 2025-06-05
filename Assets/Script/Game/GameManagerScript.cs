using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript instance;
    public GameState gameState;

    public int ballEnergy = 3;
    public int endEnergy = 0;

    public int requiredEnergy = 10;

    public enum GameState
    {
        PLAY,
        PAUSE,
        GAMEOVER,
        Win
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        ballEnergy = 3;
        endEnergy = 0;
        //gameState = GameState.PLAY;
    }

    void Update()
    {
        if(endEnergy >= requiredEnergy)
            gameState = GameState.Win;
    }

    public void IncreaseBallEnergy(int energy)
    {
        ballEnergy += energy;
    }

    public void TransferEnergy()
    {
        endEnergy += ballEnergy;
        ballEnergy = 0;
    }
}
