
namespace UI;

public class mistVillage: leafVillage
{
    public mistVillage(IP0BL bl): base(bl){}

    public override void Start()
    {
        VillageID = 4;
        Welcome();
        CartPrompt();
    }
}