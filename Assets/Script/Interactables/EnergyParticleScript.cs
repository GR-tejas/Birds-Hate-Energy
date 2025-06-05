using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnergyParticleScript : MonoBehaviour
{
    [SerializeField]
    private int storedEnergy = 1;

    [SerializeField]
    private Sprite[] sprites;

    public GameObject icon;

    private SpriteRenderer iconSpriteRenderer;

    void Start()
    {
        iconSpriteRenderer = icon.GetComponent<SpriteRenderer>();
        if(storedEnergy <= 3 && storedEnergy >= 1)
            iconSpriteRenderer.sprite = sprites[storedEnergy - 1];
        else if(storedEnergy <= 0)
            iconSpriteRenderer.sprite = sprites[0];
        else
            iconSpriteRenderer.sprite = sprites[2];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameManagerScript.instance.gameState != GameManagerScript.GameState.PLAY)
            return;

        if (collision.CompareTag("Ball"))
        {
            if(GameManagerScript.instance.ballEnergy < 10)
            {
                GameManagerScript.instance.IncreaseBallEnergy(storedEnergy);
                Destroy(gameObject);
            }
        }
    }
}
