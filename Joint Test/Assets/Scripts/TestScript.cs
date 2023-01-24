using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour {
	/* Number of frames in between color changes in Light. Private variable editable from Unity editor. 
	 * If colorChangeInterval is set to n, the color of Light will wait n frame(s) to change the color. 
	 */
	[SerializeField] private int colorChangeInterval;

	private SpriteRenderer _sr;

	// Variable of byte type data for setting Color32 value
	private byte _red;
	private byte _green;
	private byte _blue;
	private const byte Alpha = 255;

	private int _frameCount; // Variable used to pause color changes in Light for the frame count specified with colorChangeInterval

	private void Awake() {
		_sr = GetComponent<SpriteRenderer>();
		
		_red = 255; 
		_sr.color = new Color32 (_red, _green, _blue, Alpha); // Default color of Light set to RGB(255, 0, 0) 
	}

	private void Update() {
		DoTimedRainbowLightingAnim();
	}

	private void DoTimedRainbowLightingAnim() { // Function for calling AnimateLightingInRainbow() in certain frames
		if (colorChangeInterval == 0) {
			AnimateLightingInRainbow();
		} else if (colorChangeInterval != 0) {
			_frameCount++; // count how many frames it has been since the last change in Light's color

			if (_frameCount != colorChangeInterval) return;
			AnimateLightingInRainbow();
			_frameCount = 0;
		}
	}

	private void AnimateLightingInRainbow() {
		switch (_red) {
			// Function for changing the color of Light 
			// if - else statement that calculates RGB value for the color change 
			case 0 when _green == 0 && _blue == 0:
				_red = 255;
				break;
			case 0 when _green < 255 && _blue == 255:
				_green++;
				break;
			case 0 when _green == 255 && _blue > 0:
				_blue--;
				break;
			case 255 when _green == 0 && _blue < 255:
				_blue++;
				break;
			case 255 when _green > 0 && _blue == 0:
				_green--;
				break;
			case > 0 when _green == 0 && _blue == 255:
				_red--;
				break;
			case < 255 when _green == 255 && _blue == 0:
				_red++;
				break;
		}

		_sr.color = new Color32(_red, _green, _blue, Alpha); // Update the RGB value of the color of Light with the RGB value calculated from the above if-else statements
	}
}