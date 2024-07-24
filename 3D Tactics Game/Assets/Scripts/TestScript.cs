using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public TMP_Text m_Text;
    public TestScriptableObject g; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_Text.text = g.test?"True":"False";
    }
}
