using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    public static int charge = 0;
    public AudioClip collectSound;
    //HUD
    public Sprite[] hudCharge;
    public Image chargeHudGUI; //name of UI Image

	// Use this for initialization
	void Start () {
        charge = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void CellPickup()
    {
        AudioSource.PlayClipAtPoint(collectSound, transform.position);
        charge++;
        chargeHudGUI.sprite = hudCharge[charge]; //changes UI Image to a Sprite from array hudCharge
    }

}
