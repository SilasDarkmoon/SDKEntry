using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.InteropServices;

namespace Capstones.UnityEngineEx.Native
{
    public static class SDKEntry
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        private static void Init()
        {
            PlatDependant.LogError("Android SDK Entry Init!!!!");
            using (AndroidJavaClass jc = new AndroidJavaClass("cn.capstones.anative.android.sdkplugin.SDKPlugin"))
            {
                jc.CallStatic("Init");
            }
        }

#else
        private static void Init() { }
#endif

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void OnUnityStart()
        {
            ResManager.AddInitItem(new ResManager.ActionInitItem(ResManager.LifetimeOrders.CrossEvent + 7, Init, null));
        }
    }
}
