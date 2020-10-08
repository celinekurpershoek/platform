using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ScriptableObjectHelper
{

    public static T FindScriptableObject<T>(bool searchInResources = true, bool searchInAssetDatabase = false,
        bool createNewIfNotFound = false) where T : ScriptableObject
    {
        var type = typeof(T);
        if (searchInResources)
        {
            var objects = Resources.FindObjectsOfTypeAll<T>();
            if (objects.Length > 0)
            {
                return objects[0];
            }
        }

        if (searchInAssetDatabase)
        {
#if UNITY_EDITOR
            var guids = AssetDatabase.FindAssets($"t:{type.Name}");
            if (guids.Length > 0)
            {
                return AssetDatabase.LoadAssetAtPath<T>(AssetDatabase.GUIDToAssetPath(guids[0]));
            }
#endif
        }

        if (createNewIfNotFound)
        {
            return ScriptableObject.CreateInstance<T>();
        }

        return null;
    }
}
