
namespace UI;

public class stoneVillage: leafVillage
{
    public stoneVillage(IP0BL bl): base(bl){}

    public override void Start()
    {
        VillageID = 5;
        Welcome();
        CartPrompt();
    }
}