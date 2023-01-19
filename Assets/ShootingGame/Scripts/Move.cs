using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public AnimationCurve[] curve = new AnimationCurve[4];
    public float t = 0;
    private float[] max = new float[4] { 0.5f, 0.5f, 0.25f, 0.25f };
    private int step = 0;

    private Rigidbody rigidbody;
    private Quaternion startRot;
    public Vector3[] endRot = new Vector3[4];

    // Start is called before the first frame update
    void Start()
    {
        endRot[0] = new Vector3(0, 30, 0);
        endRot[1] = new Vector3(0, -30, 0);
        endRot[2] = new Vector3(0, 181, 0);
        endRot[3] = new Vector3(0, 170, 0);

        rigidbody = GetComponent<Rigidbody>();
        startRot = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        rigidbody.velocity = transform.forward * 4f;

        if (step < 4 && t <= max[step])
        {
            transform.localRotation = Quaternion.Slerp(startRot, Quaternion.Euler(endRot[step]), curve[step].Evaluate(t / max[step]));
        }
        else
        {
            ++step;
            t = 0;
        }
    }
}
