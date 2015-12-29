using UnityEngine;
using System.Collections;

public class PlayerCollisions : MonoBehaviour {

    GameObject currentDoor;
    
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        
        if(Physics.Raycast(transform.position, transform.forward, out hit, 3))
        {
            if(hit.collider.gameObject.tag == "playerDoor")
            {
                currentDoor = hit.collider.gameObject;
                currentDoor.SendMessage("DoorCheck");
            }
        }
	}

    /*void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag == "playerDoor" && doorIsOpen == false)
        {
            currentDoor = hit.gameObject;
            Door(doorOpenSound, true, "dooropen", currentDoor); //door open animaton and sound
        }
    }

    void OpenDoor(GameObject door)
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
    }

    void Door(AudioClip aClip, bool openCheck, string animName, GameObject thisDoor) // does both what functions OpenDoor() and ShutDoor() do in one function
    {
        thisDoor.GetComponent<AudioSource>().PlayOneShot(aClip);
        doorIsOpen = openCheck;
        thisDoor.transform.parent.GetComponent<Animation>().Play(animName);
    }*/

}
