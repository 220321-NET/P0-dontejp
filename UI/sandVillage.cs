
namespace UI;

public class sandVillage: leafVillage
{
    public sandVillage(IP0BL bl): base(bl){}

    public override void Start()
    {
        VillageID = 3;
        Welcome();
        CartPrompt();
    }
}