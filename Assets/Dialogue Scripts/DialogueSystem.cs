using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//CREDITS: https://www.youtube.com/watch?v=jTPOCglHejE
public class DialogueSystem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI NPCNameText;
    [SerializeField] private TextMeshProUGUI NPCDialogueText;
    [SerializeField] private float typeSpeed = 10f;

    private Queue<string> paragraphs = new Queue<string>();

    private bool _conversationEnded;
    private bool _isTyping;

    private string p;

    private Coroutine typeDialogueCoroutine;

    private const string HTML_ALPHA = "<color=#00000000>";
    private const float MAX_TYPE_TIME = 0.1f;

    public void DisplayNextParagraph(DialogueText dialogueText)
    {
        if (paragraphs.Count == 0)
        {
            if (!_conversationEnded)
            {
                StartConversation(dialogueText);
            }

            else
            {
                EndConversation();
                return;
            }
        }
        if (!_isTyping)
        {
            p = paragraphs.Dequeue();

            typeDialogueCoroutine = StartCoroutine(TypeDialogueText(p));
        }

        else if (_conversationEnded && !_isTyping)
        { FinishParagraphEarly(); }



        //NPCDialogueText.text = p;

        if (paragraphs.Count == 0)
        {
            _conversationEnded = true;
        }
    }

    private void StartConversation(DialogueText dialogueText)
    {
        if (!gameObject.activeSelf)
        {
            gameObject.SetActive(true);
        }

        NPCNameText.text = dialogueText.speakerName;

        for (int i = 0; i < dialogueText.paragraphs.Length; i++)
        {
            paragraphs.Enqueue(dialogueText.paragraphs[i]);
        }
    }

    private void EndConversation()
    {
        paragraphs.Clear();

        _conversationEnded = false;

        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
    }

    private IEnumerator TypeDialogueText(string p)
    {
        _isTyping = true;

        NPCDialogueText.text = "";
        string originalText = p;
        string displayedText;
        int alphaIndex = 0;

        foreach (char c in p.ToCharArray())
        {
            alphaIndex++;
            NPCDialogueText.text = originalText;

            displayedText = NPCDialogueText.text.Insert(alphaIndex, HTML_ALPHA);
            NPCDialogueText.text = displayedText;

            yield return new WaitForSeconds(MAX_TYPE_TIME / typeSpeed);
        }

        _isTyping = false;
    }

    private void FinishParagraphEarly()
    {
        StopCoroutine(typeDialogueCoroutine);

        NPCDialogueText.text = p;

        _isTyping = false;
    }
}
