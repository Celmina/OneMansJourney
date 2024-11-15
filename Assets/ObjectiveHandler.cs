using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectiveHandler : MonoBehaviour
{
    public TextMeshProUGUI objectiveText1;
    public TextMeshProUGUI objectiveText2;
    public TextMeshProUGUI objectiveText3;
    private List<(string text,string tag)> objectiveList;
    private List<TextMeshProUGUI> objectiveText;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objectiveList = new List<(string, string)>
        {
            ("Click on the cube", "CubeEvent"),
            ("Click on the Red cube", "RedCubeEvent"),
            ("Click Portal", "PortalEvent"),
            ("Win", "WinEvent")
        };
        objectiveText = new List<TextMeshProUGUI>
        {
            objectiveText1,
            objectiveText2,
            objectiveText3,
        };
        objectiveText1.text = objectiveList[0].text;
        objectiveText2.text = objectiveList[1].text;
        objectiveText3.text = objectiveList[2].text;
    }

    public void UpdateObjective(string objectiveTag)
    {
        objectiveList.RemoveAll(x => x.tag == objectiveTag);
        for (int i = 0; i < objectiveText.Count; i++)
        {
            if (i < objectiveList.Count)
            {
                objectiveText[i].text = objectiveList[i].text;
            }
            else
            {
                objectiveText[i].text = "";
            }
        }
    }
    // Update is called once per frame
}
