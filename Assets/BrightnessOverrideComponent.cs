using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if NETFX_CORE
using Windows.Graphics.Display;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
#endif

public class BrightnessOverrideComponent : MonoBehaviour
{
#if NETFX_CORE
    private BrightnessOverride bo;
    private void InitBo()
    {
        UnityEngine.WSA.Application.InvokeOnUIThread(() =>
        {
            this.bo = BrightnessOverride.GetForCurrentView();
        }, true);
    }

    public float Brightness
    {
        get
        {
            if(this.bo != null) return (float)this.bo.BrightnessLevel;
            return 0f;
        }

        set
        {
            if(this.bo != null)
            {
                double newBrightness = (double)value;

                if (newBrightness > 1.0)
                {
                    newBrightness = 1.0;
                }
                if (newBrightness < 0.0)
                {
                    newBrightness = 0.0;
                }

                bo.SetBrightnessLevel(newBrightness, DisplayBrightnessOverrideOptions.None);
            
                bo.StartOverride();
            }
        }
    }

    private void DisableBo()
    {
        if(this.bo != null)
        {
            this.bo.StopOverride();
        }
    }

#else
    private void InitBo() { }
    public float Brightness { get; set; }
    private void DisableBo() { }
#endif


    // Use this for initialization
    void Start ()
    {
        this.InitBo();
        this.Brightness = 1.0f;
    }

    public void OnDisable()
    {
        this.DisableBo();
    }

}
