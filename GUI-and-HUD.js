import java.util.Scanner;

public class Game {
    private int playerHealth;
    private int playerAmmo;

    public Game() {
        playerHealth = 100;
        playerAmmo = 20;
    }

    public void start() {
        boolean running = true;
        Scanner scanner = new Scanner(System.in);

        while (running) {
            // Render HUD
            renderHUD();

            // Render menu
            renderMenu();

            // Process user input
            String input = scanner.nextLine();
            switch (input) {
                case "1":
                    // Play game
                    System.out.println("Game is starting...");
                    // Add your game logic here
                    break;
                case "2":
                    // Adjust settings
                    System.out.println("Settings menu is not implemented yet.");
                    break;
                case "3":
                    // Exit game
                    running = false;
                    break;
                default:
                    System.out.println("Invalid input. Please try again.");
                    break;
            }
        }

        System.out.println("Exiting game. Goodbye!");
    }

    private void renderHUD() {
        System.out.println("----------");
        System.out.println("Health: " + playerHealth);
        System.out.println("Ammo: " + playerAmmo);
        System.out.println("----------");
    }

    private void renderMenu() {
        System.out.println("=== Game Menu ===");
        System.out.println("1. Play");
        System.out.println("2. Settings");
        System.out.println("3. Exit");
        System.out.print("Enter your choice: ");
    }

    public static void main(String[] args) {
        Game game = new Game();
        game.start();
    }
}
