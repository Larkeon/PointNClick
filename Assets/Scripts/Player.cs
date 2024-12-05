using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    private NavMeshAgent agent;
    private Camera cam;
    private Transform ultimoHit;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
        ComprobarInteraccion();
    }

    private void ComprobarInteraccion()
    {
        if(ultimoHit != null && ultimoHit.TryGetComponent(out NPC npc))
        {
            agent.stoppingDistance = 2f;

            if(agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            {
                npc.Interactuar(transform);

                ultimoHit = null;
            }
          
        }

        else if (ultimoHit)
        {
            agent.stoppingDistance = 0f;
        }
    }

    private void Movimiento()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                agent.SetDestination(hitInfo.point);

                ultimoHit = hitInfo.transform;
            }
        }
    }
}
