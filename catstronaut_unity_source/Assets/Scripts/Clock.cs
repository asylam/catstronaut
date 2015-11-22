using UnityEngine;
using System.Collections;

public class Clock : MonoBehaviour {
	float time=0;
	// Use this for initialization
	void Start () {
		Tick ();
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		while (time >= MasterControl.master.tickRate) {
			time -=MasterControl.master.tickRate;
			Tick ();
		}
	}
	public void Tick(){
		MusicControl.musicController.Tick ();
	}
}
