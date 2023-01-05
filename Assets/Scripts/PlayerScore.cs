using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] public int m_score = 0;
    public TMP_Text m_text;

    private void Update()
    {
        m_text.text = "Score : " + m_score;
    }
}
