using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutWindowScript : MonoBehaviour
{
    [SerializeField]
    GameObject window1;
    [SerializeField]
    GameObject window2;
    [SerializeField]
    GameObject closeButton;

    // Start is called before the first frame update
    void Start()
    {
        closeButton.SetActive(false);
        window1.SetActive(true);
        window2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadWindow1()
    {
        window2.SetActive(false);
        window1.SetActive(true);
    }
    public void LoadWindow2()
    {
        window1.SetActive(false);
        window2.SetActive(true);
        closeButton.SetActive(true);
    }

    public void CloseTutorialWindow()
    {
        gameObject.SetActive(false);
        GameManagerScript.instance.gameState = GameManagerScript.GameState.PLAY;
    }
}
