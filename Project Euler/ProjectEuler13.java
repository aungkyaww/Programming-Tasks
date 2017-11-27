public class PE13 {
  
    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) throws FileNotFoundException, IOException {
       String filePath = "Put file path to "numbers.txt" here"; //Download txt file from https://projecteuler.net/problem=13
       
       FileReader fileReader = new FileReader(filePath);
       BufferedReader bufferedReader = new BufferedReader(fileReader);
       BigInteger sum = BigInteger.valueOf(0);
       String line = null;
       while ((line = bufferedReader.readLine()) != null) {
           sum = sum.add(new BigInteger(line));
           System.out.println(sum);
       }
        
    }
    
}
