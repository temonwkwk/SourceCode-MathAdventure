using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public float HP,Atk,Interval;
    float Nextfire;
    public GameObject Bullet;
    // Start is called before the first frame update
    void Start()
    {
        Nextfire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
        if (HP <= 0)
        {
            gameObject.SetActive(false);
        }
    }
    
    void Attack()
    {
        if (Time.time > Nextfire) {
			Instantiate (Bullet, transform.position, Quaternion.identity);
			Nextfire = Time.time + Interval;
		}
    }
}
