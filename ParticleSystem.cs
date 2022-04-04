using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartRateTrail : MonoBehaviour
{
    public Mesh myMesh;
    private ParticleSystem ps;
    
    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        var main = ps.main;
        var em = ps.emission;
        var sz = ps.sizeOverLifetime;
        var col = ps.colorOverLifetime;
        

        //var sh = ps.shape;

        em.enabled = true;
        //sh.enabled = true;
        em.rateOverTime = 20.0f;
        sz.enabled = true;
        col.enabled = true;
        //everytime a beat happens..
        em.SetBursts(
            new ParticleSystem.Burst[]{
                new ParticleSystem.Burst(2.0f, 100),
                new ParticleSystem.Burst(4.0f, 100)
            });

        //sh.shapeType = ParticleSystemShapeType.Mesh;
        //sh.mesh = myMesh;

        AnimationCurve curve = new AnimationCurve();
        curve.AddKey(0.0f, 0.1f);
        curve.AddKey(0.75f, 1.0f);

        sz.size = new ParticleSystem.MinMaxCurve(1.5f, curve);


        Gradient grad = new Gradient();
        grad.SetKeys(new GradientColorKey[] { new GradientColorKey(Color.red, 0f), new GradientColorKey(Color.yellow, 1f) }, new GradientAlphaKey[] { new GradientAlphaKey(1f, 0.0f), new GradientAlphaKey(0.0f, 1.0f) });

        col.color = grad;

        //var trails = ps.trails;
        //trails.enabled = true;
        //trails.ratio = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        ps = GetComponent<ParticleSystem>();
        var main = ps.main;
        main.startSize = Random.Range(1, 2); //random start size


    }
}
