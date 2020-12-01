using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
   
    public Transform PlayerMesh;
    public Transform InteractionCanvas;
    private bool inRange = false;
    public Transform InteractIcon;
    private Vector3 rayStart;
    public Menu DialogueCanvas;
    public TextMeshProUGUI DialogueText;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        InteractionCanvas.forward = Camera.main.transform.forward;

        if (GameManager.Paused)
        {
            return;
        }
                
        rayStart = PlayerMesh.position + PlayerMesh.forward * 1f + PlayerMesh.up * 2;
        Ray ray = new Ray(rayStart, Vector3.down);
        RaycastHit hit;
        if (Physics.SphereCast(ray, 0.25f, out hit))
        {            
            if (hit.transform.GetComponent<Interactable>() || hit.transform.GetComponent<RevealText>())
            {
                inRange = true;
            }
            else
            {
                inRange = false;
            }
        }
        else
        {
            inRange = false;
        }

        if (inRange)
        {
            InteractIcon.localScale = Vector3.Lerp(InteractIcon.localScale, Vector3.one, Time.deltaTime * 10);
            if (Input.GetButtonDown("Fire1"))
            {
                Interact();
            }
        }
        else
        {
            InteractIcon.localScale = Vector3.Lerp(InteractIcon.localScale, Vector3.zero, Time.deltaTime * 10);
        }

    }
    public void Interact()
    {
        Ray ray = new Ray(rayStart, Vector3.down);        
        RaycastHit hit;
        if(Physics.SphereCast(ray, 0.25f, out hit))
        {
            Debug.Log(hit.transform.name);
            if (hit.transform.GetComponent<Interactable>())
            {
                var i = hit.transform.GetComponent<Interactable>();
                i.TriggerInteractable();
            }
            else if (hit.transform.GetComponent<RevealText>())
            {
                var t = hit.transform.GetComponent<RevealText>();
                t.StartDialogue(DialogueCanvas, DialogueText);
            }

        }
    }
    
    

    

}
