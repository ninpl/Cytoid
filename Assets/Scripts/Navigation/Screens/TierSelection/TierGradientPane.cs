using UnityEngine;
using UnityEngine.UI;

public class TierGradientPane : MonoBehaviour
{
    public Text titleText;
    public Text completionPercentageText;
    public GradientMeshEffect backgroundGradient;

    public void SetModel(Tier tier)
    {
        titleText.text = tier.data.name;
        completionPercentageText.text = "TIER_COMPLETION_PERCENTAGE"
            .Get($"{(Mathf.FloorToInt(tier.data.completionPercentage * 100 * 100) / 100f):0.00}");
        backgroundGradient.SetGradient(new ColorGradient(tier.data.colorPalette.background, -45));
    }
}