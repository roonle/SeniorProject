using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public TMP_Text text;

    [SerializeField]
    public static int score;

    // Update is called once per frame

    void Start()
    {
        text = GetComponent<TMP_Text>();
    }
    void Update()
    {
        text.text = "" + score;
    }

}
