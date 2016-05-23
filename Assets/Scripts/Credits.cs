using UnityEngine;
using System.Collections;


public class Credits : MonoBehaviour
{
	private float offset;
	public float speed = 29.0f;
	public GUIStyle style;
	public Rect viewArea;

	private void Start()
	{
		this.offset = this.viewArea.height;
	}

	private void Update()
	{
		this.offset -= Time.deltaTime * this.speed;
	}

	private void OnGUI()
	{
		GUI.BeginGroup(this.viewArea);

		var position = new Rect(0, this.offset, this.viewArea.width, this.viewArea.height);
		var text = @"Lead Designer/Programmer: Josue Ordonez
		Lead Tester: Edgar Lopez
		Artist Coordinator/Programmer: Khoa Luong
		Lead Producer/Programmer: Alex Girard
		User Test Coordinator/Programmer: Rihui Tan
		Lead Developer/Programmer: Danica Pok
		Artist: Mindy Nguyen and Juan Morales
		Sound Designer: Joshua Ray";

		GUI.Label(position, text, this.style);

		GUI.EndGroup();
	}
}