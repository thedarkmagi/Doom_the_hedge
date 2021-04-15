using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating : MonoBehaviour
{
    public float objectHeight;
    public Vector3 startPosition;
    public float floatSpeed;
    public float floatAmount;
    public Vector3 endPosition;
    public float length;
    private float startTime;
    public bool direction = true, move = false, combo = false, flying = false;
    // Start is called before the first frame update
    void Start()
    {
        moveBoard();
    }

    // Update is called once per frame
    void Update()
    {
        fly();
    }

    void fly()
    {

        float distCovered = (Time.time - startTime) * floatSpeed;
        float fractionOfJourney = distCovered / length;
        if (direction)
        {
            // Set our position as a fraction of the distance between the markers.
            transform.position = Vector3.Lerp(startPosition, endPosition, fractionOfJourney);
            if (transform.position == endPosition)
            {
                startTime = Time.time;
                direction = false;
            }

        }
        else if (!direction)
        {
            transform.position = Vector3.Lerp(endPosition, startPosition, fractionOfJourney);
            if (transform.position == startPosition)
            {
                startTime = Time.time;
                direction = true;
            }
        }

    }
    void moveBoard()
    {
        startTime = Time.time;
        startPosition = gameObject.transform.position;
        objectHeight = transform.position.y;
        endPosition = startPosition;
        endPosition += new Vector3(0, floatAmount, 0);
        length = Vector3.Distance(startPosition, endPosition);
    }
}
