using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour {
	float moveSpeed = 7f,dmg;
	Rigidbody2D rb;
	GameObject target;
	public GameObject source;
	Vector2 moveDirection;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().Hero;
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
        	Destroy (gameObject);
		}
	}

}
