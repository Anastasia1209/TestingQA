package JDBC;

import java.sql.*;

public class ConnectorDB {
    private Connection connection;
    private String url;
    private String user;
    private String pass;

    public ConnectorDB(String url, String user, String pass) throws ClassNotFoundException {
        this.url = url;
        this.user = user;
        this.pass = pass;
    }

    public void getConnection() throws SQLException {
        connection = DriverManager.getConnection("jdbc:mysql://" + url, user, pass);
        if (!connection.isClosed())
            System.out.println("Connection successful");
    }

    public void removeConnection() throws SQLException {
        System.out.println("Close connection");
        if (connection != null && !connection.isClosed()) {
            connection.close();
        }
    }

    public void closeStatement(Statement statement) throws SQLException {
        if (statement != null && !statement.isClosed()) {
            statement.close();
        }
    }

    public void insertCar(String model, int year, double price, int brandId) throws SQLException {
        String sql = "INSERT INTO cars (model, year, price, brand_id) VALUES (?, ?, ?, ?)";
        try (PreparedStatement preparedStatement = connection.prepareStatement(sql)) {
            preparedStatement.setString(1, model);
            preparedStatement.setInt(2, year);
            preparedStatement.setDouble(3, price);
            preparedStatement.setInt(4, brandId);
            preparedStatement.executeUpdate();
        }
    }

    public void deleteCar(int carId) throws SQLException {
        String sql = "DELETE FROM cars WHERE car_id = ?";
        try (PreparedStatement preparedStatement = connection.prepareStatement(sql)) {
            preparedStatement.setInt(1, carId);
            preparedStatement.executeUpdate();
        }
    }

    public void getAllCars() throws SQLException {
        String sql = "SELECT cars.car_id, cars.model, cars.year, cars.price, brands.brand_name " +
                "FROM cars " +
                "INNER JOIN brands ON cars.brand_id = brands.brand_id";
        try (PreparedStatement preparedStatement = connection.prepareStatement(sql);
             ResultSet resultSet = preparedStatement.executeQuery()) {
            while (resultSet.next()) {
                int carId = resultSet.getInt("car_id");
                String model = resultSet.getString("model");
                int year = resultSet.getInt("year");
                double price = resultSet.getDouble("price");
                String brandName = resultSet.getString("brand_name");

                System.out.println("Car ID: " + carId + ", Model: " + model +
                        ", Year: " + year + ", Price: " + price +
                        ", Brand: " + brandName);
            }
        }
    }
}
