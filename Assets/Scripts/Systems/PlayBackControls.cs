using UnityEngine;
using UnityEngine.UI;

public class PlayBackControls : MonoBehaviour {
	public Button pause;
	public Button play;
	public Button fastForward;

	[Space(10)]
	[Range(1.0f, 64.0f)]
	public float fastForwardSpeed = 4.0f;

	private Button active;

	public void Start() {
		pause.onClick.AddListener(() => Pause());
		play.onClick.AddListener(() => Play());
		fastForward.onClick.AddListener(() => FastForward());

		SetActive(play);
	}

	private void SetActive(Button button) {
		if (active != null) active.interactable = true;
		active = button;
		if (active != null) active.interactable = false;
	}

	public void Pause() {
		Time.timeScale = 0;
		SetActive(pause);
	}
	public void Play() {
		Time.timeScale = 1;
		SetActive(play);
	}
	public void FastForward() {
		Time.timeScale = fastForwardSpeed;
		SetActive(fastForward);
	}
}
