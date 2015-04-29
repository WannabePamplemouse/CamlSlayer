using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerEnergy : MonoBehaviour {

    public Slider EnergySlider;
	public int stratingEnergy = 100;
	public int currentEnergy;
	float timer;

	// Use this for initialization
	void Awake () {
		currentEnergy = stratingEnergy;
		timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer > 1 && currentEnergy < 100) {
			timer = 0;
            UseEnergy(-10);
		}
	}

	public void UseEnergy(int amount)
	{
		currentEnergy -= amount;
		if (currentEnergy < 0) {
			currentEnergy = 0;
		}
        else if (currentEnergy > 100)
        {
            currentEnergy = 100;
        }
		EnergySlider.value = currentEnergy;
	}
}
