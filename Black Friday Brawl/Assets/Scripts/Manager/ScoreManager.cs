using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour 
{
    private int _RedScore;
    private int _BlueScore;
    private int _GreenScore;
    private int _YellowScore;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public void YellowAddScore(int val) { _YellowScore += val; }
    public void GreenAddScore(int val)  { _GreenScore += val; }
    public void BlueAddScore(int val) { _BlueScore += val; }
    public void RedAddScore(int val) { _RedScore += val; }
   
    public void AddScore(TeamColour colour, int val)
    {
        switch (colour)
        {
            case TeamColour.RED:
                _RedScore += val;
                break;
            case TeamColour.BLUE:
                _BlueScore += val;
                break;
            case TeamColour.GREEN:
                _GreenScore += val;
                break;
            case TeamColour.YELLOW:
                _YellowScore += val;
                break;
            default:
                break;
        }
    }


}
