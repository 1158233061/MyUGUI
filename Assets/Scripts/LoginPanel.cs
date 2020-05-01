using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginPanel : BasePanel
{
    private InputField idInput;
    private InputField pwInput;
    private Button loginBtn;
    private Button regBtn;

    public override void OnInit()
    {
        skinPath = "LoginPanel";
        layer = UIPanelType.Panel;
    }
    public override void OnShow(params object[] para)
    {
        idInput = skin.transform.Find("IdInput").GetComponent<InputField>();
        pwInput = skin.transform.Find("PwInput").GetComponent<InputField>();
        loginBtn = skin.transform.Find("LoginBtn").GetComponent<Button>();
        regBtn = skin.transform.Find("RegisterBtn").GetComponent<Button>();

        canvasGroup = skin.transform.GetComponent<CanvasGroup>();

        loginBtn.onClick.AddListener(OnLoginClick);
        regBtn.onClick.AddListener(OnRegClick);
    }

    public void OnLoginClick()
    {
        if (idInput.text == "" || pwInput.text == "")
        {
            PanelManager.PushPanel<TipPanel>("用户名和密码不能为空");
            return;
        }
    }
    public void OnRegClick()
    {
        PanelManager.PushPanel<RegisterPanel>();
    }

    public override void OnClose()
    {
        base.OnClose();
    }
    public override void OnPause()
    {
        canvasGroup.blocksRaycasts = false;
    }
    public override void OnResume()
    {
        canvasGroup.blocksRaycasts = true;
    }
}
