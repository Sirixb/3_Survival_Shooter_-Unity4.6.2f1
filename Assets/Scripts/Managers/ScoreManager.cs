using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static int score;// las variables estaticas no pertenecen a ninguna instancia, pertenecen a la clase en si.


    Text text;


    void Awake ()
    {
        text = GetComponent <Text> ();
        score = 0;
    }


    void Update ()
    {
        text.text = "Score: " + score;
		//text.text = "Puntaje: " + score;

    }
}
