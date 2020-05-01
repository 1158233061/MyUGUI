using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePanel : MonoBehaviour
{
    public string skinPath;
    public GameObject skin;
    public UIPanelType layer = UIPanelType.Panel;
    public CanvasGroup canvasGroup;

    public void Init()
    {
        GameObject skinPrefab = ResManager.LoadPrefab(skinPath);

        skin = Instantiate(skinPrefab);
    }

    public virtual void OnInit()
    {

    }
    public virtual void OnShow(params object[] para)
    {

    }
    public virtual void OnPause()
    {

    }
    public virtual void OnResume()
    {

    }
    public virtual void OnClose()
    {

    }
}
