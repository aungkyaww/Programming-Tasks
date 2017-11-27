public class PE16 {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
       BigInteger val = new BigInteger("2");
       val = val.pow(1000);
       long sum = mathUtils.addDigits(val);
       System.out.println(sum);
    }
    
}
