using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class
SampleHeartRateTrail : MonoBehaviour
{
    public Mesh myMesh;
    private ParticleSystem ps;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(HRCollector.sigmoidIBI);
        //Debug.Log(HRCollector.sigmoidHeartRate);
        //Debug.Log(HRCollector.IBI);
        //Debug.Log(HRCollector.heartRate);
    }

    // Update is called once per frame
    void Update()
    {
        ps = GetComponent<ParticleSystem>();
        var main = ps.main;
        var em = ps.emission;
        var sz = ps.sizeOverLifetime;
        var col = ps.colorOverLifetime;
        var shape = ps.shape;

        main.startSize = (float) HRCollector.sigmoidHeartRate * 3;
        main.startSpeed = (float)HRCollector.sigmoidHeartRate * 5;


        shape.shapeType = ParticleSystemShapeType.Circle;
        shape.radiusMode = ParticleSystemShapeMultiModeValue.BurstSpread; //can alter with biofeedback

        shape.enabled = true;
        //sh.enabled = true;
        em.rateOverTime = (float) HRCollector.sigmoidHeartRate; // can change
        sz.enabled = true;
        col.enabled = true;

        //add bursts later if want
        //radius of shape change with variability

        //dampen (limit velocity over lifetime)

        Gradient grad = new Gradient();
        grad.SetKeys(new GradientColorKey[] { new GradientColorKey(Color.blue, 0f), new GradientColorKey(Color.white, 4f) }, new GradientAlphaKey[] { new GradientAlphaKey(1f, 0.0f), new GradientAlphaKey(0.0f, 1.0f) });

        col.color = grad;
    }
}


