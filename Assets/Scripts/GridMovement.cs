﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour
{
    public bool Moving = false;
    public float MoveSpeed = 5;
    public Transform PlayerMesh;

    private Vector3 rayPos;
    private Vector3 movePos;
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


        if (Moving)
        {
            PlayerMesh.rotation = Quaternion.LookRotation(movePos - transform.position);

            if (Vector3.Distance(transform.position, movePos) > 0.01f)
            {
                transform.position = Vector3.MoveTowards(transform.position, movePos, MoveSpeed * Time.deltaTime);
            }
            else
            {
                transform.position = movePos;
                Moving = false;
            }
        }



        if (Input.GetAxis("Vertical") > 0)
        {
            rayPos = transform.position + Vector3.up * 2 + Vector3.forward * 1;

            if (!Moving)
            {
                movePos = new Vector3(transform.position.x, transform.position.y, Mathf.Round(transform.position.z + 1));
                PlayerMesh.rotation = Quaternion.LookRotation(movePos - transform.position);
                Ray ray = new Ray(rayPos, Vector3.down);
                RaycastHit hit;
                if(Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.tag == "Ground")
                    {                        
                        Moving = true;
                    }
                }
            }
        }
        if (Input.GetAxis("Vertical") < 0)
        {

            rayPos = transform.position + Vector3.up * 2 + Vector3.forward * -1;

            if (!Moving)
            {
                movePos = new Vector3(transform.position.x, transform.position.y, Mathf.Round(transform.position.z - 1));
                PlayerMesh.rotation = Quaternion.LookRotation(movePos - transform.position);
                Ray ray = new Ray(rayPos, Vector3.down);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.tag == "Ground")
                    {
                        
                        Moving = true;
                    }
                }
            }
        }
        if (Input.GetAxis("Horizontal") > 0)
        {

            rayPos = transform.position + Vector3.up * 2 + Vector3.right * 1;

            if (!Moving)
            {
                movePos = new Vector3(Mathf.Round(transform.position.x + 1), transform.position.y, transform.position.z);
                PlayerMesh.rotation = Quaternion.LookRotation(movePos - transform.position);
                Ray ray = new Ray(rayPos, Vector3.down);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.tag == "Ground")
                    {
                        
                        Moving = true;
                    }
                }
            }
        }
        if (Input.GetAxis("Horizontal") < 0)
        {

            rayPos = transform.position + Vector3.up * 2 + Vector3.right * -1;
            if (!Moving)
            {
                movePos = new Vector3(Mathf.Round(transform.position.x - 1), transform.position.y, transform.position.z);
                PlayerMesh.rotation = Quaternion.LookRotation(movePos - transform.position);
                Ray ray = new Ray(rayPos, Vector3.down);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.tag == "Ground")
                    {
                        
                        Moving = true;
                    }
                }
            }
        }
    }
}
