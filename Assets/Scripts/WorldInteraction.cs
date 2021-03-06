﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WorldInteraction : MonoBehaviour {

    NavMeshAgent playerAgent;

    private void Start()
    {
        playerAgent = GetComponent<NavMeshAgent>();

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            GetInteraction();
        }
    }

    void GetInteraction()
    {
        Ray interactionRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit interactionInfo;
        if (Physics.Raycast(interactionRay, out interactionInfo, Mathf.Infinity))
        {
            GameObject interactionObject = interactionInfo.collider.gameObject;
            if(interactionObject.tag == "Enemy")
            {
                interactionObject.GetComponent<Interactable>().MoveToInteraction(playerAgent);
            }
            else
            {
                playerAgent.stoppingDistance = 0f;
                playerAgent.destination = interactionInfo.point;
            }
        }
    }
}
