using UnityEngine;

public class HSVColor {
	public float h;
	public float s;
	public float v;

	public HSVColor(float hue, float saturation, float value) {
		h = Mathf.Clamp(hue, 0, 1);
		s = Mathf.Clamp(saturation, 0, 1);
		v = Mathf.Clamp(value, 0, 1);
	}
	public HSVColor(Color color) => Color.RGBToHSV(color, out h, out s, out v);

	public Color ToRGB() => Color.HSVToRGB(h, s, v);

	public static Color Lerp(Color from, Color to, float t) {
		var fromHSV = new HSVColor(from);
		var toHSV = new HSVColor(to);
		return Lerp(fromHSV, toHSV, t).ToRGB();
	}
	public static HSVColor Lerp(HSVColor from, HSVColor to, float t) {
		return new HSVColor(
			Mathf.Lerp(from.h, to.h, t),
			Mathf.Lerp(from.s, to.s, t),
			Mathf.Lerp(from.v, to.v, t)
		);
	}
}