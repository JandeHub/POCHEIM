using System.Threading.Tasks;
using UnityEngine;



public class SlowMo : MonoBehaviour
{
    
    
    public static async void Activate(float _factor, float _duration)
    {
        //Debug.Log("Test");
        float t = 0;
        while (t < _duration)
        {
            t += Time.unscaledDeltaTime;
            //Debug.Log("time at slow speed");
            Time.timeScale = _factor;
            Time.fixedDeltaTime = Time.deltaTime * .02f;
            await Task.Yield();
        }
        while (Time.timeScale < 1)
        {
            Time.timeScale += (1 / _duration) * Time.unscaledDeltaTime;
            Time.fixedDeltaTime = Time.deltaTime * .02f;
        }
        //Debug.Log("time at normal");
    }

   
}
