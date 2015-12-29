using UnityEngine;
using System.Collections;

public class PlayerCollisions : MonoBehaviour {

    GameObject currentDoor;
    private bool doorIsOpen = false;
    private float doorTimer = 0.0f;

    public float doorOpenTime = 3.0f;
    public AudioClip doorOpenSound;
    public AudioClip doorShutSound;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(doorIsOpen == true)
        {
            doorTimer += Time.deltaTime;
            if(doorTimer > doorOpenTime)
            {
                Door(doorShutSound, false, "doorshut", currentDoor); //door shut animation and sound
                doorTimer = 0.0f;
            }
        }


	}

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag == "playerDoor" && doorIsOpen == false)
        {
            currentDoor = hit.gameObject;
            Door(doorOpenSound, true, "dooropen", currentDoor); //door open animaton and sound
        }
    }

    /*void OpenDoor(GameObject door)
    {
        doorIsOpen = true;
        door.GetComponent<AudioSource>().PlayOneShot(doorOpenSound);
        door.transform.parent.GetComponent<Animation>().Play("dooropen");
    }

    void ShutDoor(GameObject door)
    {
        doorIsOpen = false;
        door.GetComponent<AudioSource>().PlayOneShot(doorShutSound);
        door.transform.parent.GetComponent<Animation>().Play("doorshut");
    }*/

    void Door(AudioClip aClip, bool openCheck, string animName, GameObject thisDoor) // does both what functions OpenDoor() and ShutDoor() do in one function
    {
        thisDoor.GetComponent<AudioSource>().PlayOneShot(aClip);
        doorIsOpen = openCheck;
        thisDoor.transform.parent.GetComponent<Animation>().Play(animName);
    }

}
