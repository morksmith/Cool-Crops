using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class RevealText : MonoBehaviour
{
    private TextMeshProUGUI dialogueText;
    private Menu dialogueCanvas;
    public List<string> Sentences;
    public bool Complete = false;
    public float RevealSpeed = 5;
    private float revealTimer;
    private int currentChar;
    private int sentenceInt = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogueText == null)
        {
            return;
        }

        if (!Complete)
        {
            if(dialogueText.maxVisibleCharacters < dialogueText.text.Length)
            {
                revealTimer += Time.deltaTime * RevealSpeed;
                if (revealTimer > 1)
                {
                    dialogueText.maxVisibleCharacters += 1;
                    revealTimer = 0;
                    Debug.Log(dialogueText.text[currentChar]);
                    if (currentChar < dialogueText.text.Length - 1)
                    {
                        currentChar++;
                    }
                }
            }
            else
            {
                Complete = true;
            }

        }
        else if (Input.GetButtonDown("Fire1"))
        {
            NextSentence();
        }
    }

    public void StartDialogue(Menu dCanvas, TextMeshProUGUI dText)
    {
        dialogueText = dText;
        dialogueCanvas = dCanvas;
        dialogueText.text = Sentences[0];
        dialogueText.maxVisibleCharacters = 0;
        currentChar = 0;
        GameManager.Paused = true;
        dialogueCanvas.Active = true;
        dialogueText = dText;

    }
    public void NextSentence()
    {
        if(sentenceInt < Sentences.Count - 1)
        {
            sentenceInt++;
            dialogueText.text = Sentences[sentenceInt];
            dialogueText.maxVisibleCharacters = 0;
            currentChar = 0;
            Complete = false;
        }
        else
        {
            dialogueCanvas.Active = false;
            GameManager.Paused = false;
            dialogueCanvas = null;
            dialogueText = null;
            Complete = false;
            currentChar = 0;
            sentenceInt = 0;

        }
    }
}
