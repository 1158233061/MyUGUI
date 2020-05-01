using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegisterPanel : BasePanel
{
    private InputField idInput;
    private InputField pwInput;
    private InputField repInput;
    private Button regBtn;
    private Button closeBtn;

    public override void OnInit()
    {
        skinPath = "RegisterPanel";
        layer = UIPanelType.Panel;
    }
    public override void OnShow(params object[] para)
    {
        idInput = skin.transform.Find("IdInput").GetComponent<InputField>();
        pwInput = skin.transform.Find("PwInput").GetComponent<InputField>();
        repInput = skin.transform.Find("RepInput").GetComponent<InputField>();
        regBtn = skin.transform.Find("RegisterBtn").GetComponent<Button>();
        closeBtn = skin.transform.Find("CloseBtn").GetComponent<Button>();

        canvasGroup = skin.transform.GetComponent<CanvasGroup>();

        regBtn.onClick.AddListener(OnRegClick);
        closeBtn.onClick.AddListener(OnCloseClick);
    }

    public override void OnClose()
    {
        base.OnClose();
    }
    public void OnRegClick()
    {
        if (idInput.text == "" || pwInput.text == "")
        {
            PanelManager.PushPanel<TipPanel>("用户名和密码不能为空");
            return;
        }
        if (pwInput.text != repInput.text)
        {
            PanelManager.PushPanel<TipPanel>("两次输入的密码不同");
            return;
        }
    }
    public void OnCloseClick()
    {
        PanelManager.PopPanel();
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
