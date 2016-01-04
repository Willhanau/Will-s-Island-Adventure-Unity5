using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WinGame : MonoBehaviour {

    public GameObject winSequence;
    public GameObject fader;
    public AudioClip winClip;
    public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator GameOver()
    {
        AudioSource.PlayClipAtPoint(winClip, player.transform.position);
        winSequence.SetActive(true);
        yield return new WaitForSeconds(8.0f);
        fader.SetActive(true);
    }

}

