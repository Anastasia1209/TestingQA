package JDBC;

import java.sql.SQLException;

public class Main {
    public static void main(String[] args) {
        try {
            String driver = "com.microsoft.sqlserver.jdbc.SQLServerDriver";
            ConnectorDB connectorDB = new ConnectorDB(driver, "jdbc:sqlserver://DESKTOP-U07UAVE;databaseName=Lab6_Testing;trustServerCertificate=true;encrypt=false;IntegratedSecurity=false", "sa", "1111");
            connectorDB.getConnection();

            //connectorDB.insertCar("NewModel", 2023, 30000.00, 1);
            //connectorDB.deleteCar(7);
            connectorDB.getAllCars();

            connectorDB.removeConnection();
        } catch (ClassNotFoundException | SQLException e) {
            e.printStackTrace();
        }
    }
}
