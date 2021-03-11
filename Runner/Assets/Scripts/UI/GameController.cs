using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum MenuButtonsState 
{
    None,
    Start,
    Info,
    About
}

public class GameController : MonoBehaviour
{
    [SerializeField] Button startButton;
    [SerializeField] Button infoButton;
    [SerializeField] Button aboutButton;
    [SerializeField] PlayerStartMover playerMover;

    Button[] menuButtons;

    private void Start()
    {
        startButton.onClick.AddListener(StartAction);
        SetStartParameters();
    }

    void SetStartParameters() 
    {
        playerMover.enabled = false;
    }

    void StartAction()
    {
        Debug.Log("I can move");

        startButton.interactable = false;
        infoButton.interactable = false;
        aboutButton.interactable = false;

        playerMover.enabled = true;
    }
}
