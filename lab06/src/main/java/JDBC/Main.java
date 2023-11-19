package JDBC;

import java.sql.SQLException;

public class Main {
    public static void main(String[] args) {
        try {
            ConnectorDB connectorDB = new ConnectorDB("localhost:3306/sys", "root", "root");
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
