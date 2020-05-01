using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager
{
    private static Dictionary<UIPanelType, Transform> layers = new Dictionary<UIPanelType, Transform>();
    public static Dictionary<string, BasePanel> panels = new Dictionary<string, BasePanel>();

    public static Transform root;
    public static Transform canvas;
    /// <summary>
    /// 初始化
    /// </summary>
    public static void Init()
    {
        root = GameObject.Find("Root").transform;
        canvas = root.Find("Canvas");
        Transform panel = canvas.Find("Panel");
        Transform tip = canvas.Find("Tip");
        layers.Add(UIPanelType.Panel, panel);
        layers.Add(UIPanelType.Tip, tip);
    }
    /// <summary>
    /// 打开面板
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="para"></param>
    public static void Open<T>(params object[] para) where T : BasePanel
    {
        string name = typeof(T).ToString();
        if (panels.ContainsKey(name))
            return;
        BasePanel panel = root.gameObject.AddComponent<T>();
        panel.OnInit();
        panel.Init();
        Transform layer = layers[panel.layer];
        panel.skin.transform.SetParent(layer, false);
        panels.Add(name, panel);
        panel.OnShow(para);
    }
    /// <summary>
    /// 关闭界面
    /// </summary>
    /// <param name="name">界面名称</param>
    public static void Close(string name)
    {
        if (!panels.ContainsKey(name))
            return;
        BasePanel panel = panels[name];
        panel.OnClose();
        panels.Remove(name);
        GameObject.Destroy(panel.skin);
        Component.Destroy(panel);
    }
    
}
