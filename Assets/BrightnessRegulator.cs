using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrightnessRegulator : MonoBehaviour {

    Material myMaterial;

    private float minEmission = 0.3f;

    private float magEmission = 2.0f;

    private int degree = 0;

    private int speed = 10;

    Color defaultcolor = Color.white;

	// Use this for initialization
	void Start ()
    {
		if(tag == "SmallStarTag")
        {
            this.defaultcolor = Color.white;
        }

        else if (tag == "LargeStarTag")
        {
            this.defaultcolor = Color.yellow;
        }

        else if (tag == "SmallCloudTag" || tag == "LargeCloudTag")
        {
            this.defaultcolor = Color.cyan;
        }

        this.myMaterial = GetComponent<Renderer>().material;

        myMaterial.SetColor("_EmissionColor", this.defaultcolor*minEmission);

    }
	
	// Update is called once per frame
	void Update ()
    {
		if(this.degree >= 0)
        {
            Color emissionColor = this.defaultcolor * (this.minEmission + Mathf.Sin(this.degree * Mathf.Deg2Rad) * this.magEmission);

            myMaterial.SetColor("_EmissionColor", emissionColor);

            this.degree -= this.speed;
         }
	}

    void OnCollisionEnter(Collision other)
    {
        this.degree = 180;
    }
}
