using UnityEngine;
using System.Collections;

public class CapturePoint : MonoBehaviour 
{
    public GameObject _gameObject;
    ScoreManager _ScoreManager;


	// Use this for initialization
	void Start () 
    {
        _ScoreManager = _gameObject.GetComponent<ScoreManager>();
	}
	

    
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Player player = other.gameObject.GetComponent<Player>();

            if(player._isCarryingObject)
            {
                Iteam iteam = other.gameObject.GetComponent<Iteam>();
                 _ScoreManager.AddScore(player._teamcolour, iteam._scorevalue);
                 player.RemoveIteam();
            }
        }
    }

}
