# BrightnessOverride sample
This is a small sample to show the use of [BrightnessOverride](https://docs.microsoft.com/en-us/uwp/api/windows.graphics.display.brightnessoverride) API in a HoloLens UWP app.

You will need to run the Mixed Reality Feature Tool and add in the OpenXR plugin.  Documentation [here](https://docs.microsoft.com/en-us/windows/mixed-reality/develop/unity/mixed-reality-openxr-plugin)

Currently builds with [Unity 2021.3](https://unity3d.com/unity/qa/lts-releases?version=2021.3).  HoloLens needs to have the Windows 10 Spring 2018 update or later.

The following voice commands should work:
- **Off** – set screen brightness to 0
- **On** – set screen brightness to 1
- **Darker** – reduce the screen brightness by 10%
- **Brighter** – increase the screen brightness by 10%
- **Hide** – hide the cube
- **Show** – show the cube
- **Quit** – quit the app
