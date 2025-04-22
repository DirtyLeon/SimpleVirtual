using System.Collections;
using System.Collections.Generic;
using DirtyWorks.Simple;
using UnityEngine;
using UnityEngine.UI;

public class SimpleVirtualTest : MonoBehaviour
{
    public InputField ipStart, ipEnd, ipTime;
    public Text txtResult;
    
    private float result = 0;
    private SimpleFloatTween tween;

    private void FixedUpdate()
    {
        txtResult.text = result.ToString();
    }

    public void TestStart()
    {
        tween?.Kill();

        var start = float.Parse(ipStart.text);
        var end = float.Parse(ipEnd.text);
        var time = float.Parse(ipTime.text);

        tween = SimpleVirtual.Float(start, end, time, v => result = v);
    }
}
