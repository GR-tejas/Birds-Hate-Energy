using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyStaffScript : MonoBehaviour
{
    public StaffState staffState;
    [SerializeField]
    private GameObject image;
    private Sprite imageSprite;
    [SerializeField]
    private Sprite[] staffSprites;

    public enum StaffState
    {
        ON,
        OFF
    }

    // Start is called before the first frame update
    void Start()
    {
        imageSprite = image.GetComponent<SpriteRenderer>().sprite;
        staffState = StaffState.OFF;
    }

    // Update is called once per frame
    void Update()
    {
        SetStaffImage();
        if (GameManagerScript.instance.endEnergy == GameManagerScript.instance.requiredEnergy)
            staffState = StaffState.ON;
    }

    private void SetStaffImage()
    {
        if(staffState == StaffState.OFF)
            imageSprite = staffSprites[0];
        else imageSprite = staffSprites[1];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameManagerScript.instance.gameState != GameManagerScript.GameState.PLAY)
            return;

        if(collision.CompareTag("Ball"))
        {
            GameManagerScript.instance.TransferEnergy();
        }
    }
}
