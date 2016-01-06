using UnityEngine;
using System.Collections;

public class EventUI : MonoBehaviour
{
    InvestigateUI MyInvestigateUI;
    ResultUI MyResultUI;
    AccidentUI MyAccidentUI;
    CampUI MyCampUI;
    public void Init()
    {
        MyInvestigateUI = transform.FindChild("Investigate").GetComponent<InvestigateUI>();
        MyInvestigateUI.Init();
        MyResultUI = transform.FindChild("Result").GetComponent<ResultUI>();
        MyResultUI.Init();
        MyAccidentUI = transform.FindChild("Accident").GetComponent<AccidentUI>();
        MyAccidentUI.Init();
        MyCampUI = transform.FindChild("Camp").GetComponent<CampUI>();
        MyCampUI.Init();
    }
}
