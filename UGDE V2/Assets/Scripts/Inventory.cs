using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    public static int charge = 0;
    public AudioClip collectSound;
    //HUD
    public Sprite[] hudCharge;
    public Image chargeHudGUI; //name of UI Image
    //Generator
    public Texture2D[] meterCharge;
    public Renderer meter;

	// Use this for initialization
	void Start () {
        charge = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void CellPickup()
    {
        HUDon();
        AudioSource.PlayClipAtPoint(collectSound, transform.position);
        charge++;
        chargeHudGUI.sprite = hudCharge[charge]; //changes UI Image to a Sprite from array hudCharge
        meter.material.mainTexture = meterCharge[charge];
    }

    void HUDon()
    {
        if (chargeHudGUI.enabled != true)
        {
            chargeHudGUI.enabled = true;
        }
    }

}
