using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	[SerializeField]
	private GameObject BotPrefab; // model za bote

	public static bool GAME_RUNNING; // spremenljivka ki pove ali je igra v teku.    Statična zato ker bomo dostopali tudi iz ostalih skript (premikanje igralca, streljanje, ...)
	private float playingTime = 0f;  // štopanje igralnega časa  - default vrednost ob zagonu igre je 0

	private float BotSpawnTime = 5f;  // vsake 4 sekunde se bo spawnal novi bot
	private float BotTimer = 0f;  // timer, da vidimo kdaj minejo 4 sekunde 
	private float SpawnedBots = 0;  // beležimo koliko botov je bilo spawnanih
	private int BotsNumber = 3;

	private GameObject[] mBotSpawnPoints;  // array točk v mapi kjer se lahko spawnajo boti

	[SerializeField]
	private Text FpsText;
	[SerializeField]
	private Text ScoreText;

	[SerializeField]
	private GameObject GameCanvas;
	[SerializeField]
	private GameObject GameOverCanvas;
	[SerializeField]
	private Text StateText;
	[SerializeField]
	private Text ResultText;

	void OnEnable(){ 
		GameOverCanvas.SetActive (false);
		mBotSpawnPoints = GameObject.FindGameObjectsWithTag ("ZombieSpawnPoint"); 
		GAME_RUNNING = true; 
	}

	void Update(){
		playingTime += Time.deltaTime; 
		ScoreText.text = playingTime.ToString ();
		FpsText.text = (1.0f / Time.deltaTime).ToString ();
		BotTimer += Time.deltaTime; 

		if ((BotTimer >= BotSpawnTime) && SpawnedBots < BotsNumber) { 
			SpawnBot ();  
		}
		CheckWin ();
	}

	private void SpawnBot(){
		int randomPosition = Random.Range (0, mBotSpawnPoints.Length);  
		Instantiate (BotPrefab, mBotSpawnPoints [randomPosition].transform.position, Quaternion.identity); 
		SpawnedBots++; 
		BotTimer = 0f; 
	}

	public void CheckWin(){ 
		bool victoryCondition1 = GameObject.FindGameObjectsWithTag ("Zombie").Length == 0; 
		bool victoryCondition2 = SpawnedBots == BotsNumber; 
		if (victoryCondition1 && victoryCondition2) {
			GameWon (); 
		}
	}

	public void PlayerKilled(){ 
		GameOver (); 
	}

	private void GameOver(){
		GAME_RUNNING = false;  // igra je nehala teči
		GameCanvas.SetActive(false);
		GameOverCanvas.SetActive (true);
		StateText.text = "YOU LOST!";
		ResultText.text = string.Empty;
		StartCoroutine (BackToMenu ()); // začnemo funkcijo za izhod nazaj v meni 
	}

	private void GameWon(){
		GAME_RUNNING = false;  // igra je nehala teči
		GameCanvas.SetActive(false);
		GameOverCanvas.SetActive (true);
		StateText.text = "YOU WON!";
		ResultText.text = "Result: " + playingTime.ToString();
		WriteResultToTextFile (); // Metoda kjer bomo zapisali rezultat v neko datoteko (še jo moramo naredit)
		StartCoroutine (BackToMenu ()); // začnemo funkcijo za izhod nazaj v meni
	}

	private void WriteResultToTextFile(){
		// ZA NAREDIT ŠE: Zapisat rezultat (playingTime) v neko tekstovno datoteko, da jo bo potem brala naša aplikacija 
	}

	private IEnumerator BackToMenu(){
		yield return new WaitForSeconds (4); // počakamo 3 sekunde, da igralcu kaže Game Win ali Game Lost text 3 sekunde preden gre nazaj v meni
		AsyncOperation async = SceneManager.LoadSceneAsync("Menu"); // naložimo meni in zapustimo trenutno sceno. Konec igre 
		while (!async.isDone) {
			yield return null;
		}
	}

}
