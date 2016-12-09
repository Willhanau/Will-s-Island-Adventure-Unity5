using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AnimatorGUI : MonoBehaviour {

    private float xStartPosition = Screen.width + (Screen.width/2);
    private float xEndPosition = Screen.width/2;
    public float speed = 1.0f;
    float startTime;

	// Use this for initialization
	void Start () {
        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = new Vector3(Mathf.Lerp(xStartPosition, xEndPosition, (Time.time - startTime) * speed), transform.position.y, transform.position.z);
        transform.position = pos;
	}
}
