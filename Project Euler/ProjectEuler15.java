public class ProjectEuler15 {

    /**
     * @param args the command line arguments
     */
    
    public static void main(String[] args) {
        
   long c = 1;
   int n = 40;
   int k = 20;
   
        for (int i = 0; i < k; i++) {
            c = c * (n - i);
            c = c / (i + 1);
            
        }
      System.out.println(c);   
    }
    
}
