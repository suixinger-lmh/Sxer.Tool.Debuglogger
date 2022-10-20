using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sxer.Tool
{
    public static class DebugLogger
    {
        public static void DebugLog_(string str)
        {
#if UNITY_EDITOR
            Debug.Log(str);
#endif
        }


        public static void DebugLog_Warning(string str)
        {
#if UNITY_EDITOR
            Debug.Log(string.Format("<color=yellow>{0}</color>", str));
#endif
        }

        public static void DebugLog_Error(string str)
        {
#if UNITY_EDITOR
            Debug.Log(string.Format("<color=red>{0}</color>", str));
#endif
        }

    }
}

