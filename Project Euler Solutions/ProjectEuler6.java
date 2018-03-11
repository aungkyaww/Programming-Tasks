public class ProjectEuler6 {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        long sumOfSquares = 0L;
        long squareOfSum = 0L;
        
        for (int i = 0; i <= 100; i++) {
            sumOfSquares += i*i;
        }
        for (int j = 0; j <= 100; j++) {
            squareOfSum += j;
        }
        squareOfSum *= squareOfSum;
        
        System.out.println(squareOfSum - sumOfSquares);
    }
    
}
