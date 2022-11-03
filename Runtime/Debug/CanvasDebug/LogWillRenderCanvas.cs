using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Reflection;

namespace Sxer.Tool.DebugTool
{
    /// <summary>
    /// 输出WillRenderCanvases相关
    /// </summary>
    /// 将此脚本挂载到物体上可以查看log具体是哪个元素引起了布局/图像重建
    public class LogWillRenderCanvas : MonoBehaviour
    {
        IList<ICanvasElement> m_LayoutRebuildQueue;
        IList<ICanvasElement> m_GraphicRebuildQueue;

        private void Awake()
        {
            Type type = typeof(CanvasUpdateRegistry);
            FieldInfo fi_layout = type.GetField("m_LayoutRebuildQueue", BindingFlags.Instance | BindingFlags.NonPublic);
            m_LayoutRebuildQueue = (IList<ICanvasElement>)fi_layout.GetValue(CanvasUpdateRegistry.instance);
            FieldInfo fi_graphic = type.GetField("m_GraphicRebuildQueue", BindingFlags.Instance | BindingFlags.NonPublic);
            m_GraphicRebuildQueue = (IList<ICanvasElement>)fi_graphic.GetValue(CanvasUpdateRegistry.instance);
        }

        private void Update()
        {
            Log();
        }

        void Log()
        {
            for (int i = 0; i < m_LayoutRebuildQueue.Count; i++)
            {
                if (m_LayoutRebuildQueue[i] != null)
                {
                    Debug.Log($"{m_LayoutRebuildQueue[i].transform.name}引起了布局重建");
                }
            }
            for (int i = 0; i < m_GraphicRebuildQueue.Count; i++)
            {
                if (m_GraphicRebuildQueue[i] != null)
                {
                    Debug.Log($"{m_GraphicRebuildQueue[i].transform.name}引起了网格重建");
                }
            }
        }
    }
}
