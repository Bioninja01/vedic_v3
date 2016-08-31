public class Vid_DB_Table : Vid_Object
{
    public string tableName = "";

    public new void Awake() 
    {
        base.Awake();
        acceptableInputs = new VidData_Type[1];
            acceptableInputs[0] = VidData_Type.DATABASE_QUERY;
        output = new Vid_Data(VidData_Type.DATABASE_TABLE);
        output.setData(tableName);
    }

    public override void updateData() {
        output.setData(tableName);
    }

}
