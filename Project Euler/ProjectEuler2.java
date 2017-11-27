public class ProjectEuler2 {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        int nextTerm = 2;
        int num1 = 1;
        int num2 = 1;
        int sum = 0;
        while (nextTerm < 4000000) {
           if (nextTerm % 2 == 0) {
               sum += nextTerm;
           }
           num1 = num2;
           num2 = nextTerm;
           nextTerm = num1 + num2;
           System.out.println(nextTerm);
        }
        System.out.println(sum);
    }
    
}
