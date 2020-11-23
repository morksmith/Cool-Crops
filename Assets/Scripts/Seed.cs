using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour
{
    public enum SeedType
    {
        ASeed,
        BSeed,
        CSeed
    }
    public SeedType Type;
    public bool Wet = false;
    public float GrowTime;
    public Transform WetMesh;
    public GameObject FruitPrefab;

    private float growTimer;
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

        if (Wet)
        {
            growTimer += Time.deltaTime;
            if(growTimer > GrowTime)
            {
                SpawnFruit();
            }
        }
        
    }
    public void Water()
    {
        WetMesh.gameObject.SetActive(true);
    }
    public void SpawnFruit()
    {
        var newFruit = Instantiate(FruitPrefab, transform.position, transform.rotation);
        Destroy(transform.gameObject);
    }
}
