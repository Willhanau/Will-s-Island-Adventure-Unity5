using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    public static int charge = 0;
    public AudioClip collectSound;
    public Text textHints;
    //HUD
    public Sprite[] hudCharge;
    public Image chargeHudGUI; //name of UI Image
    //Generator
    public Texture2D[] meterCharge;
    public Renderer meter;
    //Matches
    public GameObject canvas;
    private bool haveMatches = false;
    private bool fireLit = false;
    public GameObject matchGUIprefab;
    private GameObject matchGUI;
    public GameObject winObj;

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

    void MatchPickup()
    {
        haveMatches = true;
        AudioSource.PlayClipAtPoint(collectSound, transform.position);
        GameObject matchHUD = Instantiate(matchGUIprefab, matchGUIprefab.transform.position, transform.rotation) as GameObject;
        matchHUD.transform.SetParent(canvas.transform, false);
        matchGUI = matchHUD;
    }

    void OnControllerColliderHit(ControllerColliderHit col)
    {
        if (col.gameObject.name == "campfire")
        {
            if (haveMatches == true && fireLit == false)
            {
                LightFire(col.gameObject);
            }
            else if (haveMatches == false && fireLit == false)
            {
                textHints.SendMessage("ShowHint", "I could use this campfire to signal for help... \n if only I could light it..");
            }
        }
    }

    void LightFire(GameObject campfire)
    {
        ParticleSystem[] fireEmitters;
        fireEmitters = campfire.GetComponentsInChildren<ParticleSystem>();
        foreach(ParticleSystem emitter in fireEmitters)
        {
            ParticleSystem.EmissionModule em = emitter.emission;
            em.enabled = true;
        }
        campfire.GetComponent<AudioSource>().Play();
        Destroy(matchGUI);
        haveMatches = false;
        fireLit = true;
        winObj.SendMessage("GameOver");
    }

}
