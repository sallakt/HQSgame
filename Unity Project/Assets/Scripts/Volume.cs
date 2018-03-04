using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Volume : MonoBehaviour {

	public Slider mySlider;
	public AudioSource myMusic;

	public void VolumeControl(){
		myMusic.volume = mySlider.value;
	}
}