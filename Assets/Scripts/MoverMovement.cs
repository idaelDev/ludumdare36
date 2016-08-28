using UnityEngine;
using System.Collections;

public class MoverMovement : MonoBehaviour {

    public float speed = 10f;

    Vector3 direction = new Vector3(1, 1, 0);


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 translation = direction * speed * Time.deltaTime;
        Debug.DrawLine(transform.position, transform.position + direction,Color.red);
        transform.Translate(translation);
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        Vector2 v = new Vector2(transform.position.x, transform.position.y);
        direction = Vector2.Reflect(direction, other.contacts[0].normal);
    }

}
