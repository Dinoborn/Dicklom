using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Cudenos : MonoBehaviour
{
    private NavMeshAgent agent;
    private Camera camera;
    private Vector3 destination;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            Ray ray = camera.ScreenPointToRay(mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.CompareTag("Ground"))
                {
                    destination = hit.point;
                    agent.SetDestination(destination);
                }
            }
        }
    }
}





