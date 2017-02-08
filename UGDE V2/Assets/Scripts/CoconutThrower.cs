using UnityEngine;
using System.Collections;
[RequireComponent (typeof (AudioSource))]

public class CoconutThrower : MonoBehaviour {
	[SerializeField]
	private Camera _camera;
	private float nextFire;
	private float fireRate = 0.25f;
	private float angle = 30.0f;
    public static bool canThrow = false;
    public AudioClip throwSound;
    public Rigidbody coconutPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1") && canThrow == true && Time.time > nextFire)
        {
			nextFire = Time.time + fireRate;
			Vector3 point = new Vector3 (_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
			Ray ray = _camera.ScreenPointToRay (point);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
				GetComponent<AudioSource> ().PlayOneShot (throwSound);
				Rigidbody newCoconut = Instantiate (coconutPrefab, transform.position, transform.rotation) as Rigidbody;
				newCoconut.name = "coconut";
				newCoconut.velocity = calcBallisticVelocityVector (hit);

			}
        }
	}

	Vector3 calcBallisticVelocityVector(RaycastHit hit){
		Vector3 direction = hit.point - transform.position;
		float h = direction.y;
		direction.y = 0;
		float dist = direction.magnitude;
		float a = angle * Mathf.Deg2Rad;
		direction.y = dist * Mathf.Tan (a);
		dist += h/(Mathf.Tan(a));
		float velocity = Mathf.Sqrt ((dist * Physics.gravity.magnitude) / Mathf.Sin (2 * a));
		return velocity * direction.normalized;
	}


}
