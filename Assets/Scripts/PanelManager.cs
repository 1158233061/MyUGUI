using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager
{
    private static Dictionary<UIPanelType, Transform> layers = new Dictionary<UIPanelType, Transform>();
    public static Dictionary<string, BasePanel> panels = new Dictionary<string, BasePanel>();

    private static Stack<BasePanel> panelStack;

    public static Transform root;
    public static Transform canvas;
    /// <summary>
    /// 初始化
    /// </summary>
    public static void Init()
    {
        panelStack = new Stack<BasePanel>();

        root = GameObject.Find("Root").transform;
        canvas = root.Find("Canvas");
        Transform panel = canvas.Find("Panel");
        Transform tip = canvas.Find("Tip");
        layers.Add(UIPanelType.Panel, panel);
        layers.Add(UIPanelType.Tip, tip);
    }

    /// <summary>
    /// 关闭界面
    /// </summary>
    /// <param name="name">界面名称</param>
    private static void Close(string name)
    {
        if (!panels.ContainsKey(name))
            return;
        BasePanel panel = panels[name];
        panel.OnClose();
        panels.Remove(name);
        GameObject.Destroy(panel.skin);
        Component.Destroy(panel);
    }
    /// <summary>
    /// 界面入栈
    /// </summary>
    /// <param name="panelType"></param>
    public static void PushPanel<T>(params object[] para) where T : BasePanel
    {
        if (panelStack.Count > 0)
        {
            BasePanel bp1 = panelStack.Peek();
            bp1.OnPause();
        }

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

        panelStack.Push(panel);
        Debug.Log("stack count: " + panelStack.Count);
    }
    public static void PopPanel()
    {
        if (panelStack.Count <= 0)
            return;

        //关闭当前界面
        BasePanel toppanel = panelStack.Pop();
        string name = toppanel.GetType().ToString();
        Close(name);

        Debug.Log("stack count: " + panelStack.Count);
        //恢复上一个界面
        if (panelStack.Count>0)
        {
            BasePanel panel = panelStack.Peek();
            panel.OnResume();
        }
    }
}
