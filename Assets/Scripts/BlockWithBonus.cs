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
        var bonus = Random.Range(0, 3);
        BonusBase bonusScriptObject = (BonusBase) bonusObject.AddComponent(bonusScript.GetClass());
        if (bonus == 0)
        {
            bonusScriptObject.backgroundColor = backgroundColor;
            bonusScriptObject.text = text;
        }
        else if (bonus == 1)
        {
            bonusScriptObject.backgroundColor = Color.red;
            bonusScriptObject.text = "Fire";
        }
        else if (bonus == 2)
        {
            bonusScriptObject.backgroundColor = Color.grey;
            bonusScriptObject.text = "Steel";
        }
        else if (bonus == 3)
        {
            bonusScriptObject.backgroundColor = Color.white;
            bonusScriptObject.text = "Norm";
        }

        bonusScriptObject.bonusId = bonus;
        bonusScriptObject.player = playerScript;
        bonusScriptObject.textColor = textColor;
        
        base.OnBlockDestroy();
    }
}
