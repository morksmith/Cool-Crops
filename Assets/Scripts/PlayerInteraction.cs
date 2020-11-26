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
    public Transform InteractionCanvas;
    public bool Interactable = false;
    public Transform InteractIcon;
    public GameManager Manager;

    public enum EpuippedItem
    {
        None,
        ASeed,
        BSeed,
        CSeed,
        Water,
        Shears,
        Scythe,
        Shovel,
        Pick,
        Spray,
        Poison
    }
    public EpuippedItem Item = EpuippedItem.None;

    public GameObject ASeedPrefab;
    public GameObject BSeedPrefab;
    public GameObject CSeedPrefab;

    private Vector3 rayStart;

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

        if (Input.GetButtonDown("Fire2"))
        {
            UseItem();
        }

        rayStart = PlayerMesh.position + PlayerMesh.forward * 1f + PlayerMesh.up * 2;
        Ray ray = new Ray(rayStart, Vector3.down);
        RaycastHit hit;
        if (Physics.SphereCast(ray, 0.25f, out hit))
        {
            
            if (hit.transform.GetComponent<Fruit>())
            {
                Interactable = true;
            }
            else
            {
                Interactable = false;
            }
        }
        else
        {
            Interactable = false;
        }

        if (Interactable)
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

        //if (DebugMode)
        //{
        //    if (Input.GetButton("Fire2"))
        //    {
        //        DebugCube.SetActive(true);
        //        var playerPos = PlayerMesh.position + PlayerMesh.forward * 1.2f;
        //        var snapPos = new Vector3(Mathf.Round(playerPos.x), Mathf.Round(playerPos.y), Mathf.Round(playerPos.z));
        //        DebugCube.transform.position = snapPos;
        //        CubeMesh.enabled = true;
        //    }
        //    else
        //    {
        //        DebugCube.SetActive(false);
        //    }
        //}
        //else
        //{
        //    CubeMesh.enabled = true;
        //}
    }
    public void Interact()
    {
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
    public void UseItem()
    {
        if(Item == EpuippedItem.Water)
        {
            UseWater();
        }
        else if(Item == EpuippedItem.ASeed)
        {
            if(Inventory.ASeeds > 0)
            {
                PlaceSeed(ASeedPrefab);
            }

        }
        else if (Item == EpuippedItem.BSeed)
        {
            if (Inventory.BSeeds > 0)
            {
                PlaceSeed(BSeedPrefab);
            }
        }
        else if (Item == EpuippedItem.CSeed)
        {
            if (Inventory.CSeeds > 0)
            {
                PlaceSeed(CSeedPrefab);
            }
        }
        else
        {
            Debug.Log("No Item Equipped");
        }
    }
    public void PlaceSeed(GameObject seed)
    {
        var playerPos = PlayerMesh.position + PlayerMesh.forward * 1.2f;
        var snapPos = new Vector3(Mathf.Round(playerPos.x), Mathf.Round(playerPos.y), Mathf.Round(playerPos.z));
        Ray ray = new Ray(snapPos + Vector3.up * 2, Vector3.down);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            //if (hit.transform.GetComponent<Dirt>())
            //{
            //    var newSeed = Instantiate(seed, snapPos, transform.rotation);
            //}
        }
    }

    public void EquipWater()
    {
        Item = EpuippedItem.Water;
        Manager.UpdateUI();
    }
    public void EquipASeed()
    {
        Item = EpuippedItem.ASeed;
        Manager.UpdateUI();

    }
    public void EquipBSeed()
    {
        Item = EpuippedItem.BSeed;
        Manager.UpdateUI();

    }
    public void EquipCSeed()
    {
        Item = EpuippedItem.CSeed;
        Manager.UpdateUI();

    }
    public void UseWater()
    {
        rayStart = PlayerMesh.position + PlayerMesh.forward * 1f + PlayerMesh.up * 2;
        Ray ray = new Ray(rayStart, Vector3.down);
        RaycastHit hit;
        if (Physics.SphereCast(ray, 0.25f, out hit))
        {

            if (hit.transform.GetComponent<Seed>())
            {
                var hitSeed = hit.transform.GetComponent<Seed>();
                hitSeed.Water();
            }
            
        }
    }

}
