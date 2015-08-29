using UnityEngine;
using System.Collections;

public class Buffer : ExecuteCom
{
    //此執行元件提供的貢獻率
    public float ContributionRatio { get; protected set; }
    public Buffer(ExecuteType _type, float _contributionRatio)
        : base(_type)
    {
        ContributionRatio = _contributionRatio;
    }
    public override void Execute(Chara _self, Chara _target)
    {
        base.Execute(_self, _target);
        Debug.Log(string.Format("對{0}施放{1}", Target.Name, Type));
    }
}
