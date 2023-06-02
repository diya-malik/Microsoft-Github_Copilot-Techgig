import java.util.HashMap;
import java.util.Map;
import java.util.*;

public class InventoryManagementSystem {
    private Map<String, Integer> inventory;

    public InventoryManagementSystem() {
        inventory = new HashMap<>();
    }

    public void addProduct(String product, int quantity) {
        if (inventory.containsKey(product)) {
            int currentQuantity = inventory.get(product);
            inventory.put(product, currentQuantity + quantity);
        } else {
            inventory.put(product, quantity);
        }
        System.out.println(quantity + " " + product + "(s) added to the inventory.");
    }

    public void updateProduct(String product, int quantity) {
        if (inventory.containsKey(product)) {
            inventory.put(product, quantity);
            System.out.println(product + " quantity updated to " + quantity);
        } else {
            System.out.println(product + " does not exist in the inventory.");
        }
    }

    public void removeProduct(String product) {
        if (inventory.containsKey(product)) {
            inventory.remove(product);
            System.out.println(product + " removed from the inventory.");
        } else {
            System.out.println(product + " does not exist in the inventory.");
        }
    }

    public int getStock(String product) {
        return inventory.getOrDefault(product, 0);
    }

    public void printInventory() {
        System.out.println("Inventory:");
        for (Map.Entry<String, Integer> entry : inventory.entrySet()) {
            System.out.println(entry.getKey() + " - " + entry.getValue());
        }
    }

    public static void main(String[] args) {
        InventoryManagementSystem ims = new InventoryManagementSystem();
        // write code to add product and the quantity from command line

        Scanner sc = new Scanner(System.in);
        System.out.println("Enter the number of products to be added: ");
        int n = sc.nextInt();
        for(int i=0;i<n;i++){
            System.out.println("Enter the product name: ");
            String product = sc.next();
            System.out.println("Enter the quantity: ");
            int quantity = sc.nextInt();
            ims.addProduct(product, quantity);
        }

        System.out.println("Enter the number of products to be updated: ");
        int n1 = sc.nextInt();
        for(int i=0;i<n1;i++){
            System.out.println("Enter the product name: ");
            String product = sc.next();
            System.out.println("Enter the quantity: ");
            int quantity = sc.nextInt();
            ims.updateProduct(product, quantity);
        }

        System.out.println("Enter the number of products to be removed: ");
        int n2 = sc.nextInt();
        for(int i=0;i<n2;i++){
            System.out.println("Enter the product name: ");
            String product = sc.next();
            ims.removeProduct(product);
        }

        System.out.println("Enter the number of products to get the stock: ");
        int n3 = sc.nextInt();
        for(int i=0;i<n3;i++){
            System.out.println("Enter the product name: ");
            String product = sc.next();
            System.out.println("Stock of "+product+" is "+ims.getStock(product));
        }

        ims.printInventory();
        sc.close();
    }
}
