public class Vid_DB_Col : Vid_Object {

    public string colName;

    public MySql_colTypes type = MySql_colTypes.MYSQL_INT;

    private bool isSetable = false;
    private bool NotNull;
    private int charvar_Number = 1;

    public new void Awake() 
    {
        base.Awake();
        NotNull = false;
        output = new Vid_Data(VidData_Type.DATABASE_COL);
        output.setData(colName);
    }
    public void toggleMySql_ColType()
    {
        switch (type)
        {
            case MySql_colTypes.MYSQL_INT:
                type = MySql_colTypes.MYSQL_FLOAT;
                break;
            case MySql_colTypes.MYSQL_FLOAT:
                type = MySql_colTypes.MYSQL_DOUBLE;
                break;
            case MySql_colTypes.MYSQL_DOUBLE:
                type = MySql_colTypes.MYSQL_CHAR;
                break;
            case MySql_colTypes.MYSQL_CHAR:
                type = MySql_colTypes.MYSQL_BLOB;
                break;
            case MySql_colTypes.MYSQL_BLOB:
                type = MySql_colTypes.MYSQL_TIMESTAMP;
                break;
            case MySql_colTypes.MYSQL_TIMESTAMP:
                type = MySql_colTypes.MYSQL_VARCHAR;
                break;
            case MySql_colTypes.MYSQL_VARCHAR:
                type = MySql_colTypes.MYSQL_ENUM;
                break;
            case MySql_colTypes.MYSQL_ENUM:
                type = MySql_colTypes.MYSQL_INT;
                break;
            default:
                type = MySql_colTypes.MYSQL_INT;
                break;
        }
    }

    public override void updateData() {
        output.setData(colName);
    }
    /*Getters*/
    public bool isNotNull(){ return NotNull; }
    public int getCarVarNumber() { return charvar_Number; }
    public bool getSetable() { return isSetable; }

    /*Setters*/
    public void set_NotNull(bool b){this.NotNull = b; }
    public void setCarVarNumber(int i) { this.charvar_Number = i; }
    public void setSetable(bool b) {
        this.isSetable = b;
        if (b)
        {
            output = new Vid_Data(VidData_Type.DATABASE_COL, this);
            output.setData("value");
        }
        else
        {
            output = null;
        }
    }
}
