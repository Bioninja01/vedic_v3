using System.Text;

public class Vid_DB_Col : Vid_Object {

    public enum ColState {
        NAME,
        EXPRESSION,
        DATA,
    }
    public ColState colMode = ColState.NAME;
    public MySql_colTypes type = MySql_colTypes.MYSQL_INT;

    public string colName;
    public string cellName = "defaultNAME";
    public string asName = "defaultNAME";

    private bool isSetable = false;
    public bool NotNull = false;
    public bool asFlag = false;
    public int charvar_Number = 1;


    public new void Awake() 
    {
        base.Awake();
        base.output_dataType = VidData_Type.DATABASE_COL;
        NotNull = false;
    }

    public override string ToString() {
        StringBuilder sb = new StringBuilder();
        switch (colMode) {
            case ColState.NAME:
                if (asFlag) {
                    return colName + " As" + asName;
                }
                else {
                    return colName;
                }
            case ColState.EXPRESSION:
                return colName + " = " + cellName;
            case ColState.DATA:
                switch (type) {
                    case MySql_colTypes.MYSQL_INT:
                        sb.Append(colName + " int ");
                        if (NotNull) {
                            sb.Append("NOT NULL");
                        }
                        break;
                    case MySql_colTypes.MYSQL_FLOAT:
                        sb.Append(colName + " float ");
                        if (NotNull) {
                            sb.Append("NOT NULL");
                        }
                        break;
                    case MySql_colTypes.MYSQL_DOUBLE:
                        sb.Append(colName + " double ");
                        if (NotNull) {
                            sb.Append("NOT NULL");
                        }
                        break;
                    case MySql_colTypes.MYSQL_TIMESTAMP:
                        sb.Append(colName + " TIMESTAMP  ");
                        if (NotNull) {
                            sb.Append("NOT NULL");
                        }
                        break;
                    case MySql_colTypes.MYSQL_CHAR:
                        sb.Append(colName + " VARCHAR(" + charvar_Number + ")");
                        if (NotNull) {
                            sb.Append("NOT NULL");
                        }
                        break;
                    case MySql_colTypes.MYSQL_BLOB:
                        sb.Append(colName + " BLOB ");
                        if (NotNull) {
                            sb.Append("NOT NULL");
                        }
                        break;
                    case MySql_colTypes.MYSQL_ENUM:
                        break;
                }
                return sb.ToString();
        }
        return "";
    }

    public void toggleMySql_ColType() {
        switch (type) {
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

    /*Getters*/
    public bool isNotNull(){ return NotNull; }
    public int getCarVarNumber() { return charvar_Number; }
    public bool getSetable() { return isSetable; }

    /*Setters*/
    public void set_NotNull(bool b){this.NotNull = b; }
    public void setCarVarNumber(int i) { this.charvar_Number = i; }
    public void setSetable(bool b) {
        this.isSetable = b;
    }
}
