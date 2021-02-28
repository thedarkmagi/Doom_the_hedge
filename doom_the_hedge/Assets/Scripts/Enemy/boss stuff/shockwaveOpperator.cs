using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum travelDirection
{
    up,
    down,
    inactive
}

public class shockwaveOpperator : MonoBehaviour
{
    public GameObject shockwaveStartPoint;
    public GameObject shockwaveEndPoint;

    public float travelUpSpeed;
    public float travelDownSpeed;
    public float damage;

    private float startTime;
    private float journeyLength;

    public travelDirection direction;
    public Collider hitbox;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        journeyLength = Vector3.Distance(shockwaveStartPoint.transform.position, shockwaveEndPoint.transform.position);
        hitbox.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        switch (direction)
        {
            case travelDirection.up:
                travelInDirection(shockwaveEndPoint, travelUpSpeed);
                if(Vector3.Distance(transform.position, shockwaveEndPoint.transform.position)<1)
                {
                    direction = travelDirection.down;
                    hitbox.enabled = false;
                }
                break;
            case travelDirection.down:
                travelInDirection(shockwaveStartPoint, travelDownSpeed);
                if (Vector3.Distance(transform.position, shockwaveStartPoint.transform.position) < 1)
                {
                    transform.localPosition = Vector3.zero;
                    direction = travelDirection.inactive;
                }
                break;
            case travelDirection.inactive:
                break;
            default:
                break;
        }
    }

    public void activateAttack()
    {
        //should I update this? hmmmm 
        startTime = Time.time;
        direction = travelDirection.up;
        hitbox.enabled = true;
    }

    void travelInDirection(GameObject target, float speed)
    {
        // Distance moved equals elapsed time times speed..
        float distCovered = (Time.time - startTime) * speed;
;

        // Fraction of journey completed equals current distance divided by total distance.
        float fractionOfJourney = distCovered / journeyLength;

        // Set our position as a fraction of the distance between the markers.
        transform.position = Vector3.Lerp(transform.position, target.transform.position, fractionOfJourney);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            // pew pew do damage 
            var target = other.gameObject.GetComponent<HpPool>();
            target.takeDamage(damage);
        }
    }
}
