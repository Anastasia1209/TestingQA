package threads;

import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;
import java.util.concurrent.Semaphore;
import java.util.concurrent.locks.ReentrantLock;

public class Main {
    public static void main(String[] args) throws InterruptedException {
        // - - - - - - - Task_01 (1) - - - - - - -

        Operator operator = new Operator();
        for(int i = 0; i < 10; i++){
            new Thread(new Client(i,operator)).start();
        }

        // - - - - - - - Task_01 (2) - - - - - - -

        Semaphore semaphore = new Semaphore(2);
        Mountain mountain = new Mountain(semaphore);
        for(int i = 0; i < 30; i++){
            if(i%5 == 0)
                new Thread(new Skier(i,mountain,"elite")).start();
            else new Thread(new Skier(i,mountain,"not elite")).start();
        }

    }
}