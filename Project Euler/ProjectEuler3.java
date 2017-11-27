public class PE3 {

  

    public static boolean isPrime(long num) {
      
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
      
        long x = 600851475143L;
        long z = 3;
        
       ArrayList<Long> primes = new ArrayList<Long>();
        
        
        while (z*z <= x) {
          
          if (isPrime(z)) {
              primes.add(z);
              System.out.print(z + " ");
          }
          z += 2;
            
        }
        System.out.println();
        System.out.println();
        System.out.println();
        System.out.println();
        System.out.println();
        
        for (int i = 0; i < primes.size(); i++) {
           if (x % primes.get(i) == 0) {
               System.out.print(primes.get(i) + " ");
           }
        }
        

}
    
}
