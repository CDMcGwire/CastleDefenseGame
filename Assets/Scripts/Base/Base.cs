using UnityEngine;

[RequireComponent(typeof(Health))]
public class Base : MonoBehaviour {
	private static Base instance;
	private static Base Instance {
		get {
			if (instance == null) instance = FindObjectOfType<Base>();
			return instance;
		}
	}

	public SpriteRenderer spriteRenderer;
	public Sprite aliveSprite;
	public Sprite deadSprite;
	public new ParticleSystem particleSystem;
	public float destroySwapDelay = 0.5f;

	private Health health;

	private void OnValidate() => health = GetComponent<Health>();

	private void Awake() {
		if (instance != null) return;
		instance = this;
	}

	public void DestroyBase() {
		Invoke("DestroySprite", destroySwapDelay);
		particleSystem.Play();
	}
	public void DestroySprite() => spriteRenderer.sprite = deadSprite;

	public static void Damage(int amount) => Instance.health.Damage(amount);
}
