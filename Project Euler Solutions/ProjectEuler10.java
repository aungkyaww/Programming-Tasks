public class ProjectEuler10 {

 
    public static void main(String[] args) {
      int[] primes = new int[0];  
      primes = mathUtils.findPrimesUpTo(2000000); //Uses a prime sieve 
      arrayUtils.printArray(primes);
      long total = 0L;
        for (int i = 0; i < primes.length; i++) {
          total += primes[i]; 
         // System.out.print(total + " ");
        }
  
        System.out.println(total);
    }
    
}
