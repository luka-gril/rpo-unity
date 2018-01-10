using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	[SerializeField]
	private GameObject MainMenu;
	[SerializeField]
	private GameObject SettingsMenu;
	[SerializeField]
	private GameObject ChooseMapMenu;

	[SerializeField]
	private Text QualityButtonLabel;
	[SerializeField]
	private Text SoundsButtonLabel;

	private string Quality = "LOW";
	private string Sound = "ON";

	private bool sceneLoading = false;

	public void PlayClicked(){
		ChooseMapMenu.SetActive (true);
		MainMenu.SetActive (false);
	}

	public void SettingsClicked(){
		SettingsMenu.SetActive (true);
		MainMenu.SetActive (false);
	}

	public void BackFromPlay(){
		MainMenu.SetActive (true);
		ChooseMapMenu.SetActive (false);
	}

	public void BackFromSettings(){
		MainMenu.SetActive (true);
		SettingsMenu.SetActive (false);
	}

	public void Quit(){
		Application.Quit ();
	}

	public void ToggleQuality(){
		if (Quality.Equals ("LOW")) {
			Quality = "HIGH";
			QualityButtonLabel.text = "QUALITY: " + Quality;
		}else{
			Quality = "LOW";
			QualityButtonLabel.text = "QUALITY: " + Quality;
		}
	}

	public void ToggleSound(){
		if (Sound.Equals ("ON")) {
			Sound = "OFF";
			SoundsButtonLabel.text = "SOUND: " + Sound;
		}else{
			Sound = "ON";
			SoundsButtonLabel.text = "SOUND: " + Sound;
		}
	}

	public void MapSelection(string sceneName){
		if (!sceneLoading) {
			sceneLoading = true;
			StartCoroutine (LoadScene (sceneName));
		}
	}

	private IEnumerator LoadScene(string sceneName){
		AsyncOperation async = SceneManager.LoadSceneAsync(sceneName); 
		while (!async.isDone) {
			yield return null;
		}
	}


}
