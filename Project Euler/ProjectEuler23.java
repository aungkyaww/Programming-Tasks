public class ProjectEuler23 {


    /**
     * @param args the command line arguments
     */
    
    
//     public static int sumOfProperDivisors (int num) {
//       int sum=0;
//    for (int i=1; i<num; i++) {
//
//        if (num%i==0) {
//
//            sum += i;
//        }
//    }
//       return sum;
//   }
//   
//    
//    public static ArrayList<Integer> findAbundantsUpTo(int inclusiveUB) {
//      ArrayList<Integer> abundants = new ArrayList<>();
//        int sumOfFactors;
//          
//        for (int i = 0; i <= inclusiveUB; i++) {
//            sumOfFactors = sumOfProperDivisors(i);
//            if (sumOfFactors > i) {
//                abundants.add(i);
//               
//            }
//        }
//         // System.out.println(abundants.toString());
//        return abundants;
//    }
//    
//    public static void main(String[] args) {
//        //Calculate all abundant numbers up to 28123
//        // --- calculate factors of i
//        // --- check if deficient or abundant
//        //    --- sum all factors
//        //    --- test values for less or more than n
//        // --- add abundant values to list
//        //Check which numbers I can add together to make i
//        // --- for i to 28123
//        // --- for j
//        // --- for k, check if j+k == i
//        // --- if j+k > i, continue
//        // --- add to a list if j+k == i
//        //Find numbers I can't make with abundant numbers
//        // --- loop through, when i != abundantSum list, add to another list
//        //Sum final list, output
//        
//        int limit = 28124;
//        ArrayList<Integer> list;
//        list = findAbundantsUpTo(28123);
//        System.out.println("finished finding abundants -- total: " + list.size());
//        ArrayList<Integer> sumOfAbundants = new ArrayList<>();
//        int listSize = list.size();
//        int tempNum;
//         for (int i=0; i<listSize; i++) {
//
//        for (int j=i; j<listSize; j++) {
//
//            tempNum = list.get(i) + list.get(j);
//            if (tempNum < limit) {
//                sumOfAbundants.add(tempNum);
//            }
//        }
//    }
//        
//        
//        
////        for (int i = 0; i < abundants.size(); i++) {
////            for (int j = 0; j < abundants.size(); j++) {
////                if ((abundants.get(i) + abundants.get(j)) < 28124) {
////                    sumOfAbundants.add(abundants.get(i) + abundants.get(j));
////                    System.out.println("number addded at: " + i);
////                }
////            }
////        }
//       System.out.println("finished adding abundants");
//     int sum = 0;
//        for (int i = 0; i < limit; i++) {
//            if (!sumOfAbundants.contains(i)) {
//                sum+= sumOfAbundants.get(i);
//                System.out.println(sum);
//                    }
//        
//        }
//        System.out.println(sum);
//    }
    
    
    public static void main(String[] args) {

    int limit = 28124;
    int sum=0;
    int tempNum;
    int listSize;
    ArrayList<Integer> list = new ArrayList<Integer>();
    ArrayList<Integer> sumList = new ArrayList<Integer>();
    for (int i=0; i<limit; i++) {

        if (isAbundant(i)) {

            list.add(i);
        }
    }
    listSize = list.size();

    for (int i=0; i<listSize; i++) {

        for (int j=i; j<listSize; j++) {

            tempNum = list.get(i) + list.get(j);
            if (tempNum < limit) {
                sumList.add(tempNum);
            }
        }
    }

    for (int i=1; i<limit; i++) {

        if (sumList.contains(i) == false) {

            sum += i;
        }
    }
    System.out.println(sum);
}

public static boolean isAbundant(int n) {

    int sum=0;
    for (int i=1; i<n; i++) {

        if (n%i==0) {

            sum += i;
        }
    }
    if (sum>n) { return true; }
    else { return false; }
}
    
}
