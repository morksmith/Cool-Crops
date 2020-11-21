using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public bool DebugMode = true;
    public GameObject DebugCube;
    public MeshRenderer CubeMesh;
    public Transform PlayerMesh;
    public PlayerInventory Inventory;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        

        if (GameManager.Paused)
        {
            return;
        }
        

        if (Input.GetButtonDown("Fire1"))
        {
            Interact();
        }

        if (DebugMode)
        {
            if (Input.GetButton("Fire2"))
            {
                DebugCube.SetActive(true);
                var playerPos = PlayerMesh.position + PlayerMesh.forward * 1.2f;
                var snapPos = new Vector3(Mathf.Round(playerPos.x), Mathf.Round(playerPos.y), Mathf.Round(playerPos.z));
                DebugCube.transform.position = snapPos;
                CubeMesh.enabled = true;
            }
            else
            {
                DebugCube.SetActive(false);
            }
        }
        else
        {
            CubeMesh.enabled = true;
        }
    }
    public void Interact()
    {
        var rayStart = PlayerMesh.position + PlayerMesh.forward * 1f + PlayerMesh.up * 2;
        Ray ray = new Ray(rayStart, Vector3.down);        
        RaycastHit hit;
        if(Physics.SphereCast(ray, 0.25f, out hit))
        {
            Debug.Log(hit.transform.name);
            if (hit.transform.GetComponent<Fruit>())
            {
                var fruitInfo = hit.transform.GetComponent<Fruit>();
                Inventory.SetFruit(fruitInfo.Type.ToString(), 1);
                Destroy(hit.transform.gameObject);
            }
        }
    }
}
