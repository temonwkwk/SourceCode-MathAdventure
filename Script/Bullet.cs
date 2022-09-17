using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	float moveSpeed = 7f,dmg;
	Rigidbody2D rb;
	GameObject target;
	GameObject[] enemy;
	public GameObject source;
	Vector2 moveDirection;

	// Use this for initialization
	void Start () {
		enemy = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().Enemy;
		if (enemy[0].activeInHierarchy)
		{
			target = enemy[0];
		}
		else if(!enemy[0].activeInHierarchy && enemy[1].activeInHierarchy)
		{
			target = enemy[1];
		}
		// else
		// {
		// 	Destroy(this);
		// }
		rb = GetComponent<Rigidbody2D>();
        // target = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().Enemy;
		moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
		rb.velocity = new Vector2 (moveDirection.x, moveDirection.y);
	    dmg = source.GetComponent<Stats>().Atk;
		
	}
	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject == target) {
			float HP = target.GetComponent<Stats>().HP;
			HP = HP - dmg;
			target.GetComponent<Stats>().HP = HP;
			Debug.Log(target.name +" "+ HP);
			Destroy(gameObject);
		}
	}

}