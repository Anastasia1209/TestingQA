package string;

public class Main {
    public static void main(String[] args) {
        // Исходная строка
        String originalString = "Hello, World! This World is amazing.";

        // Методы модификации строки
        String modifiedString1 = appendText(originalString, " This is an additional text.");
        String modifiedString2 = toUpperCase(originalString);
        String modifiedString3 = replaceSubstring(originalString, "World", "Java");
        String modifiedString4 = replaceFirstOccurrence(originalString, "World", "Universe");
        String modifiedString5 = replaceLastOccurrence(originalString, "World", "Galaxy");
        String modifiedString6 = removeAllOccurrences(originalString, "World");
        String modifiedString7 = reverseEachWord(originalString);

        // Вывод результатов
        System.out.println("Original String: " + originalString);
        System.out.println("Modified String 1: " + modifiedString1);
        System.out.println("Modified String 2: " + modifiedString2);
        System.out.println("Modified String 3: " + modifiedString3);
        System.out.println("Modified String 4: " + modifiedString4);
        System.out.println("Modified String 5: " + modifiedString5);
        System.out.println("Modified String 6: " + modifiedString6);
        System.out.println("Modified String 7: " + modifiedString7);
    }

    // Метод добавления текста к строке
    public static String appendText(String original, String additionalText) {
        return original + additionalText;
    }

    // Метод преобразования строки в верхний регистр
    public static String toUpperCase(String original) {
        return original.toUpperCase();
    }

    // Метод замены подстроки в строке
    public static String replaceSubstring(String original, String target, String replacement) {
        return original.replace(target, replacement);
    }

    // Метод замены первого вхождения подстроки в строке
    public static String replaceFirstOccurrence(String original, String target, String replacement) {
        return original.replaceFirst(target, replacement);
    }

    // Метод замены последнего вхождения подстроки в строке
    public static String replaceLastOccurrence(String original, String target, String replacement) {
        int lastIndex = original.lastIndexOf(target);
        if (lastIndex != -1) {
            return original.substring(0, lastIndex) + replacement + original.substring(lastIndex + target.length());
        } else {
            return original;
        }
    }

    // Метод удаления всех вхождений подстроки в строке
    public static String removeAllOccurrences(String original, String target) {
        return original.replaceAll(target, "");
    }

    // Метод инвертирования каждого слова в строке
    public static String reverseEachWord(String original) {
        String[] words = original.split(" ");
        for (int i = 0; i < words.length; i++) {
            words[i] = new StringBuilder(words[i]).reverse().toString();
        }
        return String.join(" ", words);
    }
}
