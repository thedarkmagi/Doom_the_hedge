using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public HpPool hp;
    NavMeshAgent agent;

    public gun _gun;
    public SphereCollider agroRange;
    public argo agg;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(hp.HP<0)
        {
            kill();
        }
        if (agg.agrroed)
        {
            if (_gun.tick())
            {
                _gun.fire();
            }

            agent.SetDestination(gamemanager.instance.player.transform.position);
        }
    }

    private void LateUpdate()
    {
        transform.forward = new Vector3(Camera.main.transform.forward.x,
            transform.forward.y, Camera.main.transform.forward.z);
    }


    void kill()
    {
        Destroy(this.gameObject);
    }
}
