using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class RevealText : MonoBehaviour
{
    public TextMeshProUGUI DialogueText;
    public List<string> Sentences;
    public bool Complete = false;
    public float RevealSpeed = 5;
    private float revealTimer;
    private int currentChar;
    private int sentenceInt = 0;
    // Start is called before the first frame update
    void Start()
    {
        DialogueText.maxVisibleCharacters = 0;
        currentChar = 0;
        DialogueText.text = Sentences[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (!Complete)
        {
            if(DialogueText.maxVisibleCharacters < DialogueText.text.Length)
            {
                revealTimer += Time.deltaTime * RevealSpeed;
                if (revealTimer > 1)
                {
                    DialogueText.maxVisibleCharacters += 1;
                    revealTimer = 0;
                    Debug.Log(DialogueText.text[currentChar]);
                    if (currentChar < DialogueText.text.Length - 1)
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

    public void NextSentence()
    {
        if(sentenceInt < Sentences.Count - 1)
        {
            sentenceInt++;
            DialogueText.text = Sentences[sentenceInt];
            DialogueText.maxVisibleCharacters = 0;
            currentChar = 0;
            Complete = false;
        }
        else
        {
            Debug.Log("Close Dialogue");
        }
    }
}
