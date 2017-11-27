public class ProjectEuler7 {
    
 public static boolean isPrime(long num) {
        if (num == 2) {
            return true;
        }
        if ((num & 1) == 0) {
            return false;
        }
        else
        {
          for (int i = 3; i < num; i++ ) {
              if (num % i == 0) {
                  return false;
              }
          }  
        }
        return true;
    }
    public static void main(String[] args) {
        boolean finished = false;
        int i = 1;
        int numPrime = 0;
      while (numPrime < 10002) {
          if (isPrime(i)) {
              numPrime++;
              System.out.println("primeNo: " + numPrime + " Prime is: " + i + " ");
              
              
          }
          i++;
      }
    } 
    
}
