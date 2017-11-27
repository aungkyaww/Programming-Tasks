public class ProjectEuler20 {

    /**
     * @param args the command line arguments
     */
    
     public static BigInteger factorialBig(int num) {
    BigInteger fact = new BigInteger("1");
    for (int i = 1; i <= num; i++) {
        fact = fact.multiply(BigInteger.valueOf(i));
    }
    return fact;
     }
     
     public static long addDigits(BigInteger num) {
        String number = num.toString();
        String[] arr = number.split("");
        int sumOfDigits = 0;
       
        for (int i = 0; i < arr.length; i++) {
            sumOfDigits += Integer.parseInt(arr[i]);
        }
        return sumOfDigits;
    }
    
    public static void main(String[] args) {
       BigInteger fact = new BigInteger("0");
       fact = factorialBig(100);
       long sum = 0L;
       
       sum = addDigits(fact);
       System.out.print(sum);
    }
    
}
