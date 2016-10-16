using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public AudioClip crack;
	public Sprite[] hitSprites;
	public static int numberOfBricks = 0;
	
	private int timesHit;
	private LevelManager levelManager;
	private bool isbreak;
	// Use this for initialization
	void Start () {
		isbreak = (this.tag == "Breakable");
		
		if (isbreak) {
			numberOfBricks++;
			print (numberOfBricks);
		}
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void OnCollisionEnter2D (Collision2D collision) {
		//AudioSource.PlayClipAtPoint (crack, transform.position);
		if (isbreak) {
			HandleHits();	
		}
	}
	
	void HandleHits() {
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		if (timesHit >= maxHits) {
			numberOfBricks--;
			levelManager.BrickDestroyed();
			Destroy(gameObject);
		} else {
			LoadSprites();
		}
	}
	void SimulateWin() {
		levelManager.LoadNextLevel();
	}
	
	void LoadSprites() {
		int spriteIndex = timesHit - 1;
		if (hitSprites[spriteIndex]) {
		this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
	}
}
