using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class shotgunBlast : MonoBehaviour
{
    public float damage;
    public float lifetime;
    public string targetTag;

    public BoxCollider _collider;


    public float m_MaxDistance;
    bool m_HitDetect;

    public GameObject bullet;
    RaycastHit[] m_Hit;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        lifetime -= 1;
        if (lifetime < 0)
        {
            kill();
        }
        else
        {
            m_Hit = Physics.BoxCastAll(_collider.bounds.center, transform.localScale,
                transform.forward, transform.rotation, m_MaxDistance);
            if (m_Hit.Length > 0)
            {
                //Output the name of the Collider your Box hit
                //Debug.Log("Hit : " + m_Hit.collider.name);
                for (int i = 0; i < m_Hit.Length; i++)
                {
                    if (m_Hit[i].collider.CompareTag(targetTag))
                    {
                        var target = m_Hit[i].collider.gameObject.GetComponent<HpPool>();
                        target.takeDamage(damage);
                    }
                }
            }

        }    
    }

    void kill()
    {
        gameObject.SetActive(false);
    }

    public void fire()
    {
        gameObject.SetActive(true);
        //sounds play here
        var shot = Instantiate(bullet, transform.position, Quaternion.identity, null);
        var data = shot.GetComponent<dumbyShot>();
        data.lifetime = 4;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        //Draw a Ray forward from GameObject toward the maximum distance
        Gizmos.DrawRay(transform.position, transform.forward * m_MaxDistance);
        //Draw a cube at the maximum distance
        Gizmos.DrawWireCube(transform.position + transform.forward * m_MaxDistance, transform.localScale);

    }
}
