using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePanel : MonoBehaviour
{
    public string skinPath;
    public GameObject skin;
    public UIPanelType layer = UIPanelType.Panel;
    public CanvasGroup canvasGroup;
    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public void Init()
    {
        GameObject skinPrefab = ResManager.LoadPrefab(skinPath);
        
        skin = Instantiate(skinPrefab);
    }
    public void Close()
    {
        string name = this.GetType().ToString();
        PanelManager.Close(name);
    }
    public virtual void OnInit()
    {

    }
    public virtual void OnShow(params object[] para)
    {

    }
    public virtual void OnClose()
    {

    }
}
