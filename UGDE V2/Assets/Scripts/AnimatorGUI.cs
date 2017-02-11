using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AnimatorGUI : MonoBehaviour {
	[SerializeField]
	private Canvas gui;
	private float sreenWidth;
	private float xStartPosition;
	private float xEndPosition;
    public float speed = 1.0f;
    float startTime;

	// Use this for initialization
	void Start () {
        startTime = Time.time;
		sreenWidth = gui.pixelRect.width;
		xStartPosition = sreenWidth + (sreenWidth/2);
		xEndPosition = sreenWidth/2;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = new Vector3(Mathf.Lerp(xStartPosition, xEndPosition, (Time.time - startTime) * speed), transform.position.y, transform.position.z);
        transform.position = pos;
	}
}
