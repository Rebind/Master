using UnityEngine;
using System.Collections;

public class delayPlay : MonoBehaviour
{


    public float delay;


    // Use this for initialization
    void Start()
    {
        gameObject.GetComponent<AudioSource>().PlayDelayed(delay);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
