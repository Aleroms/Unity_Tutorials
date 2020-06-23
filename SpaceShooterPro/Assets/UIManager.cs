using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	[SerializeField]
	private Text _scoretext;

    // Start is called before the first frame update
    void Start()
    {
		_scoretext.text = "Score: " + 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	public void SetScore(int score)
	{
		_scoretext.text = "Score: " + score;
	}
}
