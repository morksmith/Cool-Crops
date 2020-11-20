using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public bool Debug = true;
    public GameObject DebugCube;
    public MeshRenderer CubeMesh;
    public Transform PlayerMesh;
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

        if (Debug)
        {
            if (Input.GetButton("Fire1"))
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
}
