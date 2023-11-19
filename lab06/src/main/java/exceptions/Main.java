package exceptions;

public class Main {
    public static void main(String[] args) {
        try {
            // Попытка создать автомобиль с некорректной ценой
            Car car1 = new Car("Toyota", "Camry", 2021, -25000);
        } catch (NegativePriceException e) {
            System.out.println("Exception caught: " + e.getMessage());
        } catch (InvalidYearException | InvalidBrandException e) {
            System.out.println("Unexpected exception caught: " + e.getMessage());
        }

        try {
            // Попытка создать автомобиль с некорректным годом
            Car car2 = new Car("Honda", "Civic", 1800, 22000);
        } catch (NegativePriceException | InvalidBrandException e) {
            System.out.println("Unexpected exception caught: " + e.getMessage());
        } catch (InvalidYearException e) {
            System.out.println("Exception caught: " + e.getMessage());
        }

        try {
            // Попытка создать автомобиль с некорректным брендом
            Car car3 = new Car("InvalidBrand", "Model", 2022, 30000);
        } catch (NegativePriceException | InvalidYearException e) {
            System.out.println("Unexpected exception caught: " + e.getMessage());
        } catch (InvalidBrandException e) {
            System.out.println("Exception caught: " + e.getMessage());
        }
    }
}

class NegativePriceException extends Exception {
    public NegativePriceException() {
        super("Car price cannot be negative.");
    }
}

class InvalidYearException extends Exception {
    public InvalidYearException(int year) {
        super("Invalid year for the car: " + year + ". Year should be between 1900 and the current year.");
    }
}

class InvalidBrandException extends Exception {
    public InvalidBrandException(String brand) {
        super("Invalid brand for the car: " + brand + ". Expected a valid brand.");
    }
}

class Car {
    private String brand;
    private String model;
    private int year;
    private double price;

    public Car(String brand, String model, int year, double price) throws NegativePriceException, InvalidYearException, InvalidBrandException {
        if (price < 0) {
            throw new NegativePriceException();
        }

        if (year < 1900 || year > java.time.Year.now().getValue()) {
            throw new InvalidYearException(year);
        }

        if (!isValidBrand(brand)) {
            throw new InvalidBrandException(brand);
        }

        this.brand = brand;
        this.model = model;
        this.year = year;
        this.price = price;
    }

    private boolean isValidBrand(String brand) {
        String[] validBrands = {"Toyota", "Honda", "Ford", "Chevrolet", "Tesla"};
        for (String validBrand : validBrands) {
            if (validBrand.equalsIgnoreCase(brand)) {
                return true;
            }
        }
        return false;
    }
}