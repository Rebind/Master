using UnityEngine;
using System.Collections;

public class FadeScenes : MonoBehaviour {

    public Texture2D fadeOutTexture;    
    public float fadeSpeed = 0.8f;     

    private int drawDepth = -1000;      
    private float alpha = 1.0f;         
    private int fadeDir = -1;          

    void OnGUI()
    {
        
        alpha += fadeDir * fadeSpeed * Time.deltaTime;
      
        alpha = Mathf.Clamp01(alpha);

        // set color of our GUI (in this case our texture). All color values remain the same & the Alpha is set to the alpha variable
        GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;                                                              
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);       
    }

    // sets fadeDir to the direction parameter making the scene fade in if -1 and out if 1
    public float BeginFade (int direction)
    {
        fadeDir = direction;
        return (fadeSpeed);
    }

}