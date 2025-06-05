using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameManagerScript.instance.gameState != GameManagerScript.GameState.PLAY)
            return;

        if (collision.CompareTag("Ball"))
        {
            if(GameManagerScript.instance.ballEnergy != 0)
            {
                Debug.Log(1);
                GameManagerScript.instance.gameState = GameManagerScript.GameState.GAMEOVER;
            }
        }
    }
}
