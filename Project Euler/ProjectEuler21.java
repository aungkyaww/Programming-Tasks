public class ProjectEuler21 {

    /**
     * @param args the command line arguments
     */
    
    public static int[][] findAmicableUpTo(int num) {
        ArrayList<Integer> pairs = new ArrayList<>();
        if (num < 220) {
            return null;
        }
        
        for (int i = 219; i <= num; i++) {
          int[] factors;
          int[] factors2;
          int sum = 0;
          int sum2 = 0;
          factors = mathUtils.findFactors(i);
            for (int j = 0; j < factors.length - 1; j++) {
                sum += factors[j];
               
            }
          factors2 = mathUtils.findFactors(sum);
            for (int j = 0; j < factors2.length-1; j++) {
                sum2 += factors2[j];
               
            }
         
          if (sum2 == i && sum2 != sum) {
              boolean alreadyFound = false;
              for (int j = 0; j < pairs.size(); j++) {
                 // System.out.println(pairs.get(j));
                  if (sum == pairs.get(j) || sum2 == pairs.get(j)) {
                      alreadyFound = true;
                      break;
                  }
              }
              if (!alreadyFound) {
              //amicable
              pairs.add(sum);
              pairs.add(sum2);
              }
          }  
 
        }
        //System.out.println(pairs.size());
        int[][] amicablePairs = new int[((pairs.size()/2))][2];
      
        int index = 0;
        for (int i = 0; i < amicablePairs.length; i++) {
          amicablePairs[i][0] = pairs.get(index);
          amicablePairs[i][1] = pairs.get(index + 1);
          index += 2;
        }
       
        return amicablePairs;
    }
    
    public static void main(String[] args) {
        int[][] amicables;
        int sum = 0;
        amicables = findAmicableUpTo(10000);
        for (int i = 0; i < amicables.length; i++) {
            sum += amicables[i][0];
            sum += amicables[i][1];
        }
        System.out.println(sum);
    }
    
}
