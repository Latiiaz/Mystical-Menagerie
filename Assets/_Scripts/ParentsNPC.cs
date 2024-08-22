using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentsNPC : NPC, ITalkable
{
    [SerializeField] private DialogueText dialogueText;
    [SerializeField] private DialogueSystem dialogueSystem;

    public override void Interact()
    {
        Talk(dialogueText);
    }

    public void Talk(DialogueText dialogueText)
    {
        dialogueSystem.DisplayNextParagraph(dialogueText);
    }
}