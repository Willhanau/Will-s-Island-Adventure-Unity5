using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ThrowTrigger : MonoBehaviour {

    public Image crosshair;
    public Text textHints;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnTriggerEnter(Collider col)
    {   
        if(col.gameObject.tag == "Player")
        {
            if (CoconutWin.haveWon != true)
            {
                textHints.SendMessage("ShowHint", "\n\n\n\n\n\n\n There's a power cell attached to this game, \n maybe I'll win it if I can Knock down all the targets...");
            }
            crosshair.enabled = true;
            CoconutThrower.canThrow = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            crosshair.enabled = false;
            CoconutThrower.canThrow = false;
        }
    }

}
