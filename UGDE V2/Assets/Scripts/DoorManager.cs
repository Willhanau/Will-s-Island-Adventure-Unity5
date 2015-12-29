using UnityEngine;
using System.Collections;

public class DoorManager : MonoBehaviour
{

    private bool doorIsOpen = false;
    private float doorTimer = 0.0f;

    public float doorOpenTime = 3.0f;
    public AudioClip doorOpenSound;
    public AudioClip doorShutSound;

    // Use this for initialization
    void Start()
    {
        doorTimer = 0.0F;
    }

    // Update is called once per frame
    void Update()
    {
        if (doorIsOpen == true)
        {
            doorTimer += Time.deltaTime;
            if (doorTimer > doorOpenTime)
            {
                Door(doorShutSound, false, "doorshut"); //door shut animation and sound
                doorTimer = 0.0f;
            }
        }
    }

    void DoorCheck()
    {
        if(doorIsOpen == false) //if door is closed do...
        {
            Door(doorOpenSound, true, "dooropen");
        }
    }

    void Door(AudioClip aClip, bool openCheck, string animName)
    {
        GetComponent<AudioSource>().PlayOneShot(aClip);
        doorIsOpen = openCheck;
        transform.parent.gameObject.GetComponent<Animation>().Play(animName);
    }



}