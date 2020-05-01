using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipPanel : BasePanel
{
    private Text text;
    private Button okBtn;

    public override void OnInit()
    {
        skinPath = "TipPanel";
        layer = UIPanelType.Tip;
    }
    public override void OnShow(params object[] para)
    {
        text = skin.transform.Find("Text").GetComponent<Text>();
        okBtn = skin.transform.Find("OkBtn").GetComponent<Button>();

        okBtn.onClick.AddListener(OnOkClick);

        if(para.Length==1)
        {
            text.text = (string)para[0];
        }
    }
 
    public void OnOkClick()
    {
        PanelManager.PopPanel();
    }
}
