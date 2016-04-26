using UnityEngine;
using System.Collections;

public class FlickeringLight : MonoBehaviour {
	public Light tmp;
	public float radius;
	bool dim = false;
	public float upper;
	public float lower;
	public float rangeModifier;
	public float changePerTick;
	public float tickInterval; 
	// Use this for initialization
	void Start () {
		dim = true;
		rangeModifier = 20.0f;
		changePerTick = 3.0f;
		tickInterval = 0.2f; 
		tmp = this.GetComponent<Light>();
		upper = tmp.range;
		lower = tmp.range - rangeModifier;
		InvokeRepeating("flicker", Random.Range(0.0f, 2.0f),tickInterval);
	}
	
	// Update is called once per frame
	void flicker() {
		radius = tmp.range;
		if(radius < lower){
			dim = false;
		}
		if(radius > upper){
			dim = true;
		}
		if(dim == true){
			radius = radius - changePerTick;
		}else if(dim == false){
			radius = radius + changePerTick;
		}
		tmp.range = radius;
	}
}
