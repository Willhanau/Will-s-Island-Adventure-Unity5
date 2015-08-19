using UnityEngine;
using System.Collections;

public class Shooter: MonoBehaviour {
	public Rigidbody bullet;
	public float power = 1500f;
	public float moveSpeed = 2f;
	// Update is called once per frame
	void Update () {
		float hori = Input.GetAxis ("Horizontal") * Time.deltaTime * moveSpeed;
		float vert = Input.GetAxis ("Vertical") * Time.deltaTime * moveSpeed;
		transform.Translate (hori, vert, 0);
		if (Input.GetButtonUp ("Fire1")) {
			Vector3 m_pos = Input.mousePosition;
			m_pos.z = 10f;
			Vector3 mouse_pos = Camera.main.ScreenToWorldPoint(m_pos);

			Rigidbody instance = Instantiate(bullet, mouse_pos, transform.rotation) as Rigidbody;
			Vector3 fwd = transform.TransformDirection (Vector3.forward);
			instance.AddForce(fwd * power);
		}
	}
}
