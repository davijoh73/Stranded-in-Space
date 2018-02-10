using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToClickPoint : MonoBehaviour
{
    NavMeshAgent agent;

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            //Cast ray from center of camera viewport (essentially, the reticle point)
            Vector3 reticle = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));

            if (Physics.Raycast(reticle, Camera.main.transform.forward, out hit, 100.0f))
            {
                //Do not want to move when clicking on walls or certain items that are interactive
                if (hit.collider.CompareTag("Item") || hit.collider.CompareTag("Wall"))
                {
                    agent.isStopped = true;
                }
                else
                {
                    agent.destination = hit.point;
                    agent.isStopped = false;
                }
            }
        }
    }
}
