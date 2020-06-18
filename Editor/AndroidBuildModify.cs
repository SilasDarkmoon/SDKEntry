using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Capstones.UnityEngineEx;

namespace Capstones.UnityEditorEx
{ 
    public static class AndroidBuildModify
    {
        private class AndroidPreBuild : UnityEditor.Build.IPreprocessBuild, UnityEditor.Build.IPostprocessBuild
        {
            public int callbackOrder { get { return 0; } }

            public void OnPreprocessBuild(BuildTarget target, string path)
            {
                if (target == BuildTarget.Android)
                {
                    string amani = "EditorOutput/Intermediate/AndroidManifest.xml";
                    //if (!PlatDependant.IsFileExist(amani))
                    {
                        var omani = EditorApplication.applicationContentsPath + "/PlaybackEngines/AndroidPlayer/Apk/AndroidManifest.xml";
                        if (!PlatDependant.IsFileExist(omani))
                        {
                            omani = EditorApplication.applicationContentsPath + "/PlaybackEngines/AndroidPlayer/Apk/UnityManifest.xml";
                            if (!PlatDependant.IsFileExist(omani))
                            {
                                Debug.LogError("Cannot find original AndroidManifest.xml");
                                return;
                            }
                        }

                        PlatDependant.CopyFile(omani, amani);
                    }

                    try
                    {
                        var doc = System.Xml.Linq.XDocument.Load(amani);
                        var appnode = doc.Element("manifest").Element("application").Element("activity");
                        appnode.Attribute(System.Xml.Linq.XName.Get("name", "http://schemas.android.com/apk/res/android")).SetValue("cn.capstones.anative.android.capsactivity.CapsActivity");
                        doc.Save(amani);
                        PlatDependant.CopyFile(amani, "Assets/Plugins/Android/AndroidManifest.xml");
                    }
                    catch (Exception e)
                    {
                        Debug.LogException(e);
                    }
                }
            }

            public void OnPostprocessBuild(BuildTarget target, string path)
            {
                PlatDependant.DeleteFile("EditorOutput/Intermediate/AndroidManifest.xml");
            }
        }
    }
}
