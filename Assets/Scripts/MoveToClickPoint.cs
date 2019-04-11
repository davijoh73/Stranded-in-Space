using UnityEngine;
using UnityEngine.AI;

public class MoveToClickPoint : MonoBehaviour
{
    NavMeshAgent agent;
    public AudioSource soundSource;
    public AudioClip footStepsClip;
    public GameObject walkMessage;
    public float checkIfMoving, previousPos = 0, msgTimer = 10;
    bool hasWalked = false;

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
                    //Boolean variable to indicate user has moved at least once
                    hasWalked = true;
                }
            }
        }

        //Calculation to determine if the player is actually moving
        checkIfMoving = (previousPos - agent.remainingDistance);
        previousPos = agent.remainingDistance;

        //Debug.Log("Remaining distance between Agent and target position: " + agent.remainingDistance);
        //Debug.Log("checkIfMoving: " + checkIfMoving);

        //Play audio clip of footsteps if navmesh agent is moving
        if (agent.remainingDistance > 0 && checkIfMoving != 0)
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

        //Continue counting down the message timer until it hits zero
        if (msgTimer > 0)
        {
            msgTimer -= Time.deltaTime;
            //Debug.Log("msgTimer: " + msgTimer);
        }

        //If the user has not moved yet, and the timer reaches zero, display help message
        if (!hasWalked && msgTimer <= 0)
        {
            walkMessage.SetActive(true);
        }

        //Once user has walked once, remove the help message
        if (hasWalked)
        {
            walkMessage.SetActive(false);
        }
    }
}
