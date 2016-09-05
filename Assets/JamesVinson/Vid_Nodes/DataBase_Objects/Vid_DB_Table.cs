public class Vid_DB_Table : Vid_Object
{
    public string tableName = "";

    public new void Awake() 
    {
        base.Awake();
        acceptableInputs = new VidData_Type[1];
            acceptableInputs[0] = VidData_Type.DATABASE_QUERY;
    }

    public override string ToString() {
        return tableName;
    }

}
