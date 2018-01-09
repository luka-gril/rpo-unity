using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuFunckije : MonoBehaviour {

	[SerializeField]
	private Toggle SoundToggle;

	public void NewGame(){
		// Podmeni za izbiro mape (3 gumbi, vsak za svojo mapo)
	}

	public void QuitGame(){
		Application.Quit ();
	}

	public void Options(){
		// Naredi/Odpri podmeni za nastavitve (zaenkrat toggle gumb za vklop/izklop zvoka)
	}

	public void LoadMap(string mapName){ // gumbi v podmeniju za izbiro mape bodo klicali to metodo (vsak gumb bo imel podan svoj parameter (ime mape))
		StartCoroutine (LoadMapCouroutine (mapName)); // metoda bo zagnala asinhrono nalaganje mape 
	}

	public IEnumerator LoadMapCouroutine(string mapName){ 
		AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(mapName);

		while (!asyncLoad.isDone)
		{
			yield return null;
		}

	}

	public void ToggleSound(){ // Toggle gumb v podmeniju za nastavitve bo klical to metodo
		if (SoundToggle.isOn) { // če je zvok vklopljen, ...
			SoundToggle.isOn = false; // ... ga izklopimo
		} else { // če pa ni ...
			SoundToggle.isOn = true; // ... pa ga vklopimo
		}
	}

}
