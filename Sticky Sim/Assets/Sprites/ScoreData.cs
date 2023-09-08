using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreData : MonoBehaviour
{
    public TextMeshProUGUI ScoreDisplay;
    private CubeMovement lvl;
    float score;
    // Start is called before the first frame update
    void Start()
    {
        lvl = FindObjectOfType<CubeMovement>();
        
    }
    // Update is called once per frame
    void Update()
    {
        
      //  Debug.Log(lvl.level);
        score = lvl.level * 2;
        ScoreDisplay.text = score.ToString();
    }
}
