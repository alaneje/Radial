using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class UIBehaviour : MonoBehaviour {
    public characterController Character;
    public Slider PlayerHealthBar;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        PlayerHealthBar.value = Character.health;
	}
}
