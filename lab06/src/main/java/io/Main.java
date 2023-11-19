package io;

import java.io.*;

public class Main {
    public static void main(String[] args) {
        String fileName = "output.txt";

//        try (BufferedWriter bw = new BufferedWriter(new FileWriter(fileName))) {
//            bw.write("Hello, World!");
//            bw.newLine();
//            bw.write("This is a new line.");
//        } catch (IOException e) {
//            e.printStackTrace();
//        }

        try (BufferedReader br = new BufferedReader(new FileReader(fileName))) {
            String line;
            while ((line = br.readLine()) != null) {
                System.out.println(line);
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
