using UnityEngine;
using UnityEngine.AI;

public class MoveToClickPoint : MonoBehaviour
{
    NavMeshAgent agent;
    public AudioSource soundSource;
    public AudioClip footStepsClip;

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
                    //Move to location that was hit with raycast
                    agent.destination = hit.point;
                    agent.isStopped = false;

                }
            }
        }

        //Play audio clip of footsteps if navmesh agent is moving
        if (agent.remainingDistance > 0)
        {
            //Don't play audio clip if the agent is not moving
            if (!agent.isStopped)
            {
                //Play audio clip of footsteps (only play if it is not already playing)
                if (!soundSource.isPlaying)
                {
                    soundSource.clip = footStepsClip;
                    soundSource.Play();
                }
            }
        }
        else
        {
            soundSource.Stop();
        }
    }
}
