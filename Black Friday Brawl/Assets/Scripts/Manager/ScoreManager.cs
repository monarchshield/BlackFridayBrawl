using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour 
{
    /// <Score Values>
    /// The current team score values
    /// </summary>
    private int _RedScore;
    private int _BlueScore;
    private int _GreenScore;
    private int _YellowScore;

    /// <Score Text Objects>
    /// This just holds the score text objects within the scene
    /// </summary>
    private TextMesh _RedScoreText;
    private TextMesh _BlueScoreText;
    private TextMesh _GreenScoreText;
    private TextMesh _YellowScoreText;

    /// <Time Keeper Variables>
    /// This contains how long a match will last for
    /// and render the score to the text object
    /// </summary>
    public float _MatchDuration;
    private TextMesh _TimeText;

	// Use this for initialization
	void Start () 
    {
        _RedScoreText = GameObject.Find("RedScore").GetComponent<TextMesh>();
        _BlueScoreText = GameObject.Find("BlueScore").GetComponent<TextMesh>();
        _GreenScoreText = GameObject.Find("GreenScore").GetComponent<TextMesh>();
        _YellowScoreText = GameObject.Find("YellowScore").GetComponent<TextMesh>();
        _TimeText = GameObject.Find("TimeValue").GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        UpdateScoreUI();
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
            {
                _RedScore += val;
                _RedScoreText.text = _RedScore.ToString();
            }
            break;

            case TeamColour.BLUE:
            {
                _BlueScore += val;
                _BlueScoreText.text = _BlueScore.ToString();
            }
            break;

            case TeamColour.GREEN:
            {
                _GreenScore += val;
                _GreenScoreText.text = _GreenScoreText.ToString();
            }
            break;

            case TeamColour.YELLOW:
            {
                _YellowScore += val;
                _YellowScoreText.text = _YellowScoreText.ToString();
            }
            break;

            default:
                break;
        }
    }
    
    private void UpdateScoreUI()
    {
        //Updates the score UI within the scene
        _MatchDuration -= Time.deltaTime;

        int Timer = (int)_MatchDuration;

        if (_MatchDuration < 0)
            Application.LoadLevel(0);

        _TimeText.text = Timer.ToString();
    }

}
