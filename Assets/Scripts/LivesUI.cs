using UnityEngine.UI;
using UnityEngine;

public class LivesUI : MonoBehaviour {

    public Text livesText;
	
	// Update is called once per frame
	void Update () {
        livesText.text = PlayerStats.Lives + " LIVES \n" + string.Format("{0:00.00}", PlayerStats.heroHealth) + " hero health" ;
	}
}
