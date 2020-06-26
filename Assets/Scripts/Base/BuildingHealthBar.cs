using UnityEngine;

public class BuildingHealthBar : MonoBehaviour {
	public Health target;
	[Space(10)]
	public Transform healthSlider;
	public SpriteRenderer barGraphic;
	public Vector3 emptyPosition;
	[Space(10)]
	public Color fullColor;
	public Color emptyColor;

	private void OnValidate() => barGraphic.color = fullColor;

	public void Set() {
		var fillPercentage = target.CurrentHealth / (float)target.MaxHealth;
		healthSlider.localPosition = Vector3.Lerp(emptyPosition, Vector3.zero, fillPercentage);
		barGraphic.color = HSVColor.Lerp(emptyColor, fullColor, fillPercentage);
	}
}