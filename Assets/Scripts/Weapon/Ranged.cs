using UnityEngine;

public class Gun : MonoBehaviour {
	[SerializeField]
	private Transform projectileSpawnPoint;

	[Space(20)]
	[SerializeField]
	private bool semiAuto = true;

	[SerializeField]
	private int magSize = 10;

	[SerializeField]
	private float baseDamage = 1.0f;

	[SerializeField]
	private float critModifier = 3.0f;

	[SerializeField]
	private int currentAmmo = -1;

	[SerializeField]
	private float reloadTime = 3.0f;

	public void Awake() => Debug.Assert(projectileSpawnPoint != null);

	public void Start() {
		if (currentAmmo < 0) currentAmmo = magSize;
	}

	public void Update() => Debug.DrawRay(projectileSpawnPoint.position, projectileSpawnPoint.right, Color.cyan);

	public Vector2 FirePoint => projectileSpawnPoint.position;

	public Vector2 Forward => projectileSpawnPoint.right;

	public void BeginFire() { }

	public void EndFire() { }
}
