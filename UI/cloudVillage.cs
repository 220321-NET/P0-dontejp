using DB;
using Models;

namespace UI;

public class cloudVillage: leafVillage
{
    public cloudVillage(IP0BL bl): base(bl){}

    public override void Start()
    {
        VillageID = 2;
        Welcome();
        CartPrompt();
    }
}