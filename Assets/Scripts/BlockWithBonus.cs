using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BlockWithBonus : BlockScript
{
    [SerializeField]
    private GameObject bonusPrefab;
    [SerializeField]
    private MonoScript bonusScript;
    [SerializeField]
    private Color backgroundColor;
    [SerializeField]
    private Color textColor;
    [SerializeField]
    private string text;

    protected new void Start() {
        base.Start();
    }

    protected override void OnBlockDestroy()
    {
        Debug.Log("OnBlockDestroyed!");
        Vector3 position = transform.position;
        Quaternion rotation = transform.rotation;
        GameObject bonusObject = Instantiate(bonusPrefab, position, rotation);
        Debug.Log(bonusObject.name);
        BonusBase bonusScriptObject = (BonusBase) bonusObject.AddComponent(bonusScript.GetClass()); 
        bonusScriptObject.player = playerScript;
        bonusScriptObject.backgroundColor = backgroundColor;
        bonusScriptObject.textColor = textColor;
        bonusScriptObject.text = text;
        base.OnBlockDestroy();
    }
}
