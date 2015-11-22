using UnityEngine;
using System.Collections;

public class MasterControl : MonoBehaviour {
	public static MasterControl master;
	public float bpm = 150;
	public float tickRate;
	public float measureSpeed = 5f;
    public int difficulty=1;
    public GameObject title;
    public GameObject game;
    public Transform cat;

	void Awake(){
        
		master = this;
        title = this.transform.FindChild("TitleCanvas").gameObject;
        game = this.transform.FindChild("MusicCanvas").gameObject;
        GotoTitle();
		tickRate = (1/(bpm/60))/16;
		//Debug.Log (tickRate);
       
        
        cat = this.transform.FindChild("TitleCanvas").FindChild("Background").FindChild("Cat").transform;
        
        
	}
	void Start () {
        
	}
    public void GotoTitle() {
        title.gameObject.SetActive(true);
        game.gameObject.SetActive(false);
    }


    public void GotoGame()
    {
        title.gameObject.SetActive(false);
        game.gameObject.SetActive(true);
    }
    public void Easy()
    {
        difficulty = 1;
        cat.localPosition = new Vector3(130,-100,0);

    }
    public void Medium()
    {
        difficulty = 2;
        cat.localPosition = new Vector3(130, -170, 0);
    }
    public void Hard()
    {
        difficulty = 3;
        cat.localPosition = new Vector3(130, -240, 0);
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
	}
}
