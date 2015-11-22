using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;

public class MusicControl : MonoBehaviour {
	
	public static MusicControl musicController;
	
	//public Image detectorbar;
	public Image ring;
    public Transform rainbow;
	public Sprite[] astro_sprites, cat_sprites, space_sprites;
	public Transform[] measureBars;
	public Transform note, Circle, astro, cat, space, space2;
    public Text scoreText;
    public Text multpyerText;
    public Text Credits;

	int numTick;
	List<Transform> notes;
	LinkedList<char> spawnList;
	char[] keys = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

	bool goUp = true;
	int markColor = 0, catnum = 0;
	string lastNote;
	int timeout = 0;
    int score = 0;
    float multiplyer = 1;
    
	
	void Awake () {
		musicController = this;
		//detectorbar = transform.FindChild("MusicBackground").FindChild("MusicBar").FindChild("Circle").FindChild("PlaceHolder").GetComponent<Image>();
		ring = transform.FindChild("MusicBackground").FindChild("MusicBar").FindChild("Circle").FindChild("Ring").GetComponent<Image>();
		note = transform.FindChild("MusicBackground").FindChild("MusicBar").FindChild("Circle").FindChild("Note");
		Circle = transform.FindChild("MusicBackground").FindChild("MusicBar").FindChild("Circle");
		astro = transform.FindChild ("MusicBackground").FindChild ("Astronaut");
		cat = transform.FindChild ("MusicBackground").FindChild ("Cat");
        rainbow = transform.FindChild("MusicBackground").FindChild("MusicBar").FindChild("Rainbow");
        scoreText = transform.FindChild("MusicBackground").FindChild("MusicBar").FindChild("Rainbow").FindChild("Score").GetComponent<Text>();
        multpyerText = transform.FindChild("MusicBackground").FindChild("MusicBar").FindChild("Rainbow").FindChild("Multiplyer").GetComponent<Text>();
        Credits = transform.FindChild("Credits").GetComponent<Text>();
        notes = new List<Transform>();
		spawnList = new LinkedList<char>();
		measureBars = new Transform[3];
		for (int i = 0; i<3; i++)
			measureBars [i] = transform.FindChild ("MusicBackground").FindChild ("MusicBar").FindChild ("Circle").FindChild ("MeasureBar"+(i+1)).GetComponent<Transform>();
		numTick = 0;
	}
	void Start() {
        score = 0;
        multiplyer = 1;
		readFile("Assets/Tracks/input.txt");
		
	}
	void Update () {
        if (notes.Count == 0 && spawnList.Count == 0)
            Credits.transform.localPosition = new Vector3(0, -300, 0);
        scoreText.text = "Score: " + score;
        multpyerText.text = "X" + ((int)multiplyer);
        if (Input.GetKeyDown(KeyCode.Return))
            Application.LoadLevel("MainScene");
        string keyPressed = null;
		if (Input.GetKeyDown(KeyCode.A))
			keyPressed = "a";
		if (Input.GetKeyDown(KeyCode.B))
			keyPressed = "b";
		if (Input.GetKeyDown(KeyCode.C))
			keyPressed = "c";
		if (Input.GetKeyDown(KeyCode.D))
			keyPressed = "d";
		if (Input.GetKeyDown(KeyCode.E))
			keyPressed = "e";
		if (Input.GetKeyDown(KeyCode.F))
			keyPressed = "f";
		if (Input.GetKeyDown(KeyCode.G))
			keyPressed = "g";
		if (Input.GetKeyDown(KeyCode.H))
			keyPressed = "h";
		if (Input.GetKeyDown(KeyCode.I))
			keyPressed = "i";
		if (Input.GetKeyDown(KeyCode.J))
			keyPressed = "j";
		if (Input.GetKeyDown(KeyCode.K))
			keyPressed = "k";
		if (Input.GetKeyDown(KeyCode.L))
			keyPressed = "l";
		if (Input.GetKeyDown(KeyCode.M))
			keyPressed = "m";
		if (Input.GetKeyDown(KeyCode.N))
			keyPressed = "n";
		if (Input.GetKeyDown(KeyCode.O))
			keyPressed = "o";
		if (Input.GetKeyDown(KeyCode.P))
			keyPressed = "p";
		if (Input.GetKeyDown(KeyCode.Q))
			keyPressed = "q";
		if (Input.GetKeyDown(KeyCode.R))
			keyPressed = "r";
		if (Input.GetKeyDown(KeyCode.S))
			keyPressed = "s";
		if (Input.GetKeyDown(KeyCode.T))
			keyPressed = "t";
		if (Input.GetKeyDown(KeyCode.U))
			keyPressed = "u";
		if (Input.GetKeyDown(KeyCode.V))
			keyPressed = "v";
		if (Input.GetKeyDown(KeyCode.W))
			keyPressed = "w";
		if (Input.GetKeyDown(KeyCode.X))
			keyPressed = "x";
		if (Input.GetKeyDown(KeyCode.Y))
			keyPressed = "y";
		if (Input.GetKeyDown(KeyCode.Z))
			keyPressed = "z";
		if (keyPressed !=null)
		{
            bool failed = true;
			// Debug.Log(keyPressed+" "+notes[i].FindChild("Text"),GetComponent<Text>.text;
			for(int i = 0;i<Mathf.Min(notes.Count, 10);i++)
				if (Mathf.Abs(notes[i].transform.localPosition.x) < 70&&notes[i].FindChild("Text").GetComponent<Text>().text.Equals(keyPressed))
			{
                    //detectorbar.color = Color.green;
                   
				Transform tmp = notes[i];
				notes.RemoveAt(i);
				Destroy(tmp.gameObject);
                    int r = Random.Range(0, 5);
                    catnum = r == catnum ? (r + 1) % 5 : r;
                    cat.GetComponent<Image>().sprite = cat_sprites[catnum];
                    failed = false;
                    break;
			}
            if (failed)
                FailNote();
            else
                WinNote();
			/* Debug.Log(notes.First + " " + curNotes.First);
            Debug.Log(notes.First.Value.FindChild("Text").GetComponent<Text>().text.Equals("" + keyPressed));
            if (lastNote == 't' && timeout > 0)//curNotes.First != null && curNotes.First.Value == 't' && notes.First.Value.FindChild("Text").GetComponent<Text>().text.Equals("" + keyPressed)))
                WinNote();
            else if (notes.First.Value.FindChild("Text").GetComponent<Text>().text.Equals("" + keyPressed))
                WinNote();
            else
                FailNote();
            // else
            //  FailNote();
            /*if (lastNote == 'z' && (curNotes.First == null || numTick % 8 < 6 || curNotes.First.Value == 'z'))
            {
                FailNote();
            }
            else if (notes.First.Value.GetComponent<Text>().text.Equals("" + keyPressed))
            {
                FailNote();
            }*/
			//Debug.Log(keyPressed);*/
		}
		
		
		
	}
	
	/*public void readFile(string filename)
    {
        StreamReader file = new StreamReader(filename);
        while (true)
        {

            string next = file.ReadLine();
            if (next == null)
                break;
            int tmp;
            int.TryParse(next, out tmp);
            ticksTillspawn.AddLast(tmp/25f);

            
        }
        ticksTillspawn.First.Value -= 1600 / MasterControl.master.measureSpeed;

    }*/
	public void readFile(string filename)
	{
        string file = "Z | tzzttztz | tzzttztz | tzzttztz | tzzttztz | tzzttztz | tzzttztz | tzzttztz | tzzttztz | tzzttztz | tzzttztz | tzzttztz | 19.2tzzttztz | tzzttztz | tzzttztz | tzzttztz | tztttzzz | Z | Z | 30.4tztztttz | tztztztt | 33.4tzztzztt | tzztttzt | tztztttt | tzttzttt | tztztttt | tztttztz | tztztttt | tzttzttt | tztztttt | tztttztz | tztztttt | tztzttzt | tztztztt | tztttztt | ttzzzzzz | tzttttzt | tztztztt | ttztttzt | 102.3tztztztz | tzttttzt | tztttztt | tztttztt | ttztttzt | tzttttzt | tztttztt | tzttttzt | tzttttzt | tztttztt | tztttztt | 121.5 tzttttzt | tzttttzt | tztttztt | tztttztt | tzttttzt | tzttttzt | tztttztt | tztttztt | 1.34.5tzttttzt | tzttzttt | tttttttt | tzttztzt | tzttztzt | tztzttzt | tttttttt | tztzttzt | tzttztzt | tzztzttt | tttttttt | tztttztz | tztzttzt | tztztttz | tttttttt | tzttztzz | tztttztz | 2tztztztt | tttttttt | tzttztzz | tztztztt | tzttztzt | tttttttt | tztztztt | tztztztt | tttttttt | 2.14Z | Z | tzttttzt | tzttttzt | tztttztt | tzttttzt | tzttttzt | tzttttzt | tztttztt | tzttttzt | tzttttzt | tzttttzt | 2.33.5tztttztt | tzttttzt | tzttttzt | tzttttzt | tztttztt | tzttttzt | tztztztz | tztztztz | tztztztz | tztztztz | tztztztz | tztztztz | tztztztz | tztztztz | tztztztz | tztztztz | tztztztz | tztztztz | tztztztz | tztztztz | tztztztz | tztztztz | tztztztz";
        char[] line = file.ToCharArray();
		foreach (char c in line)
		{
			if (c == 'Z')
			{
				spawnList.AddLast('z');
				spawnList.AddLast('z');
				spawnList.AddLast('z');
				spawnList.AddLast('z');
				spawnList.AddLast('z');
				spawnList.AddLast('z');
				spawnList.AddLast('z');
				spawnList.AddLast('z');
			}
			if (c == 'z' || c == 't') {
				spawnList.AddLast(c);
			}
			
		}
		for (int i = 0; i < 21; i++)
			spawnList.RemoveFirst();
		//  PopSpawn();
		
		
		
		
	}
	
	
	public void SpawnNode() {
		Transform note2 = (Transform)Instantiate(note, note.position, note.rotation);
		note2.transform.SetParent(Circle);
		note2.SetSiblingIndex(4);
		int r = Random.Range(0, keys.Length-1);
        if (MasterControl.master.difficulty == 3 || lastNote == null)
        {
            note2.transform.FindChild("Text").GetComponent<Text>().text = "" + keys[r];
            lastNote = ""+keys[r];
        }
        else
        {
            note2.transform.FindChild("Text").GetComponent<Text>().text = lastNote;
            if (MasterControl.master.difficulty == 2)
                lastNote = null;
        }
        notes.Add(note2);
		
	}
	
	public void FailNote()
	{
        astro.GetComponent<Image>().sprite = astro_sprites[4];
        score -= 50 * ((int)(multiplyer));
        multiplyer = 1;
	}
	public void WinNote()
	{
        score += (2+MasterControl.master.difficulty)*10 * ((int)(multiplyer));
        multiplyer += .2f;
	}
	public void Tick() {
		//Debug.Log(notes.Count);
		
		
		
		
		
		
		
		
		
		
		
		//timeout--;
		markColor--;
		if(markColor<=0)
			Circle.GetComponent<Image>().color = Color.black; 
		/*if (timeout <= 0 && lastNote != 'z') {
            FailNote();
        }

        /*List<float> ls = new List<float>();
        
        if (ticksTillspawn.First != null)
        {
            ticksTillspawn.First.Value -= 1;
            if (ticksTillspawn.First.Value <= 0)
            {
                SpawnNode();
                ticksTillspawn.RemoveFirst();

            }
        }*/
		foreach (Transform t in measureBars) {
			t.Translate(new Vector3(-MasterControl.master.measureSpeed, 0, 0));
			if (t.localPosition.x <= -320)
				t.Translate(new Vector3(1600 + 320, 0, 0));
		}
		foreach (Transform t in notes)
		{
			t.Translate(new Vector3(-MasterControl.master.measureSpeed, 0, 0));
		}

		Vector3 trans = goUp ? Vector3.up : Vector3.down;
		astro.Translate (trans);
		cat.Translate (-trans);
		astro.Rotate(Vector3.forward);
		cat.Rotate(Vector3.back);
		space.Translate (Vector3.down*20);
		space2.Translate (Vector3.down*20);
		if (space.localPosition.y < -1250)
			space.Translate(new Vector3(0, 3200, 0));
		if (space2.localPosition.y < -1250)
			space2.Translate(new Vector3(0, 3200, 0));
		
		while (notes.Count>0&&notes[0].localPosition.x <= -300)
		{
			Transform tmp = notes[0];
			notes.RemoveAt(0);
			Destroy(tmp.gameObject);
            FailNote();
			
		}
		numTick = (numTick + 1) % (16 * 4);
		if (numTick % 8 == 0)
		{
			//Debug.Log(spawnList.First.Value);
			if (spawnList.First != null)
			{
                if (spawnList.First.Value == 't')
                {

                    SpawnNode();
                }
                else if(spawnList.First.Value=='z')
                    lastNote = null;
                spawnList.RemoveFirst();
				// PopSpawn();
				
			}
		}
		/*if(numTick%6==0) {   // Debug.Log(keyPressed + " " + notes[i].FindChild("Text"), GetComponent<Text>.text;
            for (int i = 0; i < Mathf.Min(notes.Count, 10); i++)
                if (Mathf.Abs(notes[i].transform.localPosition.x) <= 50) // && notes[i].FindChild("Text").GetComponent<Text>().text.Equals(keyPressed))
                {
                    Debug.Log("Print");
                        detectorbar.color = Color.yellow;
                }
            /*if (curNotes.First != null)
            {
                lastNote = curNotes.First.Value;
                curNotes.RemoveFirst();
            }
            timeout = 8;*/
		//}
		// if (numTick % 10 == 0)
		// detectorbar.color = Color.black;
		if (numTick % 8 == 0) {
			space.GetComponent<Image> ().sprite = space_sprites [Random.Range (0, 1)];
			space2.GetComponent<Image> ().sprite = space_sprites [Random.Range (0, 1)];
		}
		if (numTick % 16 == 0) {
			ring.color = Color.blue;
		}
		if (numTick == 0)
		{
			ring.color = Color.magenta;
		}
		if(numTick%16== 8){
			ring.color=Color.black;
		}
        if (numTick % 16 == 8)
        {
            cat.localScale -= new Vector3(50, 50, 50);
            rainbow.localScale -= new Vector3(0, 10*(numTick / 16+1), 0);
        }
		if (numTick % 16 == 0) {
			cat.localScale += new Vector3(50, 50, 50);
            rainbow.localScale += new Vector3(0, 10*(numTick/16+1), 0);
            goUp = !goUp;
			if (Random.Range (0, 5) == 1)
				astro.GetComponent<Image> ().sprite = astro_sprites [Random.Range (0, 3)];
		}
		if (numTick % 16 == 8) {
			//int r = Random.Range (0, 5);
			//catnum = r == catnum ? (r + 1) % 5 : r;
			//cat.GetComponent<Image> ().sprite = cat_sprites [catnum];
		}
		
	}
}
