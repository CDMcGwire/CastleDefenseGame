using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCharacter : MonoBehaviour {
	[SerializeField]
	private Gun equippedWeaponPrefab;

	[SerializeField]
	private Transform weaponSlot;

	[SerializeField]
	private Transform armRoot;

	private Gun currentWeapon;

	public void Awake() {
		Debug.Assert(equippedWeaponPrefab != null);
		Debug.Assert(weaponSlot != null);
	}

	public void Start() {
		currentWeapon = Instantiate(equippedWeaponPrefab);
		currentWeapon.transform.SetParent(weaponSlot, false);
	}

	public void Target(InputAction.CallbackContext context) {
		var mousePos = (Vector2)Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
		var outer = currentWeapon.FirePoint;
		var pivot = (Vector2)armRoot.position;
		var outerToPivot = pivot - outer;
		var pivotToMouse = mousePos - pivot;
		var a = pivotToMouse.magnitude;
		var b = outerToPivot.magnitude;
		if (a > b + 0.01f) {
			var A = Vector2.Angle(outerToPivot, currentWeapon.Forward) * Mathf.Deg2Rad;
			var B = Mathf.Asin(b * Mathf.Sin(A) / a);
			var currentC = Vector2.Angle(pivotToMouse, outerToPivot * -1) * Mathf.Deg2Rad;
			var targetC = Mathf.PI - (A + B);
			var deltaC = (currentC - targetC) * Mathf.Rad2Deg;
			armRoot.Rotate(Vector3.forward, deltaC);
		}
		else {
			armRoot.rotation *= Quaternion.FromToRotation(outerToPivot * -1, pivotToMouse);
		}
	}

	public void Fire(InputAction.CallbackContext context) {
		if (context.started) {
			currentWeapon.BeginFire();
		}
		else if (context.canceled || context.performed) {
			currentWeapon.EndFire();
		}
	}
}
