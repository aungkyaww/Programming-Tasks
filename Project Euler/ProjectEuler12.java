public class ProjectEuler12 {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        int[] factors = new int[0];
        long tNum = 0;
        boolean finished = false;
        int i = 0; 
        
        while (!finished) {
           i++;
           tNum = mathUtils.triangularNumbers.findNth(i);
          factors = mathUtils.findFactors(tNum);
          //System.out.println("factors for: " + i + "found: " + factors.length);
          if (factors.length >= 500) {
              finished = true;
          }
        }
        System.out.println(tNum);
    }
    
}
