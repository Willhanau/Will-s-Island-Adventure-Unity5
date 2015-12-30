using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextHints : MonoBehaviour {

    private float timer = 0.0f; 
    public Text hintText;

    // Use this for initialization
    void Start () {
        timer = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
	    if(hintText.enabled == true)
        {
            timer += Time.deltaTime;
            if(timer >= 4)
            {
                hintText.enabled = false;
                timer = 0.0f;
            }
        }

	}

    void ShowHint(string message)
    {
        hintText.text = message;
        if(hintText.enabled != true)
        {
            hintText.enabled = true;
        }

    }

}
