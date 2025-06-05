using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tut2trigger : MonoBehaviour
{
    public GameObject tutWindow2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManagerScript.instance.gameState = GameManagerScript.GameState.PAUSE;
        tutWindow2.SetActive(true);
        Destroy(gameObject);
    }
}
