package fundamentals;

import java.util.Random;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        System.out.println("Enter name: ");
        String name = new Scanner(System.in).nextLine();
        System.out.println("Hello, " + name + "!!!");

        Random random = new Random();

        // Генерируем случайное число от 1 до 100
        int secretNumber = random.nextInt(100) + 1;

        // Создаем объект Scanner для чтения ввода пользователя
        Scanner scanner = new Scanner(System.in);

        // Переменная для хранения попыток игрока
        int attempts = 0;

        System.out.println("Welcome to the \"Guess the Number\" game!");
        System.out.println("Try to guess the number between 1 and 100.");

        while (true) {
            System.out.print("Enter your guess: ");
            int userGuess = scanner.nextInt();
            attempts++;

            if (userGuess == secretNumber) {
                System.out.println("Congratulations! You guessed the number " + secretNumber + " in " + attempts + " attempts.");
                break;
            } else if (userGuess < secretNumber) {
                System.out.println("The secret number is higher. Try again.");
            } else {
                System.out.println("The secret number is lower. Try again.");
            }
        }

        scanner.close();
    }
}
