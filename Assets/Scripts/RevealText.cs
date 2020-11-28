using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class RevealText : MonoBehaviour
{
    private TextMeshProUGUI tmpro;
    public bool Complete = false;
    public float RevealSpeed = 5;
    private float revealTimer;
    private int currentChar;
    // Start is called before the first frame update
    void Start()
    {
        tmpro = GetComponent<TextMeshProUGUI>();
        tmpro.maxVisibleCharacters = 0;
        currentChar = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Complete)
        {
            revealTimer += Time.deltaTime * RevealSpeed;
            if(revealTimer > 1)
            {
                tmpro.maxVisibleCharacters += 1;
                revealTimer = 0;
                Debug.Log(tmpro.text[currentChar]);
                if (currentChar < tmpro.text.Length - 1)
                {
                    currentChar++;
                }
            }

        }
    }
}
