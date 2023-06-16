using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

[Serializable]
public struct DialogueElements
{
    [TextAreaAttribute] public string dialogueText;
    public string answerText;
    public UnityEvent answerAction;
}

public class Dialogue : MonoBehaviour
{
    [SerializeField] private GameObject dialogueDisplay;
    [SerializeField] private TextMeshProUGUI textElement;
    [SerializeField] private Button answerButton;
    [SerializeField] private DialogueElements[] dialogueElements;

    private GameObject playerReference;
    private bool wasTriggered = false;


    public void OpenDialogue()
    {
        dialogueDisplay.SetActive(true);
        LoadDialogueElements(0);
    }

    public void CloseDialogue()
    {
        playerReference.GetComponent<PlayerInput>().enabled = true;
        Camera.main.GetComponent<PlayerInput>().enabled = true;
        dialogueDisplay.SetActive(false);
    }

    public void LoadDialogueElements(int index)
    {
        // Debug.Log(index);
        DialogueElements currentDialogueElements = dialogueElements[index];
        textElement.text = currentDialogueElements.dialogueText;
        if (currentDialogueElements.answerAction != null)
        {
            answerButton.gameObject.SetActive(true);
            answerButton.GetComponentInChildren<TextMeshProUGUI>().text = dialogueElements[index].answerText;
            answerButton.onClick.RemoveAllListeners();
            answerButton.onClick.AddListener(() => currentDialogueElements.answerAction.Invoke());
        }
        else
            answerButton.gameObject.SetActive(false);
    }

    void Start()
    {
        if (this.gameObject.name == "LevelData")
        {
            OpenDialogue();
            playerReference = GameObject.FindGameObjectWithTag("Player");
            playerReference.GetComponent<PlayerInput>().enabled = false;
            Camera.main.GetComponent<PlayerInput>().enabled = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (wasTriggered)
            return;
        if (other.gameObject.CompareTag("Player"))
        {
            wasTriggered = true;
            if (DataStorage.Instance.KeyFound == false)
            {
                OpenDialogue();
                playerReference = other.gameObject;
                playerReference.GetComponent<PlayerInput>().enabled = false;
                Camera.main.GetComponent<PlayerInput>().enabled = false;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            wasTriggered = false;
        }
    }
}