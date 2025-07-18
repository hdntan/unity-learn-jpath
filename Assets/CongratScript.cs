using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CongratScript : MonoBehaviour
{
    public TextMesh text;
    public ParticleSystem sparksParticles;

    [SerializeField]private List<string> textToDisplay;
    
    [SerializeField]private float rotatingSpeed;
    [SerializeField] private float timeToNextText;

    [SerializeField]private int currentText;
    
    // Start is called before the first frame update
    void Start()
    {
        this.text = GetComponent<TextMesh>();
        this.sparksParticles = GameObject.Find("SparksEffect").GetComponent<ParticleSystem>();
        timeToNextText = 0.0f;
        currentText = 0;
        
        rotatingSpeed = 1.0f;

        textToDisplay.Add("Congratulation");
        textToDisplay.Add("All Errors Fixed");

        text.text = textToDisplay[0];
        
        sparksParticles.Play();
    }

    // Update is called once per frame
    void Update()
    {
        timeToNextText += Time.deltaTime;

        if (timeToNextText > 1.5f)
        {
            timeToNextText = 0.0f;

            currentText++;
            if (currentText >= textToDisplay.Count)
            {
                currentText = 0;


                text.text = textToDisplay[currentText];
            }
        }
    }
}