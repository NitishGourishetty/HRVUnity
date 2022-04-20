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
        

        //var trails = ps.trails;
        //trails.enabled = true;
        //trails.ratio = 0.5f;
        //shape.angle = 45;

        //all biofeedback stuff will use shape!
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
        //shape.shapeType = ParticleSystemShapeType.Circle;
        //shape.radiusMode = ParticleSystemShapeMultiModeValue.BurstSpread; //can alter with biofeedback
        //var sh = ps.shape;
        //add distance shape stuff
        //em.enabled = true;
        shape.enabled = true;
        //sh.enabled = true;
        em.rateOverTime = (float) HRCollector.sigmoidHeartRate; // can change
        sz.enabled = true;
        col.enabled = true;
        //everytime a beat happens.. #will change
        //em.SetBursts(
        //    new ParticleSystem.Burst[]{
        //        new ParticleSystem.Burst(1.0f, (float) HRCollector.sigmoidHeartRate * 10),
        //        //new ParticleSystem.Burst(7.0f, (float) HRCollector.sigmoidIBI * 10)
        //    });

        //sh.shapeType = ParticleSystemShapeType.Mesh;
        //sh.mesh = myMesh;

        //AnimationCurve curve = new AnimationCurve();
        //curve.AddKey(0.0f, 0.1f);
        //curve.AddKey(0.75f, 1.0f);

        //sz.size = new ParticleSystem.MinMaxCurve((float)HRCollector.sigmoidHeartRate, curve);


        Gradient grad = new Gradient();
        grad.SetKeys(new GradientColorKey[] { new GradientColorKey(Color.red, 0f), new GradientColorKey(Color.yellow, 1f) }, new GradientAlphaKey[] { new GradientAlphaKey(1f, 0.0f), new GradientAlphaKey(0.0f, 1.0f) });

        col.color = grad;
       
        


    }
}
