using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;


public enum AttackModes
{
    bubbleBlast,
    shockwave
}

public class boss : MonoBehaviour
{
    public List<GameObject> bubbleBlastLevels;
    public GameObject shockwaveObj;
    public Material[] materials;
    public shockwaveOpperator shock;
    public HpPool hp;
    public Flowchart flwcrt;

    public float fireRate;
    public float currFireRate;

    public AttackModes nextAttackMode;

    public travelDirection direction;
    public GameObject startPos;
    public GameObject endPos;
    public GameObject trigger;
    public GameObject psfx;
    public float travelUpSpeed;
    public float travelDownSpeed;
    private float startTime;
    private float journeyLength;
    float hp_max;
    bool activatewave=true,finalphase=false;
    public GameObject waveController;
    // Start is called before the first frame update
    void Start()
    {
        trigger.GetComponent<Collider>().enabled = false;
        //shock = GetComponent<shockwaveOpperator>();
        startTime = Time.fixedTime;
        journeyLength = Vector3.Distance(startPos.transform.position, endPos.transform.position);
        hp_max = hp.HP;
        GetComponent<MeshRenderer>().material = materials[0];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (hp.HP <= 0)
        {
            kill();
        }
        else
        {
            currFireRate += Time.fixedDeltaTime;
            if (currFireRate > fireRate)
            {

                switch (nextAttackMode)
                {
                    case AttackModes.bubbleBlast:
                        bubbleBlast();
                        break;
                    case AttackModes.shockwave:
                        shockwave();
                        break;
                    default:
                        break;
                }
                currFireRate = 0;
            }
            if (nextAttackMode == AttackModes.shockwave)
            {
                shockwave();
            }
        }
        if (!finalphase)
        {
            if (hp.HP < hp_max - 100 && activatewave)
            {
                waveController.GetComponent<waveController>().Activate1stwave();
                activatewave = false;
                GetComponent<MeshRenderer>().material = materials[1];
            }

            if (hp.HP < hp_max *3/4)
            {
                GetComponent<MeshRenderer>().material = materials[2];
            }
            if (hp.HP < hp_max /2)
            {
                GetComponent<MeshRenderer>().material = materials[3];
                flwcrt.ExecuteBlock("phase2");
                finalphase = true;
            }
        }
    }

    void bubbleBlast()
    {
        int ind = Random.Range(0, bubbleBlastLevels.Count);
        var guns = bubbleBlastLevels[ind].GetComponentsInChildren<gun>();

        foreach (var _gun in guns)
        {
            if (_gun.tick())
            {
                _gun.fire();
            }
        }
        
        if(Random.Range(0.0f,1.0f)>0.6f)
        {
            nextAttackMode = AttackModes.bubbleBlast;
        }else if(hp.HP < hp_max /2)
        nextAttackMode = AttackModes.shockwave;
    }
    void shockwaveSlam()
    {
        shock.activateAttack();

        nextAttackMode = AttackModes.bubbleBlast;
    }
    void shockwave()
    {
        switch (direction)
        {
            case travelDirection.up:
                travelInDirection(endPos, travelUpSpeed);
                if (Vector3.Distance(transform.position, endPos.transform.position) < 1)
                {
                    direction = travelDirection.down;
                }
                break;
            case travelDirection.down:
                travelInDirection(startPos, travelDownSpeed);
                if (Vector3.Distance(transform.position, startPos.transform.position) < 1)
                {
                    transform.position = startPos.transform.position;
                    //setup for next time
                    direction = travelDirection.up;
                    //do attack stuff 
                    shockwaveSlam();
                    flwcrt.ExecuteBlock("Shake");
                   psfx.GetComponent<ParticleSystem>().Play();
                }
                break;
            case travelDirection.inactive:
                break;
            default:
                break;
        }




    }


    void travelInDirection(GameObject target, float speed)
    {
        // Distance moved equals elapsed time times speed..
        float distCovered = (Time.fixedTime - startTime) * speed;
        ;

        // Fraction of journey completed equals current distance divided by total distance.
        float fractionOfJourney = distCovered / journeyLength;

        // Set our position as a fraction of the distance between the markers.
        transform.position = Vector3.Lerp(transform.position, target.transform.position, fractionOfJourney);
    }

    void kill()
    {
        transform.localPosition = Vector3.zero;
        //Destroy(gameObject);
        if(waveController)
        {
            Destroy(waveController);
        }
        trigger.GetComponent<Collider>().enabled=true;
    }
}
