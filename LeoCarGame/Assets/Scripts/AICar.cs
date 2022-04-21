using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; // access to nav mesh agent stuff

public class AICar : MonoBehaviour
{
    public NavMeshAgent agent; // AI to navigate the world
    public Transform[] roadPoints; // points in our map the ai car can drive to
    public int currentRoadPoint; // which road point we're currently moving to
    public bool reachedPoint; // to know if we've reached a spot on the thing
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(roadPoints[currentRoadPoint].position); // continuesly move the AI car to a roadpoint

        if(agent.remainingDistance <= 0.2f && reachedPoint == false) // once it reaches/gets close to the current point it's going to
        {
            StartCoroutine(MoveToNextSpot());
        }
    }

    IEnumerator MoveToNextSpot()
    {
        reachedPoint = true;
        currentRoadPoint++; // increase road point to go to
        if (currentRoadPoint >= roadPoints.Length) // if there is no more road points to go to
        {
            currentRoadPoint = 0; // reset back to 0
        }
        yield return new WaitForSeconds(1);
        reachedPoint = false;
    }
}
