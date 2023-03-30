using System;

namespace LabOP_2Sem;

public class Invention
{
    private string ProdName { get; set; }

    public string  OfficialName { get; }

    public int Action()
    {
        return new Random().Next(-1000,1000);
    }

    public Invention(string prodName, string officialName)
    {
        ProdName = prodName;
        OfficialName = officialName;
    }
}