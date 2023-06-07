import java.util.Scanner;

public class DoomGame {
    private int playerHealth;
    private int playerAmmo;

    public DoomGame() {
        playerHealth = 100;
        playerAmmo = 50;
    }

    public void displayHUD() {
        System.out.println("------ HUD ------");
        System.out.println("Health: " + playerHealth);
        System.out.println("Ammo: " + playerAmmo);
        System.out.println("------------------");
    }

    public void displayMainMenu() {
        System.out.println("------ Main Menu ------");
        System.out.println("1. Start New Game");
        System.out.println("2. Load Game");
        System.out.println("3. Settings");
        System.out.println("4. Exit");
        System.out.println("-----------------------");
    }

    public void startGame() {
