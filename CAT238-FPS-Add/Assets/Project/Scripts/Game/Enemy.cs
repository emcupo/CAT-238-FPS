using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 5;
    public int damage = 5;

    private bool killed = false;
    public bool Killed { get { return killed; } }
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Bullet>() != null)
        {
            Bullet bullet = other.GetComponent<Bullet>();
            if (bullet.ShotByPlayer == true)
            {

                health -= bullet.damage;
                bullet.gameObject.SetActive(false);

                if (health <= 0)
                {
                    if (killed == false)
                    {
                        killed = true;
                        OnKill();
                        //Destroy(gameObject);
                    }
                }
            }
        }
    }

    protected virtual void OnKill()
    {

    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

